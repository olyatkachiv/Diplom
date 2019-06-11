namespace FindPath
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
            this.button_generateBlocks = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_findPath = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.numericUpDown_width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_height = new System.Windows.Forms.NumericUpDown();
            this.label_height = new System.Windows.Forms.Label();
            this.label_width = new System.Windows.Forms.Label();
            this.label_probability = new System.Windows.Forms.Label();
            this.numericUpDown_probability = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_probability)).BeginInit();
            this.SuspendLayout();
            // 
            // button_generateBlocks
            // 
            this.button_generateBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_generateBlocks.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_generateBlocks.Location = new System.Drawing.Point(5, 330);
            this.button_generateBlocks.Name = "button_generateBlocks";
            this.button_generateBlocks.Size = new System.Drawing.Size(209, 41);
            this.button_generateBlocks.TabIndex = 0;
            this.button_generateBlocks.Text = "Згенерувати блоки";
            this.button_generateBlocks.UseVisualStyleBackColor = true;
            this.button_generateBlocks.Click += new System.EventHandler(this.button_generateBlocks_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(5, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(492, 268);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // button_findPath
            // 
            this.button_findPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_findPath.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_findPath.Location = new System.Drawing.Point(216, 330);
            this.button_findPath.Name = "button_findPath";
            this.button_findPath.Size = new System.Drawing.Size(281, 41);
            this.button_findPath.TabIndex = 6;
            this.button_findPath.Text = "Знайти шлях";
            this.button_findPath.UseVisualStyleBackColor = true;
            this.button_findPath.Click += new System.EventHandler(this.button_findPath_Click);
            // 
            // button_clear
            // 
            this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_clear.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_clear.Location = new System.Drawing.Point(401, 8);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(99, 42);
            this.button_clear.TabIndex = 7;
            this.button_clear.Text = "Очистити";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // numericUpDown_width
            // 
            this.numericUpDown_width.Location = new System.Drawing.Point(113, 30);
            this.numericUpDown_width.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_width.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_width.Name = "numericUpDown_width";
            this.numericUpDown_width.Size = new System.Drawing.Size(117, 20);
            this.numericUpDown_width.TabIndex = 8;
            this.numericUpDown_width.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numericUpDown_height
            // 
            this.numericUpDown_height.Location = new System.Drawing.Point(6, 30);
            this.numericUpDown_height.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_height.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_height.Name = "numericUpDown_height";
            this.numericUpDown_height.Size = new System.Drawing.Size(101, 20);
            this.numericUpDown_height.TabIndex = 9;
            this.numericUpDown_height.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_height.Location = new System.Drawing.Point(6, 9);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(64, 18);
            this.label_height.TabIndex = 10;
            this.label_height.Text = "Висота:";
            // 
            // label_width
            // 
            this.label_width.AutoSize = true;
            this.label_width.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_width.Location = new System.Drawing.Point(110, 9);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(64, 18);
            this.label_width.TabIndex = 11;
            this.label_width.Text = "Ширина:";
            // 
            // label_probability
            // 
            this.label_probability.AutoSize = true;
            this.label_probability.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_probability.Location = new System.Drawing.Point(233, 9);
            this.label_probability.Name = "label_probability";
            this.label_probability.Size = new System.Drawing.Size(144, 18);
            this.label_probability.TabIndex = 12;
            this.label_probability.Text = "Густота перешкод:";
            // 
            // numericUpDown_probability
            // 
            this.numericUpDown_probability.DecimalPlaces = 3;
            this.numericUpDown_probability.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_probability.Location = new System.Drawing.Point(236, 30);
            this.numericUpDown_probability.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_probability.Name = "numericUpDown_probability";
            this.numericUpDown_probability.Size = new System.Drawing.Size(159, 20);
            this.numericUpDown_probability.TabIndex = 13;
            this.numericUpDown_probability.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(504, 378);
            this.Controls.Add(this.numericUpDown_probability);
            this.Controls.Add(this.label_probability);
            this.Controls.Add(this.label_width);
            this.Controls.Add(this.label_height);
            this.Controls.Add(this.numericUpDown_height);
            this.Controls.Add(this.numericUpDown_width);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_findPath);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_generateBlocks);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(520, 416);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пошук шляху";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_probability)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_generateBlocks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_findPath;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.NumericUpDown numericUpDown_width;
        private System.Windows.Forms.NumericUpDown numericUpDown_height;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.Label label_probability;
        private System.Windows.Forms.NumericUpDown numericUpDown_probability;
    }
}

