namespace calculatorVisuable
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
            numFirst = new TextBox();
            numSecond = new TextBox();
            Result = new TextBox();
            Calculate = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // numFirst
            // 
            numFirst.Location = new Point(31, 51);
            numFirst.Name = "numFirst";
            numFirst.Size = new Size(203, 30);
            numFirst.TabIndex = 0;
            numFirst.Text = "numFirst";
            numFirst.TextChanged += numFirst_TextChanged;
            // 
            // numSecond
            // 
            numSecond.Location = new Point(31, 259);
            numSecond.Name = "numSecond";
            numSecond.Size = new Size(203, 30);
            numSecond.TabIndex = 1;
            numSecond.Text = "numSecond";
            numSecond.TextChanged += numSecond_TextChanged;
            // 
            // Result
            // 
            Result.Location = new Point(621, 154);
            Result.Name = "Result";
            Result.Size = new Size(174, 30);
            Result.TabIndex = 2;
            Result.Text = "Result";
            // 
            // Calculate
            // 
            Calculate.Location = new Point(453, 155);
            Calculate.Name = "Calculate";
            Calculate.Size = new Size(149, 34);
            Calculate.TabIndex = 3;
            Calculate.Text = "Calculate";
            Calculate.UseVisualStyleBackColor = true;
            Calculate.Click += Calculate_Click;
            // 
            // button1
            // 
            button1.Location = new Point(280, 34);
            button1.Name = "button1";
            button1.Size = new Size(89, 37);
            button1.TabIndex = 4;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(280, 120);
            button2.Name = "button2";
            button2.Size = new Size(89, 37);
            button2.TabIndex = 5;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(280, 205);
            button3.Name = "button3";
            button3.Size = new Size(89, 37);
            button3.TabIndex = 6;
            button3.Text = "*";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(280, 288);
            button4.Name = "button4";
            button4.Size = new Size(89, 37);
            button4.TabIndex = 7;
            button4.Text = "/";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Calculate);
            Controls.Add(Result);
            Controls.Add(numSecond);
            Controls.Add(numFirst);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox numFirst;
        private TextBox numSecond;
        private TextBox Result;
        private Button Calculate;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}