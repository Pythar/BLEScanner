namespace ScanReader
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
            this.portsButton = new System.Windows.Forms.Button();
            this.portSelectionBox = new System.Windows.Forms.ComboBox();
            this.baudRateCombo = new System.Windows.Forms.ComboBox();
            this.openComButton = new System.Windows.Forms.Button();
            this.dataTextBox = new System.Windows.Forms.RichTextBox();
            this.cleanTextBox = new System.Windows.Forms.Button();
            this.macAddressFilterButton = new System.Windows.Forms.Button();
            this.macAddressTextBox1 = new System.Windows.Forms.TextBox();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.macAddressTextBox2 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox3 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox4 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox5 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox6 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox7 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox8 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox9 = new System.Windows.Forms.TextBox();
            this.macAddressTextBox10 = new System.Windows.Forms.TextBox();
            this.closeComButton = new System.Windows.Forms.Button();
            this.dataBitCombo = new System.Windows.Forms.ComboBox();
            this.stopBitCombo = new System.Windows.Forms.ComboBox();
            this.signalStrengthFilterButton = new System.Windows.Forms.Button();
            this.signalStrengthTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // portsButton
            // 
            this.portsButton.Location = new System.Drawing.Point(18, 28);
            this.portsButton.Margin = new System.Windows.Forms.Padding(2);
            this.portsButton.Name = "portsButton";
            this.portsButton.Size = new System.Drawing.Size(92, 20);
            this.portsButton.TabIndex = 2;
            this.portsButton.Text = "Get Port Info";
            this.portsButton.UseVisualStyleBackColor = true;
            this.portsButton.Click += new System.EventHandler(this.portsButton_Click);
            // 
            // portSelectionBox
            // 
            this.portSelectionBox.FormattingEnabled = true;
            this.portSelectionBox.Location = new System.Drawing.Point(129, 29);
            this.portSelectionBox.Margin = new System.Windows.Forms.Padding(2);
            this.portSelectionBox.Name = "portSelectionBox";
            this.portSelectionBox.Size = new System.Drawing.Size(104, 21);
            this.portSelectionBox.TabIndex = 3;
            // 
            // baudRateCombo
            // 
            this.baudRateCombo.FormattingEnabled = true;
            this.baudRateCombo.Location = new System.Drawing.Point(129, 63);
            this.baudRateCombo.Margin = new System.Windows.Forms.Padding(2);
            this.baudRateCombo.Name = "baudRateCombo";
            this.baudRateCombo.Size = new System.Drawing.Size(104, 21);
            this.baudRateCombo.TabIndex = 4;
            // 
            // openComButton
            // 
            this.openComButton.Location = new System.Drawing.Point(18, 65);
            this.openComButton.Margin = new System.Windows.Forms.Padding(2);
            this.openComButton.Name = "openComButton";
            this.openComButton.Size = new System.Drawing.Size(92, 19);
            this.openComButton.TabIndex = 10;
            this.openComButton.Text = "Open";
            this.openComButton.UseVisualStyleBackColor = true;
            this.openComButton.Click += new System.EventHandler(this.openComButton_Click);
            // 
            // dataTextBox
            // 
            this.dataTextBox.Location = new System.Drawing.Point(18, 271);
            this.dataTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.Size = new System.Drawing.Size(637, 306);
            this.dataTextBox.TabIndex = 12;
            this.dataTextBox.Text = "";
            // 
            // cleanTextBox
            // 
            this.cleanTextBox.Location = new System.Drawing.Point(18, 143);
            this.cleanTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.cleanTextBox.Name = "cleanTextBox";
            this.cleanTextBox.Size = new System.Drawing.Size(92, 19);
            this.cleanTextBox.TabIndex = 13;
            this.cleanTextBox.Text = "Clear Textbox";
            this.cleanTextBox.UseVisualStyleBackColor = true;
            this.cleanTextBox.Click += new System.EventHandler(this.cleanTextBox_Click);
            // 
            // macAddressFilterButton
            // 
            this.macAddressFilterButton.Location = new System.Drawing.Point(273, 101);
            this.macAddressFilterButton.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressFilterButton.Name = "macAddressFilterButton";
            this.macAddressFilterButton.Size = new System.Drawing.Size(126, 20);
            this.macAddressFilterButton.TabIndex = 15;
            this.macAddressFilterButton.Text = "Filter MAC-Address\r\n";
            this.macAddressFilterButton.UseVisualStyleBackColor = true;
            this.macAddressFilterButton.Click += new System.EventHandler(this.macAddressFilterButton_Click);
            // 
            // macAddressTextBox1
            // 
            this.macAddressTextBox1.Location = new System.Drawing.Point(413, 29);
            this.macAddressTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox1.Name = "macAddressTextBox1";
            this.macAddressTextBox1.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox1.TabIndex = 16;
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(34, 598);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(96, 31);
            this.saveDataButton.TabIndex = 17;
            this.saveDataButton.Text = "Savet to file";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // macAddressTextBox2
            // 
            this.macAddressTextBox2.Location = new System.Drawing.Point(413, 64);
            this.macAddressTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox2.Name = "macAddressTextBox2";
            this.macAddressTextBox2.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox2.TabIndex = 19;
            // 
            // macAddressTextBox3
            // 
            this.macAddressTextBox3.Location = new System.Drawing.Point(413, 101);
            this.macAddressTextBox3.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox3.Name = "macAddressTextBox3";
            this.macAddressTextBox3.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox3.TabIndex = 21;
            // 
            // macAddressTextBox4
            // 
            this.macAddressTextBox4.Location = new System.Drawing.Point(413, 142);
            this.macAddressTextBox4.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox4.Name = "macAddressTextBox4";
            this.macAddressTextBox4.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox4.TabIndex = 23;
            // 
            // macAddressTextBox5
            // 
            this.macAddressTextBox5.Location = new System.Drawing.Point(413, 172);
            this.macAddressTextBox5.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox5.Name = "macAddressTextBox5";
            this.macAddressTextBox5.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox5.TabIndex = 24;
            // 
            // macAddressTextBox6
            // 
            this.macAddressTextBox6.Location = new System.Drawing.Point(547, 30);
            this.macAddressTextBox6.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox6.Name = "macAddressTextBox6";
            this.macAddressTextBox6.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox6.TabIndex = 25;
            // 
            // macAddressTextBox7
            // 
            this.macAddressTextBox7.Location = new System.Drawing.Point(547, 64);
            this.macAddressTextBox7.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox7.Name = "macAddressTextBox7";
            this.macAddressTextBox7.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox7.TabIndex = 26;
            // 
            // macAddressTextBox8
            // 
            this.macAddressTextBox8.Location = new System.Drawing.Point(547, 104);
            this.macAddressTextBox8.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox8.Name = "macAddressTextBox8";
            this.macAddressTextBox8.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox8.TabIndex = 27;
            // 
            // macAddressTextBox9
            // 
            this.macAddressTextBox9.Location = new System.Drawing.Point(547, 142);
            this.macAddressTextBox9.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox9.Name = "macAddressTextBox9";
            this.macAddressTextBox9.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox9.TabIndex = 28;
            // 
            // macAddressTextBox10
            // 
            this.macAddressTextBox10.Location = new System.Drawing.Point(547, 172);
            this.macAddressTextBox10.Margin = new System.Windows.Forms.Padding(2);
            this.macAddressTextBox10.Name = "macAddressTextBox10";
            this.macAddressTextBox10.Size = new System.Drawing.Size(108, 20);
            this.macAddressTextBox10.TabIndex = 29;
            // 
            // closeComButton
            // 
            this.closeComButton.Location = new System.Drawing.Point(18, 105);
            this.closeComButton.Margin = new System.Windows.Forms.Padding(2);
            this.closeComButton.Name = "closeComButton";
            this.closeComButton.Size = new System.Drawing.Size(92, 19);
            this.closeComButton.TabIndex = 30;
            this.closeComButton.Text = "Close";
            this.closeComButton.UseVisualStyleBackColor = true;
            this.closeComButton.Click += new System.EventHandler(this.closeComButton_Click);
            // 
            // dataBitCombo
            // 
            this.dataBitCombo.FormattingEnabled = true;
            this.dataBitCombo.Location = new System.Drawing.Point(129, 102);
            this.dataBitCombo.Margin = new System.Windows.Forms.Padding(2);
            this.dataBitCombo.Name = "dataBitCombo";
            this.dataBitCombo.Size = new System.Drawing.Size(104, 21);
            this.dataBitCombo.TabIndex = 5;
            // 
            // stopBitCombo
            // 
            this.stopBitCombo.FormattingEnabled = true;
            this.stopBitCombo.Location = new System.Drawing.Point(129, 140);
            this.stopBitCombo.Margin = new System.Windows.Forms.Padding(2);
            this.stopBitCombo.Name = "stopBitCombo";
            this.stopBitCombo.Size = new System.Drawing.Size(104, 21);
            this.stopBitCombo.TabIndex = 9;
            // 
            // signalStrengthFilterButton
            // 
            this.signalStrengthFilterButton.Location = new System.Drawing.Point(273, 228);
            this.signalStrengthFilterButton.Margin = new System.Windows.Forms.Padding(2);
            this.signalStrengthFilterButton.Name = "signalStrengthFilterButton";
            this.signalStrengthFilterButton.Size = new System.Drawing.Size(126, 20);
            this.signalStrengthFilterButton.TabIndex = 31;
            this.signalStrengthFilterButton.Text = "Filter Signal Strength";
            this.signalStrengthFilterButton.UseVisualStyleBackColor = true;
            this.signalStrengthFilterButton.Click += new System.EventHandler(this.signalStrengthFilterButton_Click);
            // 
            // signalStrengthTextBox
            // 
            this.signalStrengthTextBox.Location = new System.Drawing.Point(413, 228);
            this.signalStrengthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.signalStrengthTextBox.Name = "signalStrengthTextBox";
            this.signalStrengthTextBox.Size = new System.Drawing.Size(108, 20);
            this.signalStrengthTextBox.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 712);
            this.Controls.Add(this.signalStrengthTextBox);
            this.Controls.Add(this.signalStrengthFilterButton);
            this.Controls.Add(this.closeComButton);
            this.Controls.Add(this.macAddressTextBox10);
            this.Controls.Add(this.macAddressTextBox9);
            this.Controls.Add(this.macAddressTextBox8);
            this.Controls.Add(this.macAddressTextBox7);
            this.Controls.Add(this.macAddressTextBox6);
            this.Controls.Add(this.macAddressTextBox5);
            this.Controls.Add(this.macAddressTextBox4);
            this.Controls.Add(this.macAddressTextBox3);
            this.Controls.Add(this.macAddressTextBox2);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.macAddressTextBox1);
            this.Controls.Add(this.macAddressFilterButton);
            this.Controls.Add(this.cleanTextBox);
            this.Controls.Add(this.dataTextBox);
            this.Controls.Add(this.openComButton);
            this.Controls.Add(this.stopBitCombo);
            this.Controls.Add(this.dataBitCombo);
            this.Controls.Add(this.baudRateCombo);
            this.Controls.Add(this.portSelectionBox);
            this.Controls.Add(this.portsButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button portsButton;
        private System.Windows.Forms.ComboBox portSelectionBox;
        private System.Windows.Forms.ComboBox baudRateCombo;
        private System.Windows.Forms.Button openComButton;
        private System.Windows.Forms.RichTextBox dataTextBox;
        private System.Windows.Forms.Button cleanTextBox;
        private System.Windows.Forms.Button macAddressFilterButton;
        private System.Windows.Forms.TextBox macAddressTextBox1;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.TextBox macAddressTextBox2;
        private System.Windows.Forms.TextBox macAddressTextBox3;
        private System.Windows.Forms.TextBox macAddressTextBox4;
        private System.Windows.Forms.TextBox macAddressTextBox5;
        private System.Windows.Forms.TextBox macAddressTextBox6;
        private System.Windows.Forms.TextBox macAddressTextBox7;
        private System.Windows.Forms.TextBox macAddressTextBox8;
        private System.Windows.Forms.TextBox macAddressTextBox9;
        private System.Windows.Forms.TextBox macAddressTextBox10;
        private System.Windows.Forms.Button closeComButton;
        private System.Windows.Forms.ComboBox dataBitCombo;
        private System.Windows.Forms.ComboBox stopBitCombo;
        private System.Windows.Forms.Button signalStrengthFilterButton;
        private System.Windows.Forms.TextBox signalStrengthTextBox;
    }
}

