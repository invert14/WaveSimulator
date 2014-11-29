namespace WaveSimulator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.dtTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.cdtTextBox = new System.Windows.Forms.TextBox();
            this.cdxTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dxTextBox = new System.Windows.Forms.TextBox();
            this.cStopTimeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopTimeTextBox = new System.Windows.Forms.TextBox();
            this.currentSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 288);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Play/Pause";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(402, 257);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(390, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(548, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtTextBox
            // 
            this.dtTextBox.Location = new System.Drawing.Point(501, 56);
            this.dtTextBox.Name = "dtTextBox";
            this.dtTextBox.Size = new System.Drawing.Size(60, 20);
            this.dtTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time step";
            // 
            // updateButton
            // 
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.updateButton.Location = new System.Drawing.Point(445, 205);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(78, 46);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update values";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cdtTextBox
            // 
            this.cdtTextBox.Enabled = false;
            this.cdtTextBox.Location = new System.Drawing.Point(572, 56);
            this.cdtTextBox.Name = "cdtTextBox";
            this.cdtTextBox.Size = new System.Drawing.Size(60, 20);
            this.cdtTextBox.TabIndex = 7;
            // 
            // cdxTextBox
            // 
            this.cdxTextBox.Enabled = false;
            this.cdxTextBox.Location = new System.Drawing.Point(572, 82);
            this.cdxTextBox.Name = "cdxTextBox";
            this.cdxTextBox.Size = new System.Drawing.Size(60, 20);
            this.cdxTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Spacial step";
            // 
            // dxTextBox
            // 
            this.dxTextBox.Location = new System.Drawing.Point(501, 82);
            this.dxTextBox.Name = "dxTextBox";
            this.dxTextBox.Size = new System.Drawing.Size(60, 20);
            this.dxTextBox.TabIndex = 8;
            // 
            // cStopTimeTextBox
            // 
            this.cStopTimeTextBox.Enabled = false;
            this.cStopTimeTextBox.Location = new System.Drawing.Point(572, 108);
            this.cStopTimeTextBox.Name = "cStopTimeTextBox";
            this.cStopTimeTextBox.Size = new System.Drawing.Size(60, 20);
            this.cStopTimeTextBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Stop time";
            // 
            // stopTimeTextBox
            // 
            this.stopTimeTextBox.Location = new System.Drawing.Point(501, 108);
            this.stopTimeTextBox.Name = "stopTimeTextBox";
            this.stopTimeTextBox.Size = new System.Drawing.Size(60, 20);
            this.stopTimeTextBox.TabIndex = 11;
            // 
            // currentSpeedTextBox
            // 
            this.currentSpeedTextBox.Enabled = false;
            this.currentSpeedTextBox.Location = new System.Drawing.Point(572, 134);
            this.currentSpeedTextBox.Name = "currentSpeedTextBox";
            this.currentSpeedTextBox.Size = new System.Drawing.Size(60, 20);
            this.currentSpeedTextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Propagation speed";
            // 
            // speedTextBox
            // 
            this.speedTextBox.Location = new System.Drawing.Point(501, 134);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(60, 20);
            this.speedTextBox.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 315);
            this.Controls.Add(this.currentSpeedTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.speedTextBox);
            this.Controls.Add(this.cStopTimeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopTimeTextBox);
            this.Controls.Add(this.cdxTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dxTextBox);
            this.Controls.Add(this.cdtTextBox);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox dtTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox cdtTextBox;
        private System.Windows.Forms.TextBox cdxTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dxTextBox;
        private System.Windows.Forms.TextBox cStopTimeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stopTimeTextBox;
        private System.Windows.Forms.TextBox currentSpeedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox speedTextBox;
    }
}

