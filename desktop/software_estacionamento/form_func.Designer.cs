namespace software_estacionamento
{
    partial class form_func
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
            this.menu_func = new System.Windows.Forms.MenuStrip();
            this.menu_relatorio_item = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_reservas_item = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_controle_item = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_func.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_func
            // 
            this.menu_func.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menu_func.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_relatorio_item,
            this.menu_reservas_item,
            this.menu_controle_item});
            this.menu_func.Location = new System.Drawing.Point(0, 0);
            this.menu_func.Name = "menu_func";
            this.menu_func.Size = new System.Drawing.Size(1248, 48);
            this.menu_func.TabIndex = 0;
            this.menu_func.Text = "menuStrip1";
            // 
            // menu_relatorio_item
            // 
            this.menu_relatorio_item.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menu_relatorio_item.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_relatorio_item.Name = "menu_relatorio_item";
            this.menu_relatorio_item.Padding = new System.Windows.Forms.Padding(4, 10, 200, 0);
            this.menu_relatorio_item.Size = new System.Drawing.Size(335, 44);
            this.menu_relatorio_item.Text = "RELATÓRIO";
            // 
            // menu_reservas_item
            // 
            this.menu_reservas_item.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menu_reservas_item.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_reservas_item.Name = "menu_reservas_item";
            this.menu_reservas_item.Padding = new System.Windows.Forms.Padding(4, 0, 200, 0);
            this.menu_reservas_item.Size = new System.Drawing.Size(323, 44);
            this.menu_reservas_item.Text = "RESERVAS";
            // 
            // menu_controle_item
            // 
            this.menu_controle_item.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menu_controle_item.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_controle_item.Name = "menu_controle_item";
            this.menu_controle_item.Padding = new System.Windows.Forms.Padding(4, 0, 200, 0);
            this.menu_controle_item.Size = new System.Drawing.Size(430, 44);
            this.menu_controle_item.Text = "CONTROLE MANUAL";
            // 
            // form_func
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1248, 791);
            this.Controls.Add(this.menu_func);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu_func;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_func";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "CONTROLE DO ESTACIONAMENTO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu_func.ResumeLayout(false);
            this.menu_func.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_func;
        private System.Windows.Forms.ToolStripMenuItem menu_relatorio_item;
        private System.Windows.Forms.ToolStripMenuItem menu_reservas_item;
        private System.Windows.Forms.ToolStripMenuItem menu_controle_item;
    }
}