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
            btn1 = new Button();
            lbl = new Label();
            tb = new TextBox();
            btn2 = new Button();
            btn3 = new Button();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Location = new Point(147, 269);
            btn1.Name = "btn1";
            btn1.Size = new Size(75, 23);
            btn1.TabIndex = 0;
            btn1.Text = "SB";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(147, 202);
            lbl.Name = "lbl";
            lbl.Size = new Size(50, 15);
            lbl.TabIndex = 4;
            lbl.Text = "WYNIK: ";
            // 
            // tb
            // 
            tb.Location = new Point(147, 146);
            tb.Name = "tb";
            tb.Size = new Size(465, 23);
            tb.TabIndex = 5;
            // 
            // btn2
            // 
            btn2.Location = new Point(238, 269);
            btn2.Name = "btn2";
            btn2.Size = new Size(75, 23);
            btn2.TabIndex = 6;
            btn2.Text = "SS";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(329, 269);
            btn3.Name = "btn3";
            btn3.Size = new Size(75, 23);
            btn3.TabIndex = 7;
            btn3.Text = "IS";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(tb);
            Controls.Add(lbl);
            Controls.Add(btn1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn1;
        private Label lbl;
        private TextBox tb;
        private Button btn2;
        private Button btn3;
    }
}