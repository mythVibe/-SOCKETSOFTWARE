
namespace Client
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
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.richTextBox_Send = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Recieve = new System.Windows.Forms.RichTextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(27, 390);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(121, 43);
            this.button_Send.TabIndex = 15;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(27, 198);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(121, 43);
            this.button_Connect.TabIndex = 14;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // richTextBox_Send
            // 
            this.richTextBox_Send.Location = new System.Drawing.Point(291, 356);
            this.richTextBox_Send.Name = "richTextBox_Send";
            this.richTextBox_Send.Size = new System.Drawing.Size(534, 134);
            this.richTextBox_Send.TabIndex = 13;
            this.richTextBox_Send.Text = "";
            // 
            // richTextBox_Recieve
            // 
            this.richTextBox_Recieve.Location = new System.Drawing.Point(291, 17);
            this.richTextBox_Recieve.Name = "richTextBox_Recieve";
            this.richTextBox_Recieve.Size = new System.Drawing.Size(534, 311);
            this.richTextBox_Recieve.TabIndex = 12;
            this.richTextBox_Recieve.Text = "";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(126, 97);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(138, 21);
            this.textBox_Port.TabIndex = 11;
            this.textBox_Port.Text = "8045";
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Location = new System.Drawing.Point(126, 55);
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(138, 21);
            this.textBox_Addr.TabIndex = 10;
            this.textBox_Addr.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 507);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Connect);
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

        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.RichTextBox richTextBox_Send;
        private System.Windows.Forms.RichTextBox richTextBox_Recieve;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

