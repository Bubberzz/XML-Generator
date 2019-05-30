namespace XML_Generator
{
    partial class XmlGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlGeneratorForm));
            this.TextBoxInput = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Load_Button = new System.Windows.Forms.Button();
            this.Create_button = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxInput
            // 
            this.TextBoxInput.Location = new System.Drawing.Point(135, 27);
            this.TextBoxInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBoxInput.Name = "TextBoxInput";
            this.TextBoxInput.Size = new System.Drawing.Size(216, 22);
            this.TextBoxInput.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(357, 26);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(83, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // labelFeedback
            // 
            this.labelFeedback.Location = new System.Drawing.Point(448, 32);
            this.labelFeedback.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(384, 25);
            this.labelFeedback.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 68);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1035, 377);
            this.dataGridView1.TabIndex = 4;
            // 
            // Load_Button
            // 
            this.Load_Button.Location = new System.Drawing.Point(840, 27);
            this.Load_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(100, 28);
            this.Load_Button.TabIndex = 5;
            this.Load_Button.Text = "Load";
            this.Load_Button.UseVisualStyleBackColor = true;
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // Create_button
            // 
            this.Create_button.Location = new System.Drawing.Point(948, 26);
            this.Create_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Create_button.Name = "Create_button";
            this.Create_button.Size = new System.Drawing.Size(100, 28);
            this.Create_button.TabIndex = 6;
            this.Create_button.Text = "Create";
            this.Create_button.UseVisualStyleBackColor = true;
            this.Create_button.Click += new System.EventHandler(this.Create_button_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(16, 30);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(113, 17);
            this.labelDescription.TabIndex = 8;
            this.labelDescription.Text = "Enter MDA here:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XML_Generator.Properties.Resources.ajax_loader;
            this.pictureBox1.InitialImage = global::XML_Generator.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(473, 191);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 127);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // XML_Generator_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1064, 457);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.Create_button);
            this.Controls.Add(this.Load_Button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TextBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "XmlGeneratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " XML Generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxInput;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.Button Load_Button;
        private System.Windows.Forms.Button Create_button;
        private System.Windows.Forms.Label labelDescription;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

