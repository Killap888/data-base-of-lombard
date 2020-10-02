namespace Lombardo
{
    partial class FormNewClient
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIdClient = new System.Windows.Forms.TextBox();
            this.button_close_form_NewClient = new System.Windows.Forms.Button();
            this.button_save_new_client = new System.Windows.Forms.Button();
            this.maskedTextBoxClientTel = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxClientPassport = new System.Windows.Forms.MaskedTextBox();
            this.textBoxClientMidName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientFirstName = new System.Windows.Forms.TextBox();
            this.textBoxClientLastName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Номер телефона";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Серия и номер паспорта";
            // 
            // textBoxIdClient
            // 
            this.textBoxIdClient.Enabled = false;
            this.textBoxIdClient.Location = new System.Drawing.Point(12, 9);
            this.textBoxIdClient.Name = "textBoxIdClient";
            this.textBoxIdClient.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdClient.TabIndex = 26;
            this.textBoxIdClient.Text = " ";
            // 
            // button_close_form_NewClient
            // 
            this.button_close_form_NewClient.Location = new System.Drawing.Point(168, 274);
            this.button_close_form_NewClient.Name = "button_close_form_NewClient";
            this.button_close_form_NewClient.Size = new System.Drawing.Size(91, 47);
            this.button_close_form_NewClient.TabIndex = 25;
            this.button_close_form_NewClient.Text = "Закрыть";
            this.button_close_form_NewClient.UseVisualStyleBackColor = true;
            this.button_close_form_NewClient.Click += new System.EventHandler(this.button_close_form_NewClient_Click);
            // 
            // button_save_new_client
            // 
            this.button_save_new_client.Location = new System.Drawing.Point(12, 274);
            this.button_save_new_client.Name = "button_save_new_client";
            this.button_save_new_client.Size = new System.Drawing.Size(91, 47);
            this.button_save_new_client.TabIndex = 24;
            this.button_save_new_client.Text = "Сохранить";
            this.button_save_new_client.UseVisualStyleBackColor = true;
            this.button_save_new_client.Click += new System.EventHandler(this.button_save_new_client_Click);
            // 
            // maskedTextBoxClientTel
            // 
            this.maskedTextBoxClientTel.Location = new System.Drawing.Point(12, 216);
            this.maskedTextBoxClientTel.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBoxClientTel.Mask = "8(999) 000-0000";
            this.maskedTextBoxClientTel.Name = "maskedTextBoxClientTel";
            this.maskedTextBoxClientTel.Size = new System.Drawing.Size(189, 20);
            this.maskedTextBoxClientTel.TabIndex = 23;
            // 
            // maskedTextBoxClientPassport
            // 
            this.maskedTextBoxClientPassport.Location = new System.Drawing.Point(12, 171);
            this.maskedTextBoxClientPassport.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBoxClientPassport.Mask = "0000-999999";
            this.maskedTextBoxClientPassport.Name = "maskedTextBoxClientPassport";
            this.maskedTextBoxClientPassport.Size = new System.Drawing.Size(189, 20);
            this.maskedTextBoxClientPassport.TabIndex = 22;
            // 
            // textBoxClientMidName
            // 
            this.textBoxClientMidName.Location = new System.Drawing.Point(12, 126);
            this.textBoxClientMidName.Name = "textBoxClientMidName";
            this.textBoxClientMidName.Size = new System.Drawing.Size(189, 20);
            this.textBoxClientMidName.TabIndex = 21;
            this.textBoxClientMidName.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Фамилия";
            // 
            // textBoxClientFirstName
            // 
            this.textBoxClientFirstName.Location = new System.Drawing.Point(12, 86);
            this.textBoxClientFirstName.Name = "textBoxClientFirstName";
            this.textBoxClientFirstName.Size = new System.Drawing.Size(189, 20);
            this.textBoxClientFirstName.TabIndex = 17;
            this.textBoxClientFirstName.Text = " ";
            // 
            // textBoxClientLastName
            // 
            this.textBoxClientLastName.Location = new System.Drawing.Point(12, 47);
            this.textBoxClientLastName.Name = "textBoxClientLastName";
            this.textBoxClientLastName.Size = new System.Drawing.Size(189, 20);
            this.textBoxClientLastName.TabIndex = 16;
            this.textBoxClientLastName.Text = " ";
            // 
            // FormNewClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 332);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxIdClient);
            this.Controls.Add(this.button_close_form_NewClient);
            this.Controls.Add(this.button_save_new_client);
            this.Controls.Add(this.maskedTextBoxClientTel);
            this.Controls.Add(this.maskedTextBoxClientPassport);
            this.Controls.Add(this.textBoxClientMidName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxClientFirstName);
            this.Controls.Add(this.textBoxClientLastName);
            this.Name = "FormNewClient";
            this.Text = "FormNewClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIdClient;
        private System.Windows.Forms.Button button_close_form_NewClient;
        private System.Windows.Forms.Button button_save_new_client;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxClientTel;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxClientPassport;
        private System.Windows.Forms.TextBox textBoxClientMidName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientFirstName;
        private System.Windows.Forms.TextBox textBoxClientLastName;
    }
}