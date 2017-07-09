namespace FPGA_FullDuplexCom
{
    partial class randomeGeneratorForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_connectTosecUsb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_connectTosecUsb
            // 
            this.btn_connectTosecUsb.Location = new System.Drawing.Point(36, 357);
            this.btn_connectTosecUsb.Name = "btn_connectTosecUsb";
            this.btn_connectTosecUsb.Size = new System.Drawing.Size(75, 23);
            this.btn_connectTosecUsb.TabIndex = 0;
            this.btn_connectTosecUsb.Text = "connect";
            this.btn_connectTosecUsb.UseVisualStyleBackColor = true;
            // 
            // randomeGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 411);
            this.Controls.Add(this.btn_connectTosecUsb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "randomeGeneratorForm";
            this.Text = "randomeGeneratorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_connectTosecUsb;
    }
}