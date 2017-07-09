﻿namespace FPGA_FullDuplexCom
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusLed = new NationalInstruments.UI.WindowsForms.Led();
            this.btn_send = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.Reciever = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.randomeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshFTDIDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.NuberOFFTDIDevieces = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.statusLed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLed
            // 
            this.statusLed.Location = new System.Drawing.Point(560, 439);
            this.statusLed.Name = "statusLed";
            this.statusLed.OffColor = System.Drawing.Color.Red;
            this.statusLed.Size = new System.Drawing.Size(28, 29);
            this.statusLed.TabIndex = 0;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(12, 445);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkGray;
            this.textBox1.Location = new System.Drawing.Point(12, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 169);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Send";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 244);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(561, 142);
            this.textBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Recieved";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(12, 409);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 7;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // Reciever
            // 
            this.Reciever.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Reciever_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomeGeneratorToolStripMenuItem,
            this.RefreshFTDIDevicesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // randomeGeneratorToolStripMenuItem
            // 
            this.randomeGeneratorToolStripMenuItem.Name = "randomeGeneratorToolStripMenuItem";
            this.randomeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.randomeGeneratorToolStripMenuItem.Text = "Randome Generator";
            this.randomeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.randomeGeneratorToolStripMenuItem_Click);
            // 
            // RefreshFTDIDevicesToolStripMenuItem
            // 
            this.RefreshFTDIDevicesToolStripMenuItem.Name = "RefreshFTDIDevicesToolStripMenuItem";
            this.RefreshFTDIDevicesToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.RefreshFTDIDevicesToolStripMenuItem.Text = "Refresh FTDI Devices";
            this.RefreshFTDIDevicesToolStripMenuItem.Click += new System.EventHandler(this.refreshFTDIDevicesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuberOFFTDIDevieces});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(588, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // NuberOFFTDIDevieces
            // 
            this.NuberOFFTDIDevieces.Name = "NuberOFFTDIDevieces";
            this.NuberOFFTDIDevieces.Size = new System.Drawing.Size(128, 17);
            this.NuberOFFTDIDevieces.Text = "number of FT Devices :";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(588, 493);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.statusLed);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FPGA_FDC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusLed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Led statusLed;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_connect;
        private System.ComponentModel.BackgroundWorker Reciever;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem randomeGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshFTDIDevicesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel NuberOFFTDIDevieces;
    }
}

