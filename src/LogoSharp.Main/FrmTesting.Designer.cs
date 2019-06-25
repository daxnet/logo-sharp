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
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.grpMoving = new System.Windows.Forms.GroupBox();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.numSteps = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpDirection = new System.Windows.Forms.GroupBox();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.numAngle = new System.Windows.Forms.NumericUpDown();
            this.tpDrawing = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnPenDown = new System.Windows.Forms.Button();
            this.btnPenUp = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tpProgram = new System.Windows.Forms.TabPage();
            this.txtError = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpMoving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).BeginInit();
            this.grpDirection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).BeginInit();
            this.tpDrawing.SuspendLayout();
            this.tpProgram.SuspendLayout();
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
            this.splitContainer.Size = new System.Drawing.Size(1116, 689);
            this.splitContainer.SplitterDistance = 434;
            this.splitContainer.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tpDrawing);
            this.tabControl.Controls.Add(this.tpProgram);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(434, 689);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnHide);
            this.tabPage2.Controls.Add(this.btnShow);
            this.tabPage2.Controls.Add(this.grpMoving);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.grpDirection);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 681);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Turtle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.Location = new System.Drawing.Point(326, 37);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 8;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(6, 37);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // grpMoving
            // 
            this.grpMoving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMoving.Controls.Add(this.btnBackward);
            this.grpMoving.Controls.Add(this.btnForward);
            this.grpMoving.Controls.Add(this.numSteps);
            this.grpMoving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMoving.Location = new System.Drawing.Point(6, 152);
            this.grpMoving.Name = "grpMoving";
            this.grpMoving.Size = new System.Drawing.Size(395, 100);
            this.grpMoving.TabIndex = 6;
            this.grpMoving.TabStop = false;
            this.grpMoving.Text = "Moving";
            // 
            // btnBackward
            // 
            this.btnBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackward.Location = new System.Drawing.Point(314, 45);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(75, 23);
            this.btnBackward.TabIndex = 2;
            this.btnBackward.Text = "Backward";
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
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
            this.numSteps.Size = new System.Drawing.Size(383, 20);
            this.numSteps.TabIndex = 0;
            this.numSteps.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(6, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(395, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpDirection
            // 
            this.grpDirection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDirection.Controls.Add(this.btnTurnRight);
            this.grpDirection.Controls.Add(this.btnTurnLeft);
            this.grpDirection.Controls.Add(this.numAngle);
            this.grpDirection.Location = new System.Drawing.Point(6, 66);
            this.grpDirection.Name = "grpDirection";
            this.grpDirection.Size = new System.Drawing.Size(395, 80);
            this.grpDirection.TabIndex = 4;
            this.grpDirection.TabStop = false;
            this.grpDirection.Text = "Direction";
            // 
            // btnTurnRight
            // 
            this.btnTurnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTurnRight.Location = new System.Drawing.Point(314, 45);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(75, 23);
            this.btnTurnRight.TabIndex = 2;
            this.btnTurnRight.Text = "Turn Right";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            this.btnTurnRight.Click += new System.EventHandler(this.btnTurnRight_Click);
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
            this.numAngle.Size = new System.Drawing.Size(383, 20);
            this.numAngle.TabIndex = 0;
            this.numAngle.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // tpDrawing
            // 
            this.tpDrawing.Controls.Add(this.btnSave);
            this.tpDrawing.Controls.Add(this.btnChoose);
            this.tpDrawing.Controls.Add(this.label1);
            this.tpDrawing.Controls.Add(this.lblColor);
            this.tpDrawing.Controls.Add(this.btnPenDown);
            this.tpDrawing.Controls.Add(this.btnPenUp);
            this.tpDrawing.Controls.Add(this.btnClear);
            this.tpDrawing.Location = new System.Drawing.Point(23, 4);
            this.tpDrawing.Name = "tpDrawing";
            this.tpDrawing.Padding = new System.Windows.Forms.Padding(3);
            this.tpDrawing.Size = new System.Drawing.Size(217, 681);
            this.tpDrawing.TabIndex = 2;
            this.tpDrawing.Text = "Drawing";
            this.tpDrawing.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(9, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(202, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save Image...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(90, 79);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 5;
            this.btnChoose.Text = "Choose...";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pen Color:";
            // 
            // lblColor
            // 
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor.Location = new System.Drawing.Point(68, 83);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(16, 16);
            this.lblColor.TabIndex = 3;
            // 
            // btnPenDown
            // 
            this.btnPenDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPenDown.Location = new System.Drawing.Point(136, 37);
            this.btnPenDown.Name = "btnPenDown";
            this.btnPenDown.Size = new System.Drawing.Size(75, 23);
            this.btnPenDown.TabIndex = 2;
            this.btnPenDown.Text = "Pen Down";
            this.btnPenDown.UseVisualStyleBackColor = true;
            this.btnPenDown.Click += new System.EventHandler(this.btnPenDown_Click);
            // 
            // btnPenUp
            // 
            this.btnPenUp.Location = new System.Drawing.Point(6, 37);
            this.btnPenUp.Name = "btnPenUp";
            this.btnPenUp.Size = new System.Drawing.Size(75, 23);
            this.btnPenUp.TabIndex = 1;
            this.btnPenUp.Text = "Pen Up";
            this.btnPenUp.UseVisualStyleBackColor = true;
            this.btnPenUp.Click += new System.EventHandler(this.btnPenUp_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(6, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(205, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear...";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tpProgram
            // 
            this.tpProgram.Controls.Add(this.txtError);
            this.tpProgram.Controls.Add(this.btnExecute);
            this.tpProgram.Controls.Add(this.txtSourceCode);
            this.tpProgram.Location = new System.Drawing.Point(23, 4);
            this.tpProgram.Name = "tpProgram";
            this.tpProgram.Padding = new System.Windows.Forms.Padding(3);
            this.tpProgram.Size = new System.Drawing.Size(217, 681);
            this.tpProgram.TabIndex = 3;
            this.tpProgram.Text = "Program";
            this.tpProgram.UseVisualStyleBackColor = true;
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Location = new System.Drawing.Point(6, 502);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtError.Size = new System.Drawing.Size(205, 171);
            this.txtError.TabIndex = 2;
            this.txtError.WordWrap = false;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(136, 474);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.AcceptsReturn = true;
            this.txtSourceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceCode.Location = new System.Drawing.Point(6, 8);
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceCode.Size = new System.Drawing.Size(205, 460);
            this.txtSourceCode.TabIndex = 0;
            this.txtSourceCode.Text = "REPEAT 5[FD 100 RT 144]\r\n\r\n";
            this.txtSourceCode.WordWrap = false;
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
            this.pnlMain.Size = new System.Drawing.Size(653, 665);
            this.pnlMain.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "PNG Files (*.png)|*.png";
            this.saveFileDialog1.Title = "Save the current drawing";
            // 
            // FrmTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 689);
            this.Controls.Add(this.splitContainer);
            this.Name = "FrmTesting";
            this.Text = "Testing Form";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grpMoving.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).EndInit();
            this.grpDirection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).EndInit();
            this.tpDrawing.ResumeLayout(false);
            this.tpDrawing.PerformLayout();
            this.tpProgram.ResumeLayout(false);
            this.tpProgram.PerformLayout();
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
        private System.Windows.Forms.TabPage tpDrawing;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPenDown;
        private System.Windows.Forms.Button btnPenUp;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabPage tpProgram;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

