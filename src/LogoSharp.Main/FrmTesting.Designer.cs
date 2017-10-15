namespace LogoSharp.Main
{
    partial class FrmTesting
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpDirection = new System.Windows.Forms.GroupBox();
            this.numAngle = new System.Windows.Forms.NumericUpDown();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpMoving = new System.Windows.Forms.GroupBox();
            this.numSteps = new System.Windows.Forms.NumericUpDown();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpDirection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).BeginInit();
            this.grpMoving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlMain);
            this.splitContainer.Size = new System.Drawing.Size(966, 750);
            this.splitContainer.SplitterDistance = 244;
            this.splitContainer.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(244, 750);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpMoving);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.grpDirection);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(217, 742);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Turtle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(13, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(693, 726);
            this.pnlMain.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grpDirection
            // 
            this.grpDirection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDirection.Controls.Add(this.btnTurnRight);
            this.grpDirection.Controls.Add(this.btnTurnLeft);
            this.grpDirection.Controls.Add(this.numAngle);
            this.grpDirection.Location = new System.Drawing.Point(6, 37);
            this.grpDirection.Name = "grpDirection";
            this.grpDirection.Size = new System.Drawing.Size(205, 80);
            this.grpDirection.TabIndex = 4;
            this.grpDirection.TabStop = false;
            this.grpDirection.Text = "Direction";
            // 
            // numAngle
            // 
            this.numAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAngle.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAngle.Location = new System.Drawing.Point(6, 19);
            this.numAngle.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numAngle.Name = "numAngle";
            this.numAngle.Size = new System.Drawing.Size(193, 20);
            this.numAngle.TabIndex = 0;
            this.numAngle.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnTurnLeft
            // 
            this.btnTurnLeft.Location = new System.Drawing.Point(6, 45);
            this.btnTurnLeft.Name = "btnTurnLeft";
            this.btnTurnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnTurnLeft.TabIndex = 1;
            this.btnTurnLeft.Text = "Turn Left";
            this.btnTurnLeft.UseVisualStyleBackColor = true;
            this.btnTurnLeft.Click += new System.EventHandler(this.btnTurnLeft_Click);
            // 
            // btnTurnRight
            // 
            this.btnTurnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTurnRight.Location = new System.Drawing.Point(124, 45);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(75, 23);
            this.btnTurnRight.TabIndex = 2;
            this.btnTurnRight.Text = "Turn Right";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            this.btnTurnRight.Click += new System.EventHandler(this.btnTurnRight_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(6, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(205, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpMoving
            // 
            this.grpMoving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMoving.Controls.Add(this.btnBackward);
            this.grpMoving.Controls.Add(this.btnForward);
            this.grpMoving.Controls.Add(this.numSteps);
            this.grpMoving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMoving.Location = new System.Drawing.Point(6, 132);
            this.grpMoving.Name = "grpMoving";
            this.grpMoving.Size = new System.Drawing.Size(205, 100);
            this.grpMoving.TabIndex = 6;
            this.grpMoving.TabStop = false;
            this.grpMoving.Text = "Moving";
            // 
            // numSteps
            // 
            this.numSteps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSteps.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSteps.Location = new System.Drawing.Point(6, 19);
            this.numSteps.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numSteps.Name = "numSteps";
            this.numSteps.Size = new System.Drawing.Size(193, 20);
            this.numSteps.TabIndex = 0;
            this.numSteps.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(6, 45);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 1;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackward.Location = new System.Drawing.Point(124, 45);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(75, 23);
            this.btnBackward.TabIndex = 2;
            this.btnBackward.Text = "Backward";
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // FrmTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 750);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTesting";
            this.Text = "Testing Form";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grpDirection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).EndInit();
            this.grpMoving.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grpDirection;
        private System.Windows.Forms.NumericUpDown numAngle;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpMoving;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.NumericUpDown numSteps;
        private System.Windows.Forms.Button btnBackward;
    }
}

