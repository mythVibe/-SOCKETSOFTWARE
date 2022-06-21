
namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.richTextBox_Recieve = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Send = new System.Windows.Forms.RichTextBox();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(62, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(62, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Location = new System.Drawing.Point(165, 64);
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(138, 21);
            this.textBox_Addr.TabIndex = 2;
            this.textBox_Addr.Text = "127.0.0.1";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(165, 106);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(138, 21);
            this.textBox_Port.TabIndex = 3;
            this.textBox_Port.Text = "8045";
            // 
            // richTextBox_Recieve
            // 
            this.richTextBox_Recieve.Location = new System.Drawing.Point(330, 26);
            this.richTextBox_Recieve.Name = "richTextBox_Recieve";
            this.richTextBox_Recieve.Size = new System.Drawing.Size(534, 311);
            this.richTextBox_Recieve.TabIndex = 4;
            this.richTextBox_Recieve.Text = "";
            // 
            // richTextBox_Send
            // 
            this.richTextBox_Send.Location = new System.Drawing.Point(330, 365);
            this.richTextBox_Send.Name = "richTextBox_Send";
            this.richTextBox_Send.Size = new System.Drawing.Size(534, 134);
            this.richTextBox_Send.TabIndex = 5;
            this.richTextBox_Send.Text = "";
            // 
            // button_Accept
            // 
            this.button_Accept.Location = new System.Drawing.Point(66, 207);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(121, 43);
            this.button_Accept.TabIndex = 6;
            this.button_Accept.Text = "Accept";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(66, 399);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(121, 43);
            this.button_Send.TabIndex = 7;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 550);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.richTextBox_Send);
            this.Controls.Add(this.richTextBox_Recieve);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Addr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.RichTextBox richTextBox_Recieve;
        private System.Windows.Forms.RichTextBox richTextBox_Send;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Send;
    }
}

