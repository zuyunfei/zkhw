namespace zkhwClient.view.HomeDoctorSigningView
{
    partial class addMember
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
            this.label1 = new System.Windows.Forms.Label();
            this.姓名 = new System.Windows.Forms.TextBox();
            this.职务 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.联系方式 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.团队长 = new System.Windows.Forms.RadioButton();
            this.团队成员 = new System.Windows.Forms.RadioButton();
            this.取消 = new System.Windows.Forms.Button();
            this.确定 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // 姓名
            // 
            this.姓名.Location = new System.Drawing.Point(107, 24);
            this.姓名.Name = "姓名";
            this.姓名.Size = new System.Drawing.Size(100, 21);
            this.姓名.TabIndex = 1;
            // 
            // 职务
            // 
            this.职务.Location = new System.Drawing.Point(107, 66);
            this.职务.Name = "职务";
            this.职务.Size = new System.Drawing.Size(100, 21);
            this.职务.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "职务：";
            // 
            // 联系方式
            // 
            this.联系方式.Location = new System.Drawing.Point(107, 104);
            this.联系方式.Name = "联系方式";
            this.联系方式.Size = new System.Drawing.Size(100, 21);
            this.联系方式.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "联系方式：";
            // 
            // 团队长
            // 
            this.团队长.AutoSize = true;
            this.团队长.Checked = true;
            this.团队长.Location = new System.Drawing.Point(11, 18);
            this.团队长.Name = "团队长";
            this.团队长.Size = new System.Drawing.Size(59, 16);
            this.团队长.TabIndex = 6;
            this.团队长.TabStop = true;
            this.团队长.Text = "团队长";
            this.团队长.UseVisualStyleBackColor = true;
            // 
            // 团队成员
            // 
            this.团队成员.AutoSize = true;
            this.团队成员.Location = new System.Drawing.Point(86, 18);
            this.团队成员.Name = "团队成员";
            this.团队成员.Size = new System.Drawing.Size(71, 16);
            this.团队成员.TabIndex = 7;
            this.团队成员.Text = "团队成员";
            this.团队成员.UseVisualStyleBackColor = true;
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(25, 189);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(75, 23);
            this.取消.TabIndex = 8;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // 确定
            // 
            this.确定.Location = new System.Drawing.Point(150, 189);
            this.确定.Name = "确定";
            this.确定.Size = new System.Drawing.Size(75, 23);
            this.确定.TabIndex = 9;
            this.确定.Text = "确定";
            this.确定.UseVisualStyleBackColor = true;
            this.确定.Click += new System.EventHandler(this.确定_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.团队长);
            this.groupBox1.Controls.Add(this.团队成员);
            this.groupBox1.Location = new System.Drawing.Point(38, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 43);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // addMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 242);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.确定);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.联系方式);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.职务);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.姓名);
            this.Controls.Add(this.label1);
            this.Name = "addMember";
            this.Text = "新增成员";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox 姓名;
        private System.Windows.Forms.TextBox 职务;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox 联系方式;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton 团队长;
        private System.Windows.Forms.RadioButton 团队成员;
        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.Button 确定;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}