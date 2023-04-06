namespace HomeworkSixth
{
    partial class addOrder
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
            splitContainer1 = new SplitContainer();
            labelAdd = new Label();
            splitContainer2 = new SplitContainer();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            buttonAdd = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(labelAdd);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 74;
            splitContainer1.TabIndex = 0;
            // 
            // labelAdd
            // 
            labelAdd.Anchor = AnchorStyles.None;
            labelAdd.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labelAdd.ForeColor = SystemColors.ActiveCaption;
            labelAdd.Location = new Point(305, 9);
            labelAdd.Name = "labelAdd";
            labelAdd.Size = new Size(201, 58);
            labelAdd.TabIndex = 0;
            labelAdd.Text = "添加订单";
            labelAdd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(textBox5);
            splitContainer2.Panel1.Controls.Add(label5);
            splitContainer2.Panel1.Controls.Add(textBox4);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Controls.Add(textBox3);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(textBox2);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(textBox1);
            splitContainer2.Panel1.Controls.Add(label1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(buttonAdd);
            splitContainer2.Size = new Size(800, 372);
            splitContainer2.SplitterDistance = 266;
            splitContainer2.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(366, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 30);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(273, 63);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 2;
            label2.Text = "顾客姓名";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(366, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(273, 12);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 0;
            label1.Text = "订单号";
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdd.ForeColor = SystemColors.ActiveCaption;
            buttonAdd.Location = new Point(282, 21);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(224, 69);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "确认添加";
            buttonAdd.UseCompatibleTextRendering = true;
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(273, 113);
            label3.Name = "label3";
            label3.Size = new Size(82, 24);
            label3.TabIndex = 4;
            label3.Text = "商品名称";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(366, 113);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 30);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(273, 165);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 6;
            label4.Text = "商品数量";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(366, 165);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 30);
            textBox4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(273, 213);
            label5.Name = "label5";
            label5.Size = new Size(82, 24);
            label5.TabIndex = 8;
            label5.Text = "商品单价";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(366, 213);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 30);
            textBox5.TabIndex = 9;
            // 
            // addOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "addOrder";
            Text = "addOrder";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label labelAdd;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button buttonAdd;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
    }
}