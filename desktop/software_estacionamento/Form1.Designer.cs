﻿namespace software_estacionamento
{
    partial class form_login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_login));
            this.lbl_user_login = new System.Windows.Forms.Label();
            this.lbl_senha_login = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.btn_acessar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_user_login
            // 
            this.lbl_user_login.AutoSize = true;
            this.lbl_user_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user_login.Location = new System.Drawing.Point(12, 50);
            this.lbl_user_login.Name = "lbl_user_login";
            this.lbl_user_login.Size = new System.Drawing.Size(145, 24);
            this.lbl_user_login.TabIndex = 0;
            this.lbl_user_login.Text = "ID funcionário:";
            // 
            // lbl_senha_login
            // 
            this.lbl_senha_login.AutoSize = true;
            this.lbl_senha_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_senha_login.Location = new System.Drawing.Point(63, 123);
            this.lbl_senha_login.Name = "lbl_senha_login";
            this.lbl_senha_login.Size = new System.Drawing.Size(76, 24);
            this.lbl_senha_login.TabIndex = 1;
            this.lbl_senha_login.Text = "Senha:";
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Location = new System.Drawing.Point(163, 50);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(220, 26);
            this.txt_user.TabIndex = 2;
            this.txt_user.TextChanged += new System.EventHandler(this.txt_user_TextChanged);
            this.txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_user_KeyPress);
            // 
            // txt_senha
            // 
            this.txt_senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_senha.Location = new System.Drawing.Point(163, 123);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '•';
            this.txt_senha.Size = new System.Drawing.Size(220, 26);
            this.txt_senha.TabIndex = 3;
            // 
            // btn_acessar
            // 
            this.btn_acessar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_acessar.Location = new System.Drawing.Point(67, 196);
            this.btn_acessar.Name = "btn_acessar";
            this.btn_acessar.Size = new System.Drawing.Size(260, 55);
            this.btn_acessar.TabIndex = 4;
            this.btn_acessar.Text = "Acessar";
            this.btn_acessar.UseVisualStyleBackColor = true;
            this.btn_acessar.Click += new System.EventHandler(this.btn_acessar_Click);
            // 
            // form_login
            // 
            this.AcceptButton = this.btn_acessar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 288);
            this.Controls.Add(this.btn_acessar);
            this.Controls.Add(this.txt_senha);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.lbl_senha_login);
            this.Controls.Add(this.lbl_user_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login no sistema e-stacionar";
            this.Load += new System.EventHandler(this.form_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user_login;
        private System.Windows.Forms.Label lbl_senha_login;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Button btn_acessar;
    }
}

