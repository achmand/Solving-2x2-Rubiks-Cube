namespace CubeSolvingAssignment
{
    partial class MiniCubeSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniCubeSolver));
            this.grpBoxProcess = new System.Windows.Forms.GroupBox();
            this.scrambleBtn = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.grpBoxSolution = new System.Windows.Forms.GroupBox();
            this.btnRotateSolve = new System.Windows.Forms.Button();
            this.listBoxSolution = new System.Windows.Forms.ListBox();
            this.sqr4 = new System.Windows.Forms.Panel();
            this.sqr5 = new System.Windows.Forms.Panel();
            this.sqr7 = new System.Windows.Forms.Panel();
            this.sqr6 = new System.Windows.Forms.Panel();
            this.sqr8 = new System.Windows.Forms.Panel();
            this.sqr9 = new System.Windows.Forms.Panel();
            this.sqr11 = new System.Windows.Forms.Panel();
            this.sqr10 = new System.Windows.Forms.Panel();
            this.sqr0 = new System.Windows.Forms.Panel();
            this.sqr1 = new System.Windows.Forms.Panel();
            this.sqr3 = new System.Windows.Forms.Panel();
            this.sqr2 = new System.Windows.Forms.Panel();
            this.sqr16 = new System.Windows.Forms.Panel();
            this.sqr17 = new System.Windows.Forms.Panel();
            this.sqr20 = new System.Windows.Forms.Panel();
            this.sqr19 = new System.Windows.Forms.Panel();
            this.sqr12 = new System.Windows.Forms.Panel();
            this.sqr21 = new System.Windows.Forms.Panel();
            this.sqr18 = new System.Windows.Forms.Panel();
            this.sqr13 = new System.Windows.Forms.Panel();
            this.sqr23 = new System.Windows.Forms.Panel();
            this.sqr22 = new System.Windows.Forms.Panel();
            this.sqr15 = new System.Windows.Forms.Panel();
            this.sqr14 = new System.Windows.Forms.Panel();
            this.grpBoxCube = new System.Windows.Forms.GroupBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.cmbSide = new System.Windows.Forms.ComboBox();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.grpBoxInput = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.grpBoxProcess.SuspendLayout();
            this.grpBoxSolution.SuspendLayout();
            this.grpBoxCube.SuspendLayout();
            this.grpBoxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxProcess
            // 
            this.grpBoxProcess.Controls.Add(this.scrambleBtn);
            this.grpBoxProcess.Controls.Add(this.btnSolve);
            this.grpBoxProcess.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBoxProcess.Location = new System.Drawing.Point(0, 376);
            this.grpBoxProcess.Name = "grpBoxProcess";
            this.grpBoxProcess.Size = new System.Drawing.Size(260, 53);
            this.grpBoxProcess.TabIndex = 1;
            this.grpBoxProcess.TabStop = false;
            this.grpBoxProcess.Text = "Process";
            // 
            // scrambleBtn
            // 
            this.scrambleBtn.Location = new System.Drawing.Point(155, 19);
            this.scrambleBtn.Name = "scrambleBtn";
            this.scrambleBtn.Size = new System.Drawing.Size(75, 23);
            this.scrambleBtn.TabIndex = 2;
            this.scrambleBtn.Text = "Scramble";
            this.scrambleBtn.UseVisualStyleBackColor = true;
            this.scrambleBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(5, 19);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(144, 23);
            this.btnSolve.TabIndex = 0;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // grpBoxSolution
            // 
            this.grpBoxSolution.Controls.Add(this.btnRotateSolve);
            this.grpBoxSolution.Controls.Add(this.listBoxSolution);
            this.grpBoxSolution.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpBoxSolution.Location = new System.Drawing.Point(260, 24);
            this.grpBoxSolution.Name = "grpBoxSolution";
            this.grpBoxSolution.Size = new System.Drawing.Size(217, 405);
            this.grpBoxSolution.TabIndex = 2;
            this.grpBoxSolution.TabStop = false;
            this.grpBoxSolution.Text = "Solution";
            // 
            // btnRotateSolve
            // 
            this.btnRotateSolve.Location = new System.Drawing.Point(6, 234);
            this.btnRotateSolve.Name = "btnRotateSolve";
            this.btnRotateSolve.Size = new System.Drawing.Size(205, 23);
            this.btnRotateSolve.TabIndex = 0;
            this.btnRotateSolve.Text = "Rotate";
            this.btnRotateSolve.UseVisualStyleBackColor = true;
            this.btnRotateSolve.Click += new System.EventHandler(this.btnRotateSolve_Click);
            // 
            // listBoxSolution
            // 
            this.listBoxSolution.FormattingEnabled = true;
            this.listBoxSolution.Location = new System.Drawing.Point(6, 19);
            this.listBoxSolution.Name = "listBoxSolution";
            this.listBoxSolution.Size = new System.Drawing.Size(205, 199);
            this.listBoxSolution.TabIndex = 0;
            // 
            // sqr4
            // 
            this.sqr4.BackColor = System.Drawing.Color.Black;
            this.sqr4.Location = new System.Drawing.Point(63, 18);
            this.sqr4.Name = "sqr4";
            this.sqr4.Size = new System.Drawing.Size(15, 15);
            this.sqr4.TabIndex = 3;
            // 
            // sqr5
            // 
            this.sqr5.BackColor = System.Drawing.Color.Black;
            this.sqr5.Location = new System.Drawing.Point(84, 18);
            this.sqr5.Name = "sqr5";
            this.sqr5.Size = new System.Drawing.Size(15, 15);
            this.sqr5.TabIndex = 3;
            // 
            // sqr7
            // 
            this.sqr7.BackColor = System.Drawing.Color.Black;
            this.sqr7.Location = new System.Drawing.Point(84, 39);
            this.sqr7.Name = "sqr7";
            this.sqr7.Size = new System.Drawing.Size(15, 15);
            this.sqr7.TabIndex = 3;
            // 
            // sqr6
            // 
            this.sqr6.BackColor = System.Drawing.Color.Black;
            this.sqr6.Location = new System.Drawing.Point(63, 39);
            this.sqr6.Name = "sqr6";
            this.sqr6.Size = new System.Drawing.Size(15, 15);
            this.sqr6.TabIndex = 3;
            // 
            // sqr8
            // 
            this.sqr8.BackColor = System.Drawing.Color.Black;
            this.sqr8.Location = new System.Drawing.Point(63, 70);
            this.sqr8.Name = "sqr8";
            this.sqr8.Size = new System.Drawing.Size(15, 15);
            this.sqr8.TabIndex = 3;
            // 
            // sqr9
            // 
            this.sqr9.BackColor = System.Drawing.Color.Black;
            this.sqr9.Location = new System.Drawing.Point(84, 70);
            this.sqr9.Name = "sqr9";
            this.sqr9.Size = new System.Drawing.Size(15, 15);
            this.sqr9.TabIndex = 3;
            // 
            // sqr11
            // 
            this.sqr11.BackColor = System.Drawing.Color.Black;
            this.sqr11.Location = new System.Drawing.Point(84, 91);
            this.sqr11.Name = "sqr11";
            this.sqr11.Size = new System.Drawing.Size(15, 15);
            this.sqr11.TabIndex = 3;
            // 
            // sqr10
            // 
            this.sqr10.BackColor = System.Drawing.Color.Black;
            this.sqr10.Location = new System.Drawing.Point(63, 91);
            this.sqr10.Name = "sqr10";
            this.sqr10.Size = new System.Drawing.Size(15, 15);
            this.sqr10.TabIndex = 3;
            // 
            // sqr0
            // 
            this.sqr0.BackColor = System.Drawing.Color.Black;
            this.sqr0.Location = new System.Drawing.Point(13, 70);
            this.sqr0.Name = "sqr0";
            this.sqr0.Size = new System.Drawing.Size(15, 15);
            this.sqr0.TabIndex = 3;
            // 
            // sqr1
            // 
            this.sqr1.BackColor = System.Drawing.Color.Black;
            this.sqr1.Location = new System.Drawing.Point(34, 70);
            this.sqr1.Name = "sqr1";
            this.sqr1.Size = new System.Drawing.Size(15, 15);
            this.sqr1.TabIndex = 3;
            // 
            // sqr3
            // 
            this.sqr3.BackColor = System.Drawing.Color.Black;
            this.sqr3.Location = new System.Drawing.Point(34, 91);
            this.sqr3.Name = "sqr3";
            this.sqr3.Size = new System.Drawing.Size(15, 15);
            this.sqr3.TabIndex = 3;
            // 
            // sqr2
            // 
            this.sqr2.BackColor = System.Drawing.Color.Black;
            this.sqr2.Location = new System.Drawing.Point(13, 91);
            this.sqr2.Name = "sqr2";
            this.sqr2.Size = new System.Drawing.Size(15, 15);
            this.sqr2.TabIndex = 3;
            // 
            // sqr16
            // 
            this.sqr16.BackColor = System.Drawing.Color.Black;
            this.sqr16.Location = new System.Drawing.Point(117, 70);
            this.sqr16.Name = "sqr16";
            this.sqr16.Size = new System.Drawing.Size(15, 15);
            this.sqr16.TabIndex = 3;
            // 
            // sqr17
            // 
            this.sqr17.BackColor = System.Drawing.Color.Black;
            this.sqr17.Location = new System.Drawing.Point(138, 70);
            this.sqr17.Name = "sqr17";
            this.sqr17.Size = new System.Drawing.Size(15, 15);
            this.sqr17.TabIndex = 3;
            // 
            // sqr20
            // 
            this.sqr20.BackColor = System.Drawing.Color.Black;
            this.sqr20.Location = new System.Drawing.Point(173, 70);
            this.sqr20.Name = "sqr20";
            this.sqr20.Size = new System.Drawing.Size(15, 15);
            this.sqr20.TabIndex = 3;
            // 
            // sqr19
            // 
            this.sqr19.BackColor = System.Drawing.Color.Black;
            this.sqr19.Location = new System.Drawing.Point(138, 91);
            this.sqr19.Name = "sqr19";
            this.sqr19.Size = new System.Drawing.Size(15, 15);
            this.sqr19.TabIndex = 3;
            // 
            // sqr12
            // 
            this.sqr12.BackColor = System.Drawing.Color.Black;
            this.sqr12.Location = new System.Drawing.Point(63, 123);
            this.sqr12.Name = "sqr12";
            this.sqr12.Size = new System.Drawing.Size(15, 15);
            this.sqr12.TabIndex = 3;
            // 
            // sqr21
            // 
            this.sqr21.BackColor = System.Drawing.Color.Black;
            this.sqr21.Location = new System.Drawing.Point(194, 70);
            this.sqr21.Name = "sqr21";
            this.sqr21.Size = new System.Drawing.Size(15, 15);
            this.sqr21.TabIndex = 3;
            // 
            // sqr18
            // 
            this.sqr18.BackColor = System.Drawing.Color.Black;
            this.sqr18.Location = new System.Drawing.Point(117, 91);
            this.sqr18.Name = "sqr18";
            this.sqr18.Size = new System.Drawing.Size(15, 15);
            this.sqr18.TabIndex = 3;
            // 
            // sqr13
            // 
            this.sqr13.BackColor = System.Drawing.Color.Black;
            this.sqr13.Location = new System.Drawing.Point(84, 123);
            this.sqr13.Name = "sqr13";
            this.sqr13.Size = new System.Drawing.Size(15, 15);
            this.sqr13.TabIndex = 3;
            // 
            // sqr23
            // 
            this.sqr23.BackColor = System.Drawing.Color.Black;
            this.sqr23.Location = new System.Drawing.Point(194, 91);
            this.sqr23.Name = "sqr23";
            this.sqr23.Size = new System.Drawing.Size(15, 15);
            this.sqr23.TabIndex = 3;
            // 
            // sqr22
            // 
            this.sqr22.BackColor = System.Drawing.Color.Black;
            this.sqr22.Location = new System.Drawing.Point(173, 91);
            this.sqr22.Name = "sqr22";
            this.sqr22.Size = new System.Drawing.Size(15, 15);
            this.sqr22.TabIndex = 3;
            // 
            // sqr15
            // 
            this.sqr15.BackColor = System.Drawing.Color.Black;
            this.sqr15.Location = new System.Drawing.Point(84, 144);
            this.sqr15.Name = "sqr15";
            this.sqr15.Size = new System.Drawing.Size(15, 15);
            this.sqr15.TabIndex = 3;
            // 
            // sqr14
            // 
            this.sqr14.BackColor = System.Drawing.Color.Black;
            this.sqr14.Location = new System.Drawing.Point(63, 144);
            this.sqr14.Name = "sqr14";
            this.sqr14.Size = new System.Drawing.Size(15, 15);
            this.sqr14.TabIndex = 3;
            // 
            // grpBoxCube
            // 
            this.grpBoxCube.Controls.Add(this.sqr0);
            this.grpBoxCube.Controls.Add(this.sqr1);
            this.grpBoxCube.Controls.Add(this.sqr2);
            this.grpBoxCube.Controls.Add(this.sqr3);
            this.grpBoxCube.Controls.Add(this.sqr4);
            this.grpBoxCube.Controls.Add(this.sqr5);
            this.grpBoxCube.Controls.Add(this.sqr6);
            this.grpBoxCube.Controls.Add(this.sqr7);
            this.grpBoxCube.Controls.Add(this.sqr8);
            this.grpBoxCube.Controls.Add(this.sqr9);
            this.grpBoxCube.Controls.Add(this.sqr10);
            this.grpBoxCube.Controls.Add(this.sqr11);
            this.grpBoxCube.Controls.Add(this.sqr12);
            this.grpBoxCube.Controls.Add(this.sqr13);
            this.grpBoxCube.Controls.Add(this.sqr14);
            this.grpBoxCube.Controls.Add(this.sqr15);
            this.grpBoxCube.Controls.Add(this.sqr16);
            this.grpBoxCube.Controls.Add(this.sqr17);
            this.grpBoxCube.Controls.Add(this.sqr18);
            this.grpBoxCube.Controls.Add(this.sqr19);
            this.grpBoxCube.Controls.Add(this.sqr20);
            this.grpBoxCube.Controls.Add(this.sqr21);
            this.grpBoxCube.Controls.Add(this.sqr22);
            this.grpBoxCube.Controls.Add(this.sqr23);
            this.grpBoxCube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxCube.Location = new System.Drawing.Point(0, 24);
            this.grpBoxCube.Name = "grpBoxCube";
            this.grpBoxCube.Size = new System.Drawing.Size(260, 352);
            this.grpBoxCube.TabIndex = 4;
            this.grpBoxCube.TabStop = false;
            this.grpBoxCube.Text = "Cube";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(155, 19);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(155, 46);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(75, 23);
            this.btnRotate.TabIndex = 0;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // cmbSide
            // 
            this.cmbSide.FormattingEnabled = true;
            this.cmbSide.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Front",
            "Back",
            "Top",
            "Bottom"});
            this.cmbSide.Location = new System.Drawing.Point(5, 21);
            this.cmbSide.Name = "cmbSide";
            this.cmbSide.Size = new System.Drawing.Size(144, 21);
            this.cmbSide.TabIndex = 1;
            // 
            // cmbDirection
            // 
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "Clockwise",
            "Anticlockwise"});
            this.cmbDirection.Location = new System.Drawing.Point(5, 48);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(144, 21);
            this.cmbDirection.TabIndex = 1;
            // 
            // grpBoxInput
            // 
            this.grpBoxInput.Controls.Add(this.cmbDirection);
            this.grpBoxInput.Controls.Add(this.cmbSide);
            this.grpBoxInput.Controls.Add(this.btnRotate);
            this.grpBoxInput.Controls.Add(this.btnRestart);
            this.grpBoxInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBoxInput.Location = new System.Drawing.Point(0, 296);
            this.grpBoxInput.Name = "grpBoxInput";
            this.grpBoxInput.Size = new System.Drawing.Size(260, 80);
            this.grpBoxInput.TabIndex = 0;
            this.grpBoxInput.TabStop = false;
            this.grpBoxInput.Text = "Input";
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(477, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // MiniCubeSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 429);
            this.Controls.Add(this.grpBoxInput);
            this.Controls.Add(this.grpBoxCube);
            this.Controls.Add(this.grpBoxProcess);
            this.Controls.Add(this.grpBoxSolution);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MiniCubeSolver";
            this.Text = "Pocket Cube Solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.MiniCubeSolver_SizeChanged);
            this.grpBoxProcess.ResumeLayout(false);
            this.grpBoxSolution.ResumeLayout(false);
            this.grpBoxCube.ResumeLayout(false);
            this.grpBoxInput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBoxProcess;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.GroupBox grpBoxSolution;
        private System.Windows.Forms.Button btnRotateSolve;
        private System.Windows.Forms.ListBox listBoxSolution;
        private System.Windows.Forms.Panel sqr4;
        private System.Windows.Forms.Panel sqr5;
        private System.Windows.Forms.Panel sqr7;
        private System.Windows.Forms.Panel sqr6;
        private System.Windows.Forms.Panel sqr8;
        private System.Windows.Forms.Panel sqr9;
        private System.Windows.Forms.Panel sqr11;
        private System.Windows.Forms.Panel sqr10;
        private System.Windows.Forms.Panel sqr0;
        private System.Windows.Forms.Panel sqr1;
        private System.Windows.Forms.Panel sqr3;
        private System.Windows.Forms.Panel sqr2;
        private System.Windows.Forms.Panel sqr16;
        private System.Windows.Forms.Panel sqr17;
        private System.Windows.Forms.Panel sqr20;
        private System.Windows.Forms.Panel sqr19;
        private System.Windows.Forms.Panel sqr12;
        private System.Windows.Forms.Panel sqr21;
        private System.Windows.Forms.Panel sqr18;
        private System.Windows.Forms.Panel sqr13;
        private System.Windows.Forms.Panel sqr23;
        private System.Windows.Forms.Panel sqr22;
        private System.Windows.Forms.Panel sqr15;
        private System.Windows.Forms.Panel sqr14;
        private System.Windows.Forms.GroupBox grpBoxCube;
        private System.Windows.Forms.Button scrambleBtn;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.ComboBox cmbSide;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.GroupBox grpBoxInput;
        private System.Windows.Forms.MenuStrip menuStrip;
    }
}

