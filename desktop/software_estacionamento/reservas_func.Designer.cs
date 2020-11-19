namespace software_estacionamento
{
    partial class reservas_func
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reservas_func));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Consultar_Veiculo = new System.Windows.Forms.Button();
            this.dataGridVeiculos = new System.Windows.Forms.DataGridView();
            this.placa_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_prop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cor_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_reserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_placa_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_inicio_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_final_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVeiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(409, 69);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(418, 31);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_reserva,
            this.id_placa_veiculo,
            this.servico,
            this.vaga,
            this.timestamp_inicio_uso,
            this.timestamp_final_uso,
            this.subtotal,
            this.nome_usuario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(91, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1193, 361);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_Consultar_Veiculo
            // 
            this.btn_Consultar_Veiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Consultar_Veiculo.Location = new System.Drawing.Point(576, 661);
            this.btn_Consultar_Veiculo.Name = "btn_Consultar_Veiculo";
            this.btn_Consultar_Veiculo.Size = new System.Drawing.Size(272, 48);
            this.btn_Consultar_Veiculo.TabIndex = 4;
            this.btn_Consultar_Veiculo.Text = "Consultar Veículo";
            this.btn_Consultar_Veiculo.UseVisualStyleBackColor = true;
            this.btn_Consultar_Veiculo.Click += new System.EventHandler(this.btn_Consultar_Veiculo_Click);
            // 
            // dataGridVeiculos
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVeiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVeiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.placa_veiculo,
            this.cidade_veiculo,
            this.Estado_veiculo,
            this.Nome_prop,
            this.Marca_veiculo,
            this.Modelo_veiculo,
            this.Cor_veiculo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridVeiculos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridVeiculos.Location = new System.Drawing.Point(91, 539);
            this.dataGridVeiculos.Name = "dataGridVeiculos";
            this.dataGridVeiculos.Size = new System.Drawing.Size(1193, 74);
            this.dataGridVeiculos.TabIndex = 5;
            this.dataGridVeiculos.Visible = false;
            // 
            // placa_veiculo
            // 
            this.placa_veiculo.DataPropertyName = "id_placa_veiculo";
            this.placa_veiculo.HeaderText = "Placa";
            this.placa_veiculo.Name = "placa_veiculo";
            // 
            // cidade_veiculo
            // 
            this.cidade_veiculo.DataPropertyName = "cidade_veiculo";
            this.cidade_veiculo.HeaderText = "Cidade";
            this.cidade_veiculo.Name = "cidade_veiculo";
            this.cidade_veiculo.Width = 200;
            // 
            // Estado_veiculo
            // 
            this.Estado_veiculo.DataPropertyName = "Estado_veiculo";
            this.Estado_veiculo.HeaderText = "UF";
            this.Estado_veiculo.Name = "Estado_veiculo";
            this.Estado_veiculo.Width = 50;
            // 
            // Nome_prop
            // 
            this.Nome_prop.DataPropertyName = "nome_prop_veiculo";
            this.Nome_prop.HeaderText = "Nome do proprietário";
            this.Nome_prop.Name = "Nome_prop";
            this.Nome_prop.Width = 400;
            // 
            // Marca_veiculo
            // 
            this.Marca_veiculo.DataPropertyName = "marca_veiculo";
            this.Marca_veiculo.HeaderText = "Marca";
            this.Marca_veiculo.Name = "Marca_veiculo";
            this.Marca_veiculo.Width = 200;
            // 
            // Modelo_veiculo
            // 
            this.Modelo_veiculo.DataPropertyName = "modelo_veiculo";
            this.Modelo_veiculo.HeaderText = "Modelo";
            this.Modelo_veiculo.Name = "Modelo_veiculo";
            // 
            // Cor_veiculo
            // 
            this.Cor_veiculo.DataPropertyName = "cor_veiculo";
            this.Cor_veiculo.HeaderText = "Cor";
            this.Cor_veiculo.Name = "Cor_veiculo";
            // 
            // id_reserva
            // 
            this.id_reserva.DataPropertyName = "id_reserva";
            this.id_reserva.HeaderText = "Reserva";
            this.id_reserva.Name = "id_reserva";
            this.id_reserva.ReadOnly = true;
            // 
            // id_placa_veiculo
            // 
            this.id_placa_veiculo.DataPropertyName = "id_placa_veiculo";
            this.id_placa_veiculo.HeaderText = "Placa do veículo";
            this.id_placa_veiculo.Name = "id_placa_veiculo";
            this.id_placa_veiculo.ReadOnly = true;
            // 
            // servico
            // 
            this.servico.DataPropertyName = "desc_servico";
            this.servico.HeaderText = "Serviço";
            this.servico.Name = "servico";
            this.servico.ReadOnly = true;
            this.servico.Width = 200;
            // 
            // vaga
            // 
            this.vaga.DataPropertyName = "local_vaga";
            this.vaga.HeaderText = "vaga";
            this.vaga.Name = "vaga";
            this.vaga.ReadOnly = true;
            // 
            // timestamp_inicio_uso
            // 
            this.timestamp_inicio_uso.DataPropertyName = "timestamp_inicio_reserva";
            this.timestamp_inicio_uso.HeaderText = "Hora inicial";
            this.timestamp_inicio_uso.Name = "timestamp_inicio_uso";
            this.timestamp_inicio_uso.ReadOnly = true;
            this.timestamp_inicio_uso.Width = 175;
            // 
            // timestamp_final_uso
            // 
            this.timestamp_final_uso.DataPropertyName = "timestamp_final_reserva";
            this.timestamp_final_uso.HeaderText = "hora final";
            this.timestamp_final_uso.Name = "timestamp_final_uso";
            this.timestamp_final_uso.ReadOnly = true;
            this.timestamp_final_uso.Width = 175;
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "subtotal";
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // nome_usuario
            // 
            this.nome_usuario.DataPropertyName = "nome_usuario";
            this.nome_usuario.FillWeight = 250F;
            this.nome_usuario.HeaderText = "Nome cliente";
            this.nome_usuario.Name = "nome_usuario";
            this.nome_usuario.ReadOnly = true;
            this.nome_usuario.Width = 200;
            // 
            // reservas_func
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1356, 739);
            this.Controls.Add(this.dataGridVeiculos);
            this.Controls.Add(this.btn_Consultar_Veiculo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "reservas_func";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVeiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Consultar_Veiculo;
        private System.Windows.Forms.DataGridView dataGridVeiculos;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_prop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cor_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_reserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_placa_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn servico;
        private System.Windows.Forms.DataGridViewTextBoxColumn vaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_inicio_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_final_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_usuario;
    }
}