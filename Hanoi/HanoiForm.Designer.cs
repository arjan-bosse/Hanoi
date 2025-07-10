namespace Hanoi
{
    partial class HanoiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HanoiForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pegsLabel = new System.Windows.Forms.ToolStripLabel();
            this.pegsToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.discsLabel = new System.Windows.Forms.ToolStripLabel();
            this.discsToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.analyseButton = new System.Windows.Forms.ToolStripButton();
            this.countToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(821, 432);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pegsLabel,
            this.pegsToolStripComboBox,
            this.discsLabel,
            this.discsToolStripComboBox,
            this.startButton,
            this.stopButton,
            this.analyseButton,
            this.countToolStripTextBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(845, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pegsLabel
            // 
            this.pegsLabel.Name = "pegsLabel";
            this.pegsLabel.Size = new System.Drawing.Size(32, 22);
            this.pegsLabel.Text = "Pegs";
            // 
            // pegsToolStripComboBox
            // 
            this.pegsToolStripComboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.pegsToolStripComboBox.Name = "pegsToolStripComboBox";
            this.pegsToolStripComboBox.Size = new System.Drawing.Size(75, 25);
            // 
            // discsLabel
            // 
            this.discsLabel.Name = "discsLabel";
            this.discsLabel.Size = new System.Drawing.Size(34, 22);
            this.discsLabel.Text = "Discs";
            // 
            // discsToolStripComboBox
            // 
            this.discsToolStripComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.discsToolStripComboBox.Name = "discsToolStripComboBox";
            this.discsToolStripComboBox.Size = new System.Drawing.Size(75, 25);
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(23, 22);
            this.startButton.Text = "startButton";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 22);
            this.stopButton.Text = "stopButton";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // analyseButton
            // 
            this.analyseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.analyseButton.Image = ((System.Drawing.Image)(resources.GetObject("analyseButton.Image")));
            this.analyseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.analyseButton.Name = "analyseButton";
            this.analyseButton.Size = new System.Drawing.Size(23, 22);
            this.analyseButton.Text = "analyseButton";
            this.analyseButton.Click += new System.EventHandler(this.analyseButton_Click);
            // 
            // countToolStripTextBox
            // 
            this.countToolStripTextBox.Name = "countToolStripTextBox";
            this.countToolStripTextBox.Size = new System.Drawing.Size(500, 25);
            // 
            // HanoiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 482);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HanoiForm";
            this.Text = "Hanoi";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripComboBox pegsToolStripComboBox;
        private System.Windows.Forms.ToolStripLabel pegsLabel;
        private System.Windows.Forms.ToolStripLabel discsLabel;
        private System.Windows.Forms.ToolStripComboBox discsToolStripComboBox;
        private System.Windows.Forms.ToolStripTextBox countToolStripTextBox;
        private System.Windows.Forms.ToolStripButton analyseButton;
    }
}

