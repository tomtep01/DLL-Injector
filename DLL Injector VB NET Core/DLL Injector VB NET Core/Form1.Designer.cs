namespace DLL_Injector_VB_NET_Core
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxProcesses = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            labelProcessSelected = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            listBoxDlls = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            labelSelectedDll = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            DllsPath = new System.Windows.Forms.ListBox();
            label3 = new System.Windows.Forms.Label();
            button5 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // listBoxProcesses
            // 
            listBoxProcesses.FormattingEnabled = true;
            listBoxProcesses.ItemHeight = 15;
            listBoxProcesses.Location = new System.Drawing.Point(1, 31);
            listBoxProcesses.Name = "listBoxProcesses";
            listBoxProcesses.Size = new System.Drawing.Size(372, 244);
            listBoxProcesses.TabIndex = 0;
            listBoxProcesses.SelectedIndexChanged += listBoxProcesses_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(1, 278);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 21);
            label1.TabIndex = 1;
            label1.Text = "Process :";
            // 
            // labelProcessSelected
            // 
            labelProcessSelected.AutoSize = true;
            labelProcessSelected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelProcessSelected.Location = new System.Drawing.Point(68, 278);
            labelProcessSelected.Name = "labelProcessSelected";
            labelProcessSelected.Size = new System.Drawing.Size(123, 21);
            labelProcessSelected.TabIndex = 2;
            labelProcessSelected.Text = "Select a process.";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(1, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(235, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "Search";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(242, 5);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(131, 23);
            button1.TabIndex = 4;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(713, 5);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Add DLL";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBoxDlls
            // 
            listBoxDlls.FormattingEnabled = true;
            listBoxDlls.ItemHeight = 15;
            listBoxDlls.Location = new System.Drawing.Point(416, 31);
            listBoxDlls.Name = "listBoxDlls";
            listBoxDlls.Size = new System.Drawing.Size(385, 244);
            listBoxDlls.TabIndex = 6;
            listBoxDlls.SelectedIndexChanged += listBoxDlls_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(416, 278);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 21);
            label2.TabIndex = 7;
            label2.Text = "DLL :";
            // 
            // labelSelectedDll
            // 
            labelSelectedDll.AutoSize = true;
            labelSelectedDll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelSelectedDll.Location = new System.Drawing.Point(457, 278);
            labelSelectedDll.Name = "labelSelectedDll";
            labelSelectedDll.Size = new System.Drawing.Size(97, 21);
            labelSelectedDll.TabIndex = 8;
            labelSelectedDll.Text = "Select a DLL.";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(576, 5);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(131, 23);
            button3.TabIndex = 9;
            button3.Text = "Remove Selected DLL";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new System.Drawing.Font("Segoe UI", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button4.Location = new System.Drawing.Point(3, 305);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(798, 147);
            button4.TabIndex = 10;
            button4.Text = "Inject!";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // DllsPath
            // 
            DllsPath.FormattingEnabled = true;
            DllsPath.ItemHeight = 15;
            DllsPath.Location = new System.Drawing.Point(600, 31);
            DllsPath.Name = "DllsPath";
            DllsPath.Size = new System.Drawing.Size(201, 244);
            DllsPath.TabIndex = 11;
            DllsPath.Visible = false;
            DllsPath.SelectedIndexChanged += DllsPath_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(197, 278);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 21);
            label3.TabIndex = 12;
            label3.Text = "hey";
            label3.Visible = false;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(439, 5);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(131, 23);
            button5.TabIndex = 13;
            button5.Text = "Remove All DLLs";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(button5);
            Controls.Add(label3);
            Controls.Add(DllsPath);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(labelSelectedDll);
            Controls.Add(label2);
            Controls.Add(listBoxDlls);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(labelProcessSelected);
            Controls.Add(label1);
            Controls.Add(listBoxProcesses);
            Name = "Form1";
            Text = "DLL Injector";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProcesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProcessSelected;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBoxDlls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSelectedDll;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox DllsPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
    }
}
