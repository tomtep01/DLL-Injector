using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DLL_Injector_VB_NET_Core
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, uint dwStackSize, IntPtr lpStartAddress,
                                                        IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        private const int PROCESS_CREATE_THREAD = 0x0002;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;
        private const int PROCESS_VM_OPERATION = 0x0008;
        private const int PROCESS_VM_WRITE = 0x0020;
        private const int PROCESS_VM_READ = 0x0010;
        private const uint MEM_COMMIT = 0x00001000;
        private const uint MEM_RESERVE = 0x00002000;
        private const uint PAGE_READWRITE = 0x04;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
            foreach (Process p in Process.GetProcesses())
            {
                listBoxProcesses.Items.Add(p.ProcessName + " (ID: " + p.Id.ToString() + ")");
            }
        }

        private void listBoxProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem != null)
            {
                string selectedItem = listBoxProcesses.SelectedItem.ToString();
                int idStartIndex = selectedItem.IndexOf("(ID: ") + 5;
                int idEndIndex = selectedItem.Length - 1;
                int processId = int.Parse(selectedItem.Substring(idStartIndex, idEndIndex - idStartIndex));

                string processName = selectedItem.Substring(0, idStartIndex - 6); // Extract the process name
                string selectedProcess = processName + " (ID: " + processId.ToString() + ")"; // Merge the process name and ID into a single string

                labelProcessSelected.Text = selectedProcess; // Display the selected process in the TextBox
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBoxProcesses.Items.Clear();

            foreach (Process p in Process.GetProcesses())
            {
                string processName = p.ProcessName + " (ID: " + p.Id.ToString() + ")";
                if (string.IsNullOrEmpty(textBox1.Text) || processName.Contains(textBox1.Text, StringComparison.OrdinalIgnoreCase))
                {
                    listBoxProcesses.Items.Add(processName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxProcesses.Items.Clear();

            foreach (Process p in Process.GetProcesses())
            {
                listBoxProcesses.Items.Add(p.ProcessName + " (ID: " + p.Id.ToString() + ")");
            }

            labelProcessSelected.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files (*.dll)|*.dll";
            openFileDialog.Title = "Select a DLL file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                foreach (string file in openFileDialog.FileNames)
                {
                    string dllName = Path.GetFileName(openFileDialog.FileName);
                    listBoxDlls.Items.Add(dllName);
                    DllsPath.Items.Add(openFileDialog.FileName);
                }
            }
        }

        private void listBoxDlls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDlls.SelectedItem != null)
            {
                labelSelectedDll.Text = listBoxDlls.SelectedItem.ToString();
                if (listBoxDlls.SelectedIndex != DllsPath.SelectedIndex)
                {
                    DllsPath.SelectedIndex = listBoxDlls.SelectedIndex;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBoxDlls.SelectedItem != null)
            {
                listBoxDlls.Items.Remove(listBoxDlls.SelectedItem);
                labelSelectedDll.Text = "";
                if (DllsPath.SelectedItem != null)
                {
                    listBoxDlls.Items.Remove(listBoxDlls.SelectedItem);
                    label3.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dllPath = label3.Text;
            if (dllPath == "")
            {
                MessageBox.Show("Please select a DLL file to inject", "Error");
                return;
            }

            if (listBoxProcesses.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a process to inject into", "Error");
                return;
            }

            string processName = listBoxProcesses.SelectedItem.ToString().Split('(')[0].Trim();
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                MessageBox.Show("Unable to find process: " + processName, "Error");
                return;
            }

            int processId = processes[0].Id;
            IntPtr processHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, processId);
            if (processHandle == IntPtr.Zero)
            {
                MessageBox.Show("Unable to open process: " + processName, "Error");
                return;
            }

            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32"), "LoadLibraryA");
            if (loadLibraryAddr == IntPtr.Zero)
            {
                MessageBox.Show("Unable to find LoadLibraryA function in kernel32.dll", "Error");
                return;
            }

            byte[] dllPathBytes = Encoding.ASCII.GetBytes(dllPath);
            IntPtr dllPathAddress = VirtualAllocEx(processHandle, IntPtr.Zero, (uint)dllPathBytes.Length, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            if (dllPathAddress == IntPtr.Zero)
            {
                MessageBox.Show("Unable to allocate memory in remote process", "Error");
                return;
            }

            UIntPtr bytesWritten;
            if (!WriteProcessMemory(processHandle, dllPathAddress, dllPathBytes, (uint)dllPathBytes.Length, out bytesWritten))
            {
                MessageBox.Show("Unable to write to remote process memory", "Error");
                return;
            }

            IntPtr threadHandle = CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibraryAddr, dllPathAddress, 0, IntPtr.Zero);
            if (threadHandle == IntPtr.Zero)
            {
                MessageBox.Show("Unable to create remote thread in target process", "Error");
                return;
            }

            MessageBox.Show("DLL injected successfully!", "Success");

            CloseHandle(processHandle);
            CloseHandle(threadHandle);
        }

        private void DllsPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDll = (string)DllsPath.SelectedItem;
            label3.Text = selectedDll;
            if (DllsPath.SelectedIndex != listBoxDlls.SelectedIndex)
            {
                listBoxDlls.SelectedIndex = DllsPath.SelectedIndex;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBoxDlls.Items.Clear();
            DllsPath.Items.Clear();
        }
    }
}