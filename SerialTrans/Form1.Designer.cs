namespace SerialTrans
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
            this.comboBoxCom1 = new System.Windows.Forms.ComboBox();
            this.comboBoxCom2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSent = new System.Windows.Forms.TextBox();
            this.buttonOpenCom1 = new System.Windows.Forms.Button();
            this.buttonOpenCom2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate1 = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxCom1
            // 
            this.comboBoxCom1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom1.FormattingEnabled = true;
            this.comboBoxCom1.Location = new System.Drawing.Point(93, 12);
            this.comboBoxCom1.Name = "comboBoxCom1";
            this.comboBoxCom1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCom1.TabIndex = 0;
            this.comboBoxCom1.SelectedIndexChanged += new System.EventHandler(this.comboBoxCom1_SelectedIndexChanged);
            // 
            // comboBoxCom2
            // 
            this.comboBoxCom2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom2.FormattingEnabled = true;
            this.comboBoxCom2.Location = new System.Drawing.Point(267, 12);
            this.comboBoxCom2.Name = "comboBoxCom2";
            this.comboBoxCom2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCom2.TabIndex = 1;
            this.comboBoxCom2.SelectedIndexChanged += new System.EventHandler(this.comboBoxCom2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "----->";
            // 
            // textBoxSent
            // 
            this.textBoxSent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSent.Location = new System.Drawing.Point(12, 60);
            this.textBoxSent.Multiline = true;
            this.textBoxSent.Name = "textBoxSent";
            this.textBoxSent.ReadOnly = true;
            this.textBoxSent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSent.Size = new System.Drawing.Size(455, 218);
            this.textBoxSent.TabIndex = 3;
            // 
            // buttonOpenCom1
            // 
            this.buttonOpenCom1.Location = new System.Drawing.Point(12, 9);
            this.buttonOpenCom1.Name = "buttonOpenCom1";
            this.buttonOpenCom1.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenCom1.TabIndex = 4;
            this.buttonOpenCom1.Text = "Open";
            this.buttonOpenCom1.UseVisualStyleBackColor = true;
            this.buttonOpenCom1.Click += new System.EventHandler(this.buttonOpenCom1_Click);
            // 
            // buttonOpenCom2
            // 
            this.buttonOpenCom2.Location = new System.Drawing.Point(394, 9);
            this.buttonOpenCom2.Name = "buttonOpenCom2";
            this.buttonOpenCom2.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenCom2.TabIndex = 5;
            this.buttonOpenCom2.Text = "Open";
            this.buttonOpenCom2.UseVisualStyleBackColor = true;
            this.buttonOpenCom2.Click += new System.EventHandler(this.buttonOpenCom2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率";
            // 
            // comboBoxBaudRate1
            // 
            this.comboBoxBaudRate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate1.FormattingEnabled = true;
            this.comboBoxBaudRate1.Location = new System.Drawing.Point(93, 38);
            this.comboBoxBaudRate1.Name = "comboBoxBaudRate1";
            this.comboBoxBaudRate1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudRate1.TabIndex = 7;
            // 
            // comboBoxBaudRate2
            // 
            this.comboBoxBaudRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate2.FormattingEnabled = true;
            this.comboBoxBaudRate2.Location = new System.Drawing.Point(267, 38);
            this.comboBoxBaudRate2.Name = "comboBoxBaudRate2";
            this.comboBoxBaudRate2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudRate2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 290);
            this.Controls.Add(this.comboBoxBaudRate2);
            this.Controls.Add(this.comboBoxBaudRate1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOpenCom2);
            this.Controls.Add(this.buttonOpenCom1);
            this.Controls.Add(this.textBoxSent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCom2);
            this.Controls.Add(this.comboBoxCom1);
            this.Name = "Form1";
            this.Text = "串口转发";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCom1;
        private System.Windows.Forms.ComboBox comboBoxCom2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSent;
        private System.Windows.Forms.Button buttonOpenCom1;
        private System.Windows.Forms.Button buttonOpenCom2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBaudRate1;
        private System.Windows.Forms.ComboBox comboBoxBaudRate2;
    }
}

