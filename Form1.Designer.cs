namespace Race
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            myBolid = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripProgressBar2 = new ToolStripProgressBar();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            timer2 = new System.Windows.Forms.Timer(components);
            finish = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)myBolid).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)finish).BeginInit();
            SuspendLayout();
            // 
            // myBolid
            // 
            myBolid.BackColor = Color.Transparent;
            myBolid.BackgroundImage = Properties.Resources.f1car;
            myBolid.Image = Properties.Resources.f1car;
            myBolid.Location = new Point(284, 608);
            myBolid.Name = "myBolid";
            myBolid.Size = new Size(31, 75);
            myBolid.TabIndex = 0;
            myBolid.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 25;
            timer1.Tick += timer1_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1, toolStripStatusLabel2, toolStripProgressBar2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 727);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(584, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.BackColor = Color.Yellow;
            toolStripProgressBar1.ForeColor = Color.Blue;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(137, 17);
            toolStripStatusLabel2.Text = "race time: 0:30 second(s)";
            // 
            // toolStripProgressBar2
            // 
            toolStripProgressBar2.Name = "toolStripProgressBar2";
            toolStripProgressBar2.Size = new Size(100, 16);
            toolStripProgressBar2.Value = 100;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(94, 17);
            toolStripStatusLabel3.Text = "  speed: 20 km/h";
            // 
            // timer2
            // 
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            // 
            // finish
            // 
            finish.Image = Properties.Resources.finish;
            finish.InitialImage = null;
            finish.Location = new Point(128, -57);
            finish.Name = "finish";
            finish.Size = new Size(344, 57);
            finish.TabIndex = 9;
            finish.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 749);
            Controls.Add(finish);
            Controls.Add(statusStrip1);
            Controls.Add(myBolid);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(2500, 50);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Race - Grand Prix of Ukraine";
            KeyDown += Form1_KeyDown;
            PreviewKeyDown += Form1_PreviewKeyDown;
            ((System.ComponentModel.ISupportInitialize)myBolid).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)finish).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal PictureBox myBolid;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Timer timer2;
        internal StatusStrip statusStrip1;
        internal ToolStripStatusLabel toolStripStatusLabel1;
        internal ToolStripProgressBar toolStripProgressBar1;

        private ToolStripStatusLabel toolStripStatusLabel2;
        internal ToolStripProgressBar toolStripProgressBar2;
        internal PictureBox finish;
        private ToolStripStatusLabel toolStripStatusLabel3;
    }
}