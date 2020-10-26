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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridRelatorio = new System.Windows.Forms.DataGridView();
            this.id_placa_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_nota_fiscal_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbl_usuario_nome_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbl_servico_id_servico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbl_vaga_id_vaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_inicio_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_final_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbox_relatorio_func = new System.Windows.Forms.ComboBox();
            this.lbl_selecione = new System.Windows.Forms.Label();
            this.btn_Consultar_Veiculo = new System.Windows.Forms.Button();
            this.dataGridVeiculos = new System.Windows.Forms.DataGridView();
            this.placa_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_prop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cor_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRelatorio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVeiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRelatorio
            // 
            this.dataGridRelatorio.AllowUserToAddRows = false;
            this.dataGridRelatorio.AllowUserToDeleteRows = false;
            this.dataGridRelatorio.AllowUserToOrderColumns = true;
            this.dataGridRelatorio.AllowUserToResizeColumns = false;
            this.dataGridRelatorio.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridRelatorio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRelatorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_placa_veiculo,
            this.id_nota_fiscal_uso,
            this.tbl_usuario_nome_usuario,
            this.valor,
            this.tbl_servico_id_servico,
            this.tbl_vaga_id_vaga,
            this.timestamp_inicio_uso,
            this.timestamp_final_uso,
            this.total});
            this.dataGridRelatorio.Location = new System.Drawing.Point(127, 137);
            this.dataGridRelatorio.Name = "dataGridRelatorio";
            this.dataGridRelatorio.Size = new System.Drawing.Size(1142, 410);
            this.dataGridRelatorio.TabIndex = 0;
            this.dataGridRelatorio.SelectionChanged += new System.EventHandler(this.dataGridRelatorio_SelectionChanged);
            // 
            // id_placa_veiculo
            // 
            this.id_placa_veiculo.DataPropertyName = "id_placa_veiculo";
            this.id_placa_veiculo.HeaderText = "Placa do veículo";
            this.id_placa_veiculo.Name = "id_placa_veiculo";
            // 
            // id_nota_fiscal_uso
            // 
            this.id_nota_fiscal_uso.DataPropertyName = "id_nota_fiscal_uso";
            this.id_nota_fiscal_uso.HeaderText = "Nota fiscal";
            this.id_nota_fiscal_uso.Name = "id_nota_fiscal_uso";
            this.id_nota_fiscal_uso.ReadOnly = true;
            this.id_nota_fiscal_uso.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tbl_usuario_nome_usuario
            // 
            this.tbl_usuario_nome_usuario.DataPropertyName = "nome_usuario";
            this.tbl_usuario_nome_usuario.HeaderText = "Nome do cliente";
            this.tbl_usuario_nome_usuario.Name = "tbl_usuario_nome_usuario";
            this.tbl_usuario_nome_usuario.ReadOnly = true;
            this.tbl_usuario_nome_usuario.Width = 200;
            // 
            // valor
            // 
            this.valor.DataPropertyName = "valor_servico_uso";
            this.valor.HeaderText = "Valor do Serviço";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // tbl_servico_id_servico
            // 
            this.tbl_servico_id_servico.DataPropertyName = "desc_servico";
            this.tbl_servico_id_servico.HeaderText = "Serviço";
            this.tbl_servico_id_servico.Name = "tbl_servico_id_servico";
            this.tbl_servico_id_servico.ReadOnly = true;
            this.tbl_servico_id_servico.Width = 200;
            // 
            // tbl_vaga_id_vaga
            // 
            this.tbl_vaga_id_vaga.DataPropertyName = "local_vaga";
            this.tbl_vaga_id_vaga.HeaderText = "vaga";
            this.tbl_vaga_id_vaga.Name = "tbl_vaga_id_vaga";
            this.tbl_vaga_id_vaga.ReadOnly = true;
            // 
            // timestamp_inicio_uso
            // 
            this.timestamp_inicio_uso.DataPropertyName = "timestamp_inicio_uso";
            this.timestamp_inicio_uso.HeaderText = "Hora inicial";
            this.timestamp_inicio_uso.Name = "timestamp_inicio_uso";
            this.timestamp_inicio_uso.ReadOnly = true;
            // 
            // timestamp_final_uso
            // 
            this.timestamp_final_uso.DataPropertyName = "timestamp_final_uso";
            this.timestamp_final_uso.HeaderText = "horario final";
            this.timestamp_final_uso.Name = "timestamp_final_uso";
            this.timestamp_final_uso.ReadOnly = true;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // cbox_relatorio_func
            // 
            this.cbox_relatorio_func.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_relatorio_func.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_relatorio_func.FormattingEnabled = true;
            this.cbox_relatorio_func.Items.AddRange(new object[] {
            "Selecione o tipo de relatório",
            "Relatório de serviços em uso",
            "Relatório dos serviços das últimas 24 horas"});
            this.cbox_relatorio_func.Location = new System.Drawing.Point(309, 62);
            this.cbox_relatorio_func.Name = "cbox_relatorio_func";
            this.cbox_relatorio_func.Size = new System.Drawing.Size(862, 28);
            this.cbox_relatorio_func.TabIndex = 1;
            this.cbox_relatorio_func.SelectedIndexChanged += new System.EventHandler(this.cbox_relatorio_func_SelectedIndexChanged);
            // 
            // lbl_selecione
            // 
            this.lbl_selecione.AutoSize = true;
            this.lbl_selecione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selecione.Location = new System.Drawing.Point(98, 65);
            this.lbl_selecione.Name = "lbl_selecione";
            this.lbl_selecione.Size = new System.Drawing.Size(179, 20);
            this.lbl_selecione.TabIndex = 2;
            this.lbl_selecione.Text = "Selecione o relatório:";
            // 
            // btn_Consultar_Veiculo
            // 
            this.btn_Consultar_Veiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Consultar_Veiculo.Location = new System.Drawing.Point(541, 709);
            this.btn_Consultar_Veiculo.Name = "btn_Consultar_Veiculo";
            this.btn_Consultar_Veiculo.Size = new System.Drawing.Size(272, 48);
            this.btn_Consultar_Veiculo.TabIndex = 3;
            this.btn_Consultar_Veiculo.Text = "Consultar Veículo";
            this.btn_Consultar_Veiculo.UseVisualStyleBackColor = true;
            this.btn_Consultar_Veiculo.Visible = false;
            this.btn_Consultar_Veiculo.Click += new System.EventHandler(this.btn_Consultar_Veiculo_Click);
            // 
            // dataGridVeiculos
            // 
            this.dataGridVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVeiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.placa_veiculo,
            this.cidade_veiculo,
            this.Estado_veiculo,
            this.Nome_prop,
            this.Marca_veiculo,
            this.Modelo_veiculo,
            this.Cor_veiculo});
            this.dataGridVeiculos.Location = new System.Drawing.Point(127, 572);
            this.dataGridVeiculos.Name = "dataGridVeiculos";
            this.dataGridVeiculos.Size = new System.Drawing.Size(1142, 97);
            this.dataGridVeiculos.TabIndex = 4;
            this.dataGridVeiculos.Visible = false;
            // 
            // placa_veiculo
            // 
            this.placa_veiculo.DataPropertyName = "id_placa_veiculo";
            this.placa_veiculo.HeaderText = "Placa";
            this.placa_veiculo.Name = "placa_veiculo";
            this.placa_veiculo.ReadOnly = true;
            this.placa_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.placa_veiculo.Width = 75;
            // 
            // cidade_veiculo
            // 
            this.cidade_veiculo.DataPropertyName = "cidade_veiculo";
            this.cidade_veiculo.HeaderText = "Cidade";
            this.cidade_veiculo.Name = "cidade_veiculo";
            this.cidade_veiculo.ReadOnly = true;
            this.cidade_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cidade_veiculo.Width = 275;
            // 
            // Estado_veiculo
            // 
            this.Estado_veiculo.DataPropertyName = "Estado_veiculo";
            this.Estado_veiculo.HeaderText = "Estado";
            this.Estado_veiculo.Name = "Estado_veiculo";
            this.Estado_veiculo.ReadOnly = true;
            this.Estado_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Estado_veiculo.Width = 50;
            // 
            // Nome_prop
            // 
            this.Nome_prop.DataPropertyName = "nome_prop_veiculo";
            this.Nome_prop.HeaderText = "Nome do proprietário";
            this.Nome_prop.Name = "Nome_prop";
            this.Nome_prop.ReadOnly = true;
            this.Nome_prop.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nome_prop.Width = 400;
            // 
            // Marca_veiculo
            // 
            this.Marca_veiculo.DataPropertyName = "marca_veiculo";
            this.Marca_veiculo.HeaderText = "Marca";
            this.Marca_veiculo.Name = "Marca_veiculo";
            this.Marca_veiculo.ReadOnly = true;
            this.Marca_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Modelo_veiculo
            // 
            this.Modelo_veiculo.DataPropertyName = "modelo_veiculo";
            this.Modelo_veiculo.HeaderText = "Modelo";
            this.Modelo_veiculo.Name = "Modelo_veiculo";
            this.Modelo_veiculo.ReadOnly = true;
            this.Modelo_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cor_veiculo
            // 
            this.Cor_veiculo.DataPropertyName = "cor_veiculo";
            this.Cor_veiculo.HeaderText = "Cor";
            this.Cor_veiculo.Name = "Cor_veiculo";
            this.Cor_veiculo.ReadOnly = true;
            this.Cor_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cor_veiculo.Width = 98;
            // 
            // form_relatorio_func
            // 
            this.AcceptButton = this.btn_Consultar_Veiculo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1399, 809);
            this.Controls.Add(this.dataGridVeiculos);
            this.Controls.Add(this.btn_Consultar_Veiculo);
            this.Controls.Add(this.lbl_selecione);
            this.Controls.Add(this.cbox_relatorio_func);
            this.Controls.Add(this.dataGridRelatorio);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_relatorio_func";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatórios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRelatorio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVeiculos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRelatorio;
        private System.Windows.Forms.ComboBox cbox_relatorio_func;
        private System.Windows.Forms.Label lbl_selecione;
        private System.Windows.Forms.Button btn_Consultar_Veiculo;
        private System.Windows.Forms.DataGridView dataGridVeiculos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_placa_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nota_fiscal_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbl_usuario_nome_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbl_servico_id_servico;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbl_vaga_id_vaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_inicio_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_final_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_prop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cor_veiculo;
    }
}