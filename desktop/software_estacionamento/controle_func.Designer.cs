namespace software_estacionamento
{
    partial class controle_func
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
            this.Iid_nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_inicio_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_final_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_corrigir_func = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(104, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1043, 542);
            this.dataGridView1.TabIndex = 1;
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
            // btn_corrigir_func
            // 
            this.btn_corrigir_func.Location = new System.Drawing.Point(556, 689);
            this.btn_corrigir_func.Name = "btn_corrigir_func";
            this.btn_corrigir_func.Size = new System.Drawing.Size(144, 38);
            this.btn_corrigir_func.TabIndex = 2;
            this.btn_corrigir_func.Text = "corrigir dados";
            this.btn_corrigir_func.UseVisualStyleBackColor = true;
            // 
            // controle_func
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 785);
            this.Controls.Add(this.btn_corrigir_func);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "controle_func";
            this.Text = "Controle Manual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iid_nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn servico;
        private System.Windows.Forms.DataGridViewTextBoxColumn vaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_inicio_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_final_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Button btn_corrigir_func;
    }
}