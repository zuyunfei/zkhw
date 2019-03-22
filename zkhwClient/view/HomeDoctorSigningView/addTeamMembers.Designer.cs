namespace zkhwClient.view.HomeDoctorSigningView
{
    partial class addTeamMembers
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
            this.团队名称 = new System.Windows.Forms.TextBox();
            this.取消 = new System.Windows.Forms.Button();
            this.确定 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "团队名称:";
            // 
            // 团队名称
            // 
            this.团队名称.Location = new System.Drawing.Point(114, 35);
            this.团队名称.Name = "团队名称";
            this.团队名称.Size = new System.Drawing.Size(100, 21);
            this.团队名称.TabIndex = 1;
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(51, 81);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(75, 23);
            this.取消.TabIndex = 2;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // 确定
            // 
            this.确定.Location = new System.Drawing.Point(159, 81);
            this.确定.Name = "确定";
            this.确定.Size = new System.Drawing.Size(75, 23);
            this.确定.TabIndex = 3;
            this.确定.Text = "确定";
            this.确定.UseVisualStyleBackColor = true;
            this.确定.Click += new System.EventHandler(this.确定_Click);
            // 
            // addTeamMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 123);
            this.Controls.Add(this.确定);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.团队名称);
            this.Controls.Add(this.label1);
            this.Name = "addTeamMembers";
            this.Text = "新增团队";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox 团队名称;
        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.Button 确定;
    }
}