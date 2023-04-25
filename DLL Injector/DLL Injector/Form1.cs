using System.Diagnostics;

namespace DLL_Injector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcesses())
            {
                string processInfo = string.Format("{0} ({1})",
                    process.ProcessName, process.Id);
                listBox1.Items.Add(processInfo);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When a process is selected, extract its name from the text
            string selectedText = listBox1.SelectedItem.ToString();
            int endIndex = selectedText.LastIndexOf(' ');
            string processName = selectedText.Substring(0, endIndex);

            // Display the process name in the text box
            label2.Text = processName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select a DLL file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files (*.dll)|*.dll";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Add the selected file name to the list box and list
                string dllName = Path.GetFileName(openFileDialog.FileName);
                listBox2.Items.Add(dllName);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDll = (string)listBox2.SelectedItem;
            label4.Text = selectedDll;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex >= 0)
            {
                listBox2.Items.RemoveAt(selectedIndex);
                label4.Text = "";
            }
        }
    }
}