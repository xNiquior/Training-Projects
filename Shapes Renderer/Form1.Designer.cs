namespace LB_7
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
            Create = new Button();
            Save = new Button();
            Download = new Button();
            Check = new Label();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Location = new Point(17, 20);
            Create.Margin = new Padding(4, 5, 4, 5);
            Create.Name = "Create";
            Create.Size = new Size(107, 38);
            Create.TabIndex = 0;
            Create.Text = "Создать";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Save
            // 
            Save.Location = new Point(133, 20);
            Save.Margin = new Padding(4, 5, 4, 5);
            Save.Name = "Save";
            Save.Size = new Size(107, 38);
            Save.TabIndex = 1;
            Save.Text = "Сохранить";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Download
            // 
            Download.Location = new Point(249, 20);
            Download.Margin = new Padding(4, 5, 4, 5);
            Download.Name = "Download";
            Download.Size = new Size(107, 38);
            Download.TabIndex = 2;
            Download.Text = "Загрузить";
            Download.UseVisualStyleBackColor = true;
            Download.Click += Download_Click;
            // 
            // Check
            // 
            Check.AutoSize = true;
            Check.Location = new Point(17, 63);
            Check.Margin = new Padding(4, 0, 4, 0);
            Check.Name = "Check";
            Check.Size = new Size(0, 25);
            Check.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 1044);
            Controls.Add(Check);
            Controls.Add(Download);
            Controls.Add(Save);
            Controls.Add(Create);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Create;
        private Button Save;
        private Button Download;
        private Label Check;
    }
}