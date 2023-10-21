namespace MainProject
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
            btnStart = new Button();
            labelAfter = new Label();
            arrayInput = new TextBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(365, 240);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // labelAfter
            // 
            labelAfter.AutoSize = true;
            labelAfter.Location = new Point(365, 313);
            labelAfter.Name = "labelAfter";
            labelAfter.Size = new Size(50, 15);
            labelAfter.TabIndex = 4;
            labelAfter.Text = "WYNIK: ";
            labelAfter.Click += label1_Click_1;
            // 
            // arrayInput
            // 
            arrayInput.Location = new Point(365, 188);
            arrayInput.Name = "arrayInput";
            arrayInput.Size = new Size(100, 23);
            arrayInput.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(arrayInput);
            Controls.Add(labelAfter);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label labelAfter;
        private TextBox arrayInput;
    }
}