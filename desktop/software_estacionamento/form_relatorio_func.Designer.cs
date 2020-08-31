namespace software_estacionamento
{
    partial class form_relatorio_func
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbox_relatorio_func = new System.Windows.Forms.ComboBox();
            this.lbl_selecione = new System.Windows.Forms.Label();
            this.Iid_nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_inicio_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_final_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Iid_nota,
            this.nome_usuario,
            this.id_placa,
            this.servico,
            this.vaga,
            this.timestamp_inicio_uso,
            this.timestamp_final_uso,
            this.total});
            this.dataGridView1.Location = new System.Drawing.Point(75, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1043, 457);
            this.dataGridView1.TabIndex = 0;
            // 
            // cbox_relatorio_func
            // 
            this.cbox_relatorio_func.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_relatorio_func.FormattingEnabled = true;
            this.cbox_relatorio_func.Items.AddRange(new object[] {
            "Selecione o tipo de relatório",
            "Relatório de serviços em uso",
            "Relatório dos serviços das últimas 24 horas"});
            this.cbox_relatorio_func.Location = new System.Drawing.Point(256, 57);
            this.cbox_relatorio_func.Name = "cbox_relatorio_func";
            this.cbox_relatorio_func.Size = new System.Drawing.Size(862, 28);
            this.cbox_relatorio_func.TabIndex = 1;
            // 
            // lbl_selecione
            // 
            this.lbl_selecione.AutoSize = true;
            this.lbl_selecione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selecione.Location = new System.Drawing.Point(71, 65);
            this.lbl_selecione.Name = "lbl_selecione";
            this.lbl_selecione.Size = new System.Drawing.Size(179, 20);
            this.lbl_selecione.TabIndex = 2;
            this.lbl_selecione.Text = "Selecione o relatório:";
            // 
            // Iid_nota
            // 
            this.Iid_nota.HeaderText = "Nota fiscal";
            this.Iid_nota.Name = "Iid_nota";
            // 
            // nome_usuario
            // 
            this.nome_usuario.HeaderText = "Nome do cliente";
            this.nome_usuario.Name = "nome_usuario";
            this.nome_usuario.Width = 300;
            // 
            // id_placa
            // 
            this.id_placa.HeaderText = "Placa do veículo";
            this.id_placa.Name = "id_placa";
            // 
            // servico
            // 
            this.servico.HeaderText = "Serviço";
            this.servico.Name = "servico";
            // 
            // vaga
            // 
            this.vaga.HeaderText = "vaga";
            this.vaga.Name = "vaga";
            // 
            // timestamp_inicio_uso
            // 
            this.timestamp_inicio_uso.HeaderText = "Hora inicial";
            this.timestamp_inicio_uso.Name = "timestamp_inicio_uso";
            // 
            // timestamp_final_uso
            // 
            this.timestamp_final_uso.HeaderText = "horario final";
            this.timestamp_final_uso.Name = "timestamp_final_uso";
            // 
            // total
            // 
            this.total.HeaderText = "total";
            this.total.Name = "total";
            // 
            // form_relatorio_func
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 652);
            this.Controls.Add(this.lbl_selecione);
            this.Controls.Add(this.cbox_relatorio_func);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_relatorio_func";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatórios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbox_relatorio_func;
        private System.Windows.Forms.Label lbl_selecione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iid_nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn servico;
        private System.Windows.Forms.DataGridViewTextBoxColumn vaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_inicio_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_final_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}