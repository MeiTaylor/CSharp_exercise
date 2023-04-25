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
            comboBox1 = new ComboBox();
            label6 = new Label();
            labelAdd = new Label();
            textBoxName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxOrderID = new TextBox();
            splitContainer2 = new SplitContainer();
            tabControl1 = new TabControl();
            buttonAdd = new Button();
            tabPage1 = new TabPage();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label3 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            tabPage2 = new TabPage();
            button1 = new Button();
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
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(comboBox1);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(labelAdd);
            splitContainer1.Panel1.Controls.Add(textBoxName);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(textBoxOrderID);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(821, 418);
            splitContainer1.SplitterDistance = 167;
            splitContainer1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            comboBox1.Location = new Point(465, 117);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(128, 32);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(465, 71);
            label6.Name = "label6";
            label6.Size = new Size(118, 24);
            label6.TabIndex = 4;
            label6.Text = "订单明细数目";
            // 
            // labelAdd
            // 
            labelAdd.Anchor = AnchorStyles.None;
            labelAdd.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labelAdd.ForeColor = SystemColors.ActiveCaption;
            labelAdd.Location = new Point(305, 0);
            labelAdd.Name = "labelAdd";
            labelAdd.Size = new Size(201, 58);
            labelAdd.TabIndex = 0;
            labelAdd.Text = "添加订单";
            labelAdd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(239, 125);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(150, 30);
            textBoxName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 71);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 0;
            label1.Text = "订单号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 125);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 2;
            label2.Text = "顾客姓名";
            // 
            // textBoxOrderID
            // 
            textBoxOrderID.Location = new Point(239, 71);
            textBoxOrderID.Name = "textBoxOrderID";
            textBoxOrderID.Size = new Size(150, 30);
            textBoxOrderID.TabIndex = 1;
            // 
            // splitContainer2
            // 
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(buttonAdd);
            splitContainer2.Size = new Size(821, 346);
            splitContainer2.SplitterDistance = 247;
            splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Location = new Point(12, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(797, 214);
            tabControl1.TabIndex = 10;
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
            // tabPage1
            // 
            tabPage1.Location = new Point(0, 0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(200, 100);
            tabPage1.TabIndex = 0;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(330, 77);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 30);
            textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(330, 125);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 30);
            textBox5.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(237, 25);
            label3.Name = "label3";
            label3.Size = new Size(82, 24);
            label3.TabIndex = 4;
            label3.Text = "商品名称";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(237, 125);
            label5.Name = "label5";
            label5.Size = new Size(82, 24);
            label5.TabIndex = 8;
            label5.Text = "商品单价";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(330, 25);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 30);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(237, 77);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 6;
            label4.Text = "商品数量";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(0, 0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(200, 100);
            tabPage2.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Info;
            button1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(305, 448);
            button1.Name = "button1";
            button1.Size = new Size(203, 69);
            button1.TabIndex = 1;
            button1.Text = "确认添加";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // addOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 572);
            Controls.Add(button1);
            Controls.Add(splitContainer1);
            Name = "addOrder";
            Text = "addOrder";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label labelAdd;
        private TextBox textBoxName;
        private Label label2;
        private TextBox textBoxOrderID;
        private Label label1;
        private Button buttonAdd;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private Label label6;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ComboBox comboBox1;
        private Button button1;
    }
}