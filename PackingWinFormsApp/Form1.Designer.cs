namespace PackingWinFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnGenNewRects = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.numUpDownCountRect = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBoxAboutRects = new System.Windows.Forms.RichTextBox();
			this.richTextBoxAboutEmployment = new System.Windows.Forms.RichTextBox();
			this.richTextBoxAboutUse = new System.Windows.Forms.RichTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdbBiLevelNextFit = new System.Windows.Forms.RadioButton();
			this.rdbBestFitDecreasingHigh = new System.Windows.Forms.RadioButton();
			this.rdbNextFitDecreasingHigh = new System.Windows.Forms.RadioButton();
			this.btnPacking = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDownCountRect)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(451, 28);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(660, 975);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// btnGenNewRects
			// 
			this.btnGenNewRects.BackColor = System.Drawing.Color.Red;
			this.btnGenNewRects.Location = new System.Drawing.Point(18, 390);
			this.btnGenNewRects.Name = "btnGenNewRects";
			this.btnGenNewRects.Size = new System.Drawing.Size(250, 43);
			this.btnGenNewRects.TabIndex = 1;
			this.btnGenNewRects.Text = "Генерировать новые элементы";
			this.btnGenNewRects.UseVisualStyleBackColor = false;
			this.btnGenNewRects.Click += new System.EventHandler(this.btnGenNewRects_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Количество прямоугольников";
			// 
			// numUpDownCountRect
			// 
			this.numUpDownCountRect.Location = new System.Drawing.Point(232, 38);
			this.numUpDownCountRect.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numUpDownCountRect.Name = "numUpDownCountRect";
			this.numUpDownCountRect.Size = new System.Drawing.Size(67, 27);
			this.numUpDownCountRect.TabIndex = 3;
			this.numUpDownCountRect.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numUpDownCountRect.ValueChanged += new System.EventHandler(this.numUpDownCountRect_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.numUpDownCountRect);
			this.groupBox1.Location = new System.Drawing.Point(18, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(313, 94);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Исходные данные";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// richTextBoxAboutRects
			// 
			this.richTextBoxAboutRects.Location = new System.Drawing.Point(18, 439);
			this.richTextBoxAboutRects.Name = "richTextBoxAboutRects";
			this.richTextBoxAboutRects.Size = new System.Drawing.Size(418, 564);
			this.richTextBoxAboutRects.TabIndex = 5;
			this.richTextBoxAboutRects.Text = "";
			// 
			// richTextBoxAboutEmployment
			// 
			this.richTextBoxAboutEmployment.Location = new System.Drawing.Point(18, 345);
			this.richTextBoxAboutEmployment.Name = "richTextBoxAboutEmployment";
			this.richTextBoxAboutEmployment.Size = new System.Drawing.Size(313, 39);
			this.richTextBoxAboutEmployment.TabIndex = 8;
			this.richTextBoxAboutEmployment.Text = "";
			// 
			// richTextBoxAboutUse
			// 
			this.richTextBoxAboutUse.Location = new System.Drawing.Point(18, 300);
			this.richTextBoxAboutUse.Name = "richTextBoxAboutUse";
			this.richTextBoxAboutUse.Size = new System.Drawing.Size(313, 39);
			this.richTextBoxAboutUse.TabIndex = 9;
			this.richTextBoxAboutUse.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdbBiLevelNextFit);
			this.groupBox2.Controls.Add(this.rdbBestFitDecreasingHigh);
			this.groupBox2.Controls.Add(this.rdbNextFitDecreasingHigh);
			this.groupBox2.Location = new System.Drawing.Point(18, 139);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(313, 155);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Алгоритмы";
			// 
			// rdbBiLevelNextFit
			// 
			this.rdbBiLevelNextFit.AutoSize = true;
			this.rdbBiLevelNextFit.Location = new System.Drawing.Point(11, 113);
			this.rdbBiLevelNextFit.Name = "rdbBiLevelNextFit";
			this.rdbBiLevelNextFit.Size = new System.Drawing.Size(142, 24);
			this.rdbBiLevelNextFit.TabIndex = 2;
			this.rdbBiLevelNextFit.Text = " Bi-Level Next Fit";
			this.rdbBiLevelNextFit.UseVisualStyleBackColor = true;
			this.rdbBiLevelNextFit.CheckedChanged += new System.EventHandler(this.rdbBiLevelNextFit_CheckedChanged);
			// 
			// rdbBestFitDecreasingHigh
			// 
			this.rdbBestFitDecreasingHigh.AutoSize = true;
			this.rdbBestFitDecreasingHigh.Location = new System.Drawing.Point(11, 74);
			this.rdbBestFitDecreasingHigh.Name = "rdbBestFitDecreasingHigh";
			this.rdbBestFitDecreasingHigh.Size = new System.Drawing.Size(192, 24);
			this.rdbBestFitDecreasingHigh.TabIndex = 1;
			this.rdbBestFitDecreasingHigh.Text = "Best Fit Decreasing High";
			this.rdbBestFitDecreasingHigh.UseVisualStyleBackColor = true;
			this.rdbBestFitDecreasingHigh.CheckedChanged += new System.EventHandler(this.rdbBestFitDecreasingHigh_CheckedChanged);
			// 
			// rdbNextFitDecreasingHigh
			// 
			this.rdbNextFitDecreasingHigh.AutoSize = true;
			this.rdbNextFitDecreasingHigh.Checked = true;
			this.rdbNextFitDecreasingHigh.Location = new System.Drawing.Point(11, 32);
			this.rdbNextFitDecreasingHigh.Name = "rdbNextFitDecreasingHigh";
			this.rdbNextFitDecreasingHigh.Size = new System.Drawing.Size(195, 24);
			this.rdbNextFitDecreasingHigh.TabIndex = 0;
			this.rdbNextFitDecreasingHigh.TabStop = true;
			this.rdbNextFitDecreasingHigh.Text = "Next Fit Decreasing High";
			this.rdbNextFitDecreasingHigh.UseVisualStyleBackColor = true;
			this.rdbNextFitDecreasingHigh.CheckedChanged += new System.EventHandler(this.rdbNextFitDecreasingHigh_CheckedChanged);
			// 
			// btnPacking
			// 
			this.btnPacking.BackColor = System.Drawing.Color.Red;
			this.btnPacking.Location = new System.Drawing.Point(268, 390);
			this.btnPacking.Name = "btnPacking";
			this.btnPacking.Size = new System.Drawing.Size(168, 43);
			this.btnPacking.TabIndex = 7;
			this.btnPacking.Text = "Выполнить упаковку";
			this.btnPacking.UseVisualStyleBackColor = false;
			this.btnPacking.Click += new System.EventHandler(this.btnPacking_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1124, 25);
			this.toolStrip1.TabIndex = 9;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1124, 1015);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.btnPacking);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnGenNewRects);
			this.Controls.Add(this.richTextBoxAboutRects);
			this.Controls.Add(this.richTextBoxAboutEmployment);
			this.Controls.Add(this.richTextBoxAboutUse);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Задача упаковки";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDownCountRect)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnGenNewRects;
        private Label label1;
        private NumericUpDown numUpDownCountRect;
        private GroupBox groupBox1;
        private RichTextBox richTextBoxAboutRects;
		private RichTextBox richTextBoxAboutEmployment;
		private RichTextBox richTextBoxAboutUse;
		private GroupBox groupBox2;
        private RadioButton rdbBiLevelNextFit;
        private RadioButton rdbBestFitDecreasingHigh;
        private RadioButton rdbNextFitDecreasingHigh;
        private Button btnPacking;
		private ToolStrip toolStrip1;
	}
}