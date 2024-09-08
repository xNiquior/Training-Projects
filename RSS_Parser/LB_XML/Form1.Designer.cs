namespace RSS_Parser
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
            rssFullTextBox = new RichTextBox();
            linkTextBox = new TextBox();
            newsInfoTextBox = new RichTextBox();
            buttonFind = new Button();
            comboBox = new ComboBox();
            SuspendLayout();
            // 
            // rssFullTextBox
            // 
            rssFullTextBox.BackColor = SystemColors.InactiveCaptionText;
            rssFullTextBox.ForeColor = SystemColors.Window;
            rssFullTextBox.Location = new Point(61, 139);
            rssFullTextBox.Name = "rssFullTextBox";
            rssFullTextBox.ReadOnly = true;
            rssFullTextBox.Size = new Size(1140, 598);
            rssFullTextBox.TabIndex = 0;
            rssFullTextBox.Text = "";
            rssFullTextBox.TextChanged += rssFullTextBox_TextChanged;
            // 
            // linkTextBox
            // 
            linkTextBox.Location = new Point(61, 67);
            linkTextBox.Name = "linkTextBox";
            linkTextBox.PlaceholderText = "Введите ссылку на RSS-ленту или выберите одну заранее подготовленную в выпадающем списке справа";
            linkTextBox.Size = new Size(949, 31);
            linkTextBox.TabIndex = 1;
            linkTextBox.TextChanged += linkTextBox_TextChanged;
            // 
            // newsInfoTextBox
            // 
            newsInfoTextBox.Location = new Point(1243, 139);
            newsInfoTextBox.Name = "newsInfoTextBox";
            newsInfoTextBox.ReadOnly = true;
            newsInfoTextBox.Size = new Size(458, 598);
            newsInfoTextBox.TabIndex = 2;
            newsInfoTextBox.Text = "";
            newsInfoTextBox.TextChanged += newsInfoTextBox_TextChanged;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(1045, 65);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(112, 31);
            buttonFind.TabIndex = 3;
            buttonFind.Text = "Найти";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // comboBox
            // 
            comboBox.Location = new Point(1193, 63);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(288, 33);
            comboBox.TabIndex = 5;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1738, 762);
            Controls.Add(comboBox);
            Controls.Add(buttonFind);
            Controls.Add(newsInfoTextBox);
            Controls.Add(linkTextBox);
            Controls.Add(rssFullTextBox);
            Name = "Form1";
            Text = "RSS ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rssFullTextBox;
        private TextBox linkTextBox;
        private RichTextBox newsInfoTextBox;
        private Button buttonFind;
        private ComboBox comboBox;
    }
}
