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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_corrigir = new System.Windows.Forms.Button();
            this.dataGridControle = new System.Windows.Forms.DataGridView();
            this.tbl_vaga_id_vaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_vaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_placa_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_nota_fiscal_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbl_servico_id_servico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_inicio_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_final_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_placa = new System.Windows.Forms.TextBox();
            this.ck_pegar_horario_final = new System.Windows.Forms.CheckBox();
            this.ck_pegar_horario_iniclal = new System.Windows.Forms.CheckBox();
            this.cb_servico = new System.Windows.Forms.ComboBox();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.cb_vaga = new System.Windows.Forms.ComboBox();
            this.btn_update_status_vaga = new System.Windows.Forms.Button();
            this.btn_adicionar_uso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_hora_inicial = new System.Windows.Forms.ComboBox();
            this.cb_minuto_inicial = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_minutos_final = new System.Windows.Forms.ComboBox();
            this.cb_hora_final = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_cancelar_status = new System.Windows.Forms.Button();
            this.btn_atualizar_vaga = new System.Windows.Forms.Button();
            this.btn_confirmar_novo = new System.Windows.Forms.Button();
            this.bt_cancelar_novo = new System.Windows.Forms.Button();
            this.bt_cancelar_correcao = new System.Windows.Forms.Button();
            this.bt_confirmar_correcao = new System.Windows.Forms.Button();
            this.panel_atualizar = new System.Windows.Forms.Panel();
            this.panel_adicionar_update = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridLivres = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridControle)).BeginInit();
            this.panel_atualizar.SuspendLayout();
            this.panel_adicionar_update.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLivres)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_corrigir
            // 
            this.btn_corrigir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_corrigir.Location = new System.Drawing.Point(815, 501);
            this.btn_corrigir.Name = "btn_corrigir";
            this.btn_corrigir.Size = new System.Drawing.Size(252, 57);
            this.btn_corrigir.TabIndex = 2;
            this.btn_corrigir.Text = "corrigir dados";
            this.btn_corrigir.UseVisualStyleBackColor = true;
            this.btn_corrigir.Click += new System.EventHandler(this.btn_corrigir_func_Click);
            // 
            // dataGridControle
            // 
            this.dataGridControle.AllowUserToAddRows = false;
            this.dataGridControle.AllowUserToDeleteRows = false;
            this.dataGridControle.AllowUserToResizeColumns = false;
            this.dataGridControle.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridControle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridControle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridControle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridControle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbl_vaga_id_vaga,
            this.status_vaga,
            this.id_placa_veiculo,
            this.id_nota_fiscal_uso,
            this.valor,
            this.tbl_servico_id_servico,
            this.timestamp_inicio_uso,
            this.timestamp_final_uso,
            this.total});
            this.dataGridControle.Location = new System.Drawing.Point(30, 41);
            this.dataGridControle.MultiSelect = false;
            this.dataGridControle.Name = "dataGridControle";
            this.dataGridControle.ReadOnly = true;
            this.dataGridControle.Size = new System.Drawing.Size(1044, 220);
            this.dataGridControle.TabIndex = 3;
            this.dataGridControle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridControle_CellFormatting);
            // 
            // tbl_vaga_id_vaga
            // 
            this.tbl_vaga_id_vaga.DataPropertyName = "local_vaga";
            this.tbl_vaga_id_vaga.HeaderText = "vaga";
            this.tbl_vaga_id_vaga.Name = "tbl_vaga_id_vaga";
            this.tbl_vaga_id_vaga.ReadOnly = true;
            // 
            // status_vaga
            // 
            this.status_vaga.DataPropertyName = "status_vaga";
            this.status_vaga.HeaderText = "status da vaga";
            this.status_vaga.Name = "status_vaga";
            this.status_vaga.ReadOnly = true;
            // 
            // id_placa_veiculo
            // 
            this.id_placa_veiculo.DataPropertyName = "id_placa_veiculo";
            this.id_placa_veiculo.HeaderText = "Placa do veículo";
            this.id_placa_veiculo.Name = "id_placa_veiculo";
            this.id_placa_veiculo.ReadOnly = true;
            // 
            // id_nota_fiscal_uso
            // 
            this.id_nota_fiscal_uso.DataPropertyName = "id_nota_fiscal_uso";
            this.id_nota_fiscal_uso.HeaderText = "Nota fiscal";
            this.id_nota_fiscal_uso.Name = "id_nota_fiscal_uso";
            this.id_nota_fiscal_uso.ReadOnly = true;
            this.id_nota_fiscal_uso.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.total.DataPropertyName = "subtotal";
            this.total.HeaderText = "total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // txt_placa
            // 
            this.txt_placa.Location = new System.Drawing.Point(18, 94);
            this.txt_placa.Name = "txt_placa";
            this.txt_placa.Size = new System.Drawing.Size(151, 20);
            this.txt_placa.TabIndex = 7;
            // 
            // ck_pegar_horario_final
            // 
            this.ck_pegar_horario_final.AutoSize = true;
            this.ck_pegar_horario_final.Location = new System.Drawing.Point(646, 138);
            this.ck_pegar_horario_final.Name = "ck_pegar_horario_final";
            this.ck_pegar_horario_final.Size = new System.Drawing.Size(103, 17);
            this.ck_pegar_horario_final.TabIndex = 4;
            this.ck_pegar_horario_final.Text = "pegar hora atual";
            this.ck_pegar_horario_final.UseVisualStyleBackColor = true;
            this.ck_pegar_horario_final.CheckedChanged += new System.EventHandler(this.ck_pegar_horario_final_CheckedChanged);
            // 
            // ck_pegar_horario_iniclal
            // 
            this.ck_pegar_horario_iniclal.AutoSize = true;
            this.ck_pegar_horario_iniclal.Location = new System.Drawing.Point(480, 138);
            this.ck_pegar_horario_iniclal.Name = "ck_pegar_horario_iniclal";
            this.ck_pegar_horario_iniclal.Size = new System.Drawing.Size(104, 17);
            this.ck_pegar_horario_iniclal.TabIndex = 3;
            this.ck_pegar_horario_iniclal.Text = "Pegar hora atual";
            this.ck_pegar_horario_iniclal.UseVisualStyleBackColor = true;
            this.ck_pegar_horario_iniclal.CheckedChanged += new System.EventHandler(this.ck_pegar_horario_iniclal_CheckedChanged);
            // 
            // cb_servico
            // 
            this.cb_servico.FormattingEnabled = true;
            this.cb_servico.Location = new System.Drawing.Point(204, 96);
            this.cb_servico.Name = "cb_servico";
            this.cb_servico.Size = new System.Drawing.Size(222, 21);
            this.cb_servico.TabIndex = 2;
            this.cb_servico.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // cb_status
            // 
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Items.AddRange(new object[] {
            "Livre",
            "Ocupado"});
            this.cb_status.Location = new System.Drawing.Point(136, 101);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(132, 21);
            this.cb_status.TabIndex = 1;
            // 
            // cb_vaga
            // 
            this.cb_vaga.FormattingEnabled = true;
            this.cb_vaga.Location = new System.Drawing.Point(22, 101);
            this.cb_vaga.Name = "cb_vaga";
            this.cb_vaga.Size = new System.Drawing.Size(108, 21);
            this.cb_vaga.TabIndex = 0;
            // 
            // btn_update_status_vaga
            // 
            this.btn_update_status_vaga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_status_vaga.Location = new System.Drawing.Point(30, 503);
            this.btn_update_status_vaga.Name = "btn_update_status_vaga";
            this.btn_update_status_vaga.Size = new System.Drawing.Size(277, 57);
            this.btn_update_status_vaga.TabIndex = 5;
            this.btn_update_status_vaga.Text = "Atualizar status da vaga";
            this.btn_update_status_vaga.UseVisualStyleBackColor = true;
            this.btn_update_status_vaga.Click += new System.EventHandler(this.btn_update_status_vaga_Click);
            // 
            // btn_adicionar_uso
            // 
            this.btn_adicionar_uso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar_uso.Location = new System.Drawing.Point(446, 503);
            this.btn_adicionar_uso.Name = "btn_adicionar_uso";
            this.btn_adicionar_uso.Size = new System.Drawing.Size(267, 57);
            this.btn_adicionar_uso.TabIndex = 6;
            this.btn_adicionar_uso.Text = "Adicionar novo uso de vaga ";
            this.btn_adicionar_uso.UseVisualStyleBackColor = true;
            this.btn_adicionar_uso.Click += new System.EventHandler(this.btn_adicionar_uso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "VAGA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "STATUS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "PLACA DO VEICULO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "SERVIÇO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(460, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "HORARIO INICIAL:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(618, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "HORARIO FINAL:";
            // 
            // cb_hora_inicial
            // 
            this.cb_hora_inicial.FormattingEnabled = true;
            this.cb_hora_inicial.Location = new System.Drawing.Point(451, 93);
            this.cb_hora_inicial.Name = "cb_hora_inicial";
            this.cb_hora_inicial.Size = new System.Drawing.Size(50, 21);
            this.cb_hora_inicial.TabIndex = 16;
            // 
            // cb_minuto_inicial
            // 
            this.cb_minuto_inicial.FormattingEnabled = true;
            this.cb_minuto_inicial.Location = new System.Drawing.Point(519, 93);
            this.cb_minuto_inicial.Name = "cb_minuto_inicial";
            this.cb_minuto_inicial.Size = new System.Drawing.Size(60, 21);
            this.cb_minuto_inicial.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(677, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = ":";
            // 
            // cb_minutos_final
            // 
            this.cb_minutos_final.FormattingEnabled = true;
            this.cb_minutos_final.Location = new System.Drawing.Point(689, 92);
            this.cb_minutos_final.Name = "cb_minutos_final";
            this.cb_minutos_final.Size = new System.Drawing.Size(60, 21);
            this.cb_minutos_final.TabIndex = 20;
            // 
            // cb_hora_final
            // 
            this.cb_hora_final.FormattingEnabled = true;
            this.cb_hora_final.Location = new System.Drawing.Point(621, 92);
            this.cb_hora_final.Name = "cb_hora_final";
            this.cb_hora_final.Size = new System.Drawing.Size(50, 21);
            this.cb_hora_final.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(448, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "HORA:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(519, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "MINUTOS:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(689, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "MINUTOS:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(618, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "HORA:";
            // 
            // btn_cancelar_status
            // 
            this.btn_cancelar_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar_status.Location = new System.Drawing.Point(177, 787);
            this.btn_cancelar_status.Name = "btn_cancelar_status";
            this.btn_cancelar_status.Size = new System.Drawing.Size(130, 35);
            this.btn_cancelar_status.TabIndex = 26;
            this.btn_cancelar_status.Text = "CANCELAR";
            this.btn_cancelar_status.UseVisualStyleBackColor = true;
            this.btn_cancelar_status.Visible = false;
            this.btn_cancelar_status.Click += new System.EventHandler(this.btn_cancelar_status_Click);
            // 
            // btn_atualizar_vaga
            // 
            this.btn_atualizar_vaga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_atualizar_vaga.Location = new System.Drawing.Point(30, 787);
            this.btn_atualizar_vaga.Name = "btn_atualizar_vaga";
            this.btn_atualizar_vaga.Size = new System.Drawing.Size(130, 35);
            this.btn_atualizar_vaga.TabIndex = 27;
            this.btn_atualizar_vaga.Text = "CONFIRMAR";
            this.btn_atualizar_vaga.UseVisualStyleBackColor = true;
            this.btn_atualizar_vaga.Visible = false;
            this.btn_atualizar_vaga.Click += new System.EventHandler(this.btn_atualizar_vaga_Click);
            // 
            // btn_confirmar_novo
            // 
            this.btn_confirmar_novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirmar_novo.Location = new System.Drawing.Point(438, 787);
            this.btn_confirmar_novo.Name = "btn_confirmar_novo";
            this.btn_confirmar_novo.Size = new System.Drawing.Size(149, 35);
            this.btn_confirmar_novo.TabIndex = 28;
            this.btn_confirmar_novo.Text = "CONFIRMAR";
            this.btn_confirmar_novo.UseVisualStyleBackColor = true;
            this.btn_confirmar_novo.Visible = false;
            this.btn_confirmar_novo.Click += new System.EventHandler(this.btn_confirmar_novo_Click);
            // 
            // bt_cancelar_novo
            // 
            this.bt_cancelar_novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar_novo.Location = new System.Drawing.Point(608, 787);
            this.bt_cancelar_novo.Name = "bt_cancelar_novo";
            this.bt_cancelar_novo.Size = new System.Drawing.Size(131, 35);
            this.bt_cancelar_novo.TabIndex = 29;
            this.bt_cancelar_novo.Text = "CANCELAR";
            this.bt_cancelar_novo.UseVisualStyleBackColor = true;
            this.bt_cancelar_novo.Visible = false;
            this.bt_cancelar_novo.Click += new System.EventHandler(this.bt_cancelar_novo_Click);
            // 
            // bt_cancelar_correcao
            // 
            this.bt_cancelar_correcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar_correcao.Location = new System.Drawing.Point(608, 848);
            this.bt_cancelar_correcao.Name = "bt_cancelar_correcao";
            this.bt_cancelar_correcao.Size = new System.Drawing.Size(131, 35);
            this.bt_cancelar_correcao.TabIndex = 31;
            this.bt_cancelar_correcao.Text = "CANCELAR";
            this.bt_cancelar_correcao.UseVisualStyleBackColor = true;
            this.bt_cancelar_correcao.Visible = false;
            this.bt_cancelar_correcao.Click += new System.EventHandler(this.bt_cancelar_correcao_Click);
            // 
            // bt_confirmar_correcao
            // 
            this.bt_confirmar_correcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_confirmar_correcao.Location = new System.Drawing.Point(438, 848);
            this.bt_confirmar_correcao.Name = "bt_confirmar_correcao";
            this.bt_confirmar_correcao.Size = new System.Drawing.Size(149, 35);
            this.bt_confirmar_correcao.TabIndex = 30;
            this.bt_confirmar_correcao.Text = "CONFIRMAR";
            this.bt_confirmar_correcao.UseVisualStyleBackColor = true;
            this.bt_confirmar_correcao.Visible = false;
            this.bt_confirmar_correcao.Click += new System.EventHandler(this.bt_confirmar_correcao_Click);
            // 
            // panel_atualizar
            // 
            this.panel_atualizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_atualizar.Controls.Add(this.label1);
            this.panel_atualizar.Controls.Add(this.cb_status);
            this.panel_atualizar.Controls.Add(this.cb_vaga);
            this.panel_atualizar.Controls.Add(this.label2);
            this.panel_atualizar.Location = new System.Drawing.Point(30, 591);
            this.panel_atualizar.Name = "panel_atualizar";
            this.panel_atualizar.Size = new System.Drawing.Size(277, 160);
            this.panel_atualizar.TabIndex = 32;
            this.panel_atualizar.Visible = false;
            // 
            // panel_adicionar_update
            // 
            this.panel_adicionar_update.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_adicionar_update.Controls.Add(this.label11);
            this.panel_adicionar_update.Controls.Add(this.cb_minutos_final);
            this.panel_adicionar_update.Controls.Add(this.label12);
            this.panel_adicionar_update.Controls.Add(this.cb_servico);
            this.panel_adicionar_update.Controls.Add(this.label10);
            this.panel_adicionar_update.Controls.Add(this.ck_pegar_horario_iniclal);
            this.panel_adicionar_update.Controls.Add(this.label9);
            this.panel_adicionar_update.Controls.Add(this.ck_pegar_horario_final);
            this.panel_adicionar_update.Controls.Add(this.label8);
            this.panel_adicionar_update.Controls.Add(this.txt_placa);
            this.panel_adicionar_update.Controls.Add(this.label3);
            this.panel_adicionar_update.Controls.Add(this.cb_hora_final);
            this.panel_adicionar_update.Controls.Add(this.label4);
            this.panel_adicionar_update.Controls.Add(this.label6);
            this.panel_adicionar_update.Controls.Add(this.label5);
            this.panel_adicionar_update.Controls.Add(this.cb_minuto_inicial);
            this.panel_adicionar_update.Controls.Add(this.label7);
            this.panel_adicionar_update.Controls.Add(this.cb_hora_inicial);
            this.panel_adicionar_update.Location = new System.Drawing.Point(313, 591);
            this.panel_adicionar_update.Name = "panel_adicionar_update";
            this.panel_adicionar_update.Size = new System.Drawing.Size(776, 160);
            this.panel_adicionar_update.TabIndex = 33;
            this.panel_adicionar_update.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "status_vaga";
            this.dataGridViewTextBoxColumn2.HeaderText = "status da vaga";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "local_vaga";
            this.dataGridViewTextBoxColumn1.HeaderText = "vaga";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridLivres
            // 
            this.dataGridLivres.AllowUserToAddRows = false;
            this.dataGridLivres.AllowUserToDeleteRows = false;
            this.dataGridLivres.AllowUserToResizeColumns = false;
            this.dataGridLivres.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridLivres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridLivres.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridLivres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLivres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridLivres.Location = new System.Drawing.Point(1095, 41);
            this.dataGridLivres.MultiSelect = false;
            this.dataGridLivres.Name = "dataGridLivres";
            this.dataGridLivres.ReadOnly = true;
            this.dataGridLivres.Size = new System.Drawing.Size(236, 230);
            this.dataGridLivres.TabIndex = 34;
            this.dataGridLivres.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridLivres_CellFormatting);
            // 
            // controle_func
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1428, 927);
            this.Controls.Add(this.dataGridLivres);
            this.Controls.Add(this.panel_adicionar_update);
            this.Controls.Add(this.panel_atualizar);
            this.Controls.Add(this.bt_cancelar_correcao);
            this.Controls.Add(this.bt_confirmar_correcao);
            this.Controls.Add(this.bt_cancelar_novo);
            this.Controls.Add(this.btn_confirmar_novo);
            this.Controls.Add(this.btn_atualizar_vaga);
            this.Controls.Add(this.btn_adicionar_uso);
            this.Controls.Add(this.btn_cancelar_status);
            this.Controls.Add(this.btn_update_status_vaga);
            this.Controls.Add(this.dataGridControle);
            this.Controls.Add(this.btn_corrigir);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "controle_func";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Controle Manual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridControle)).EndInit();
            this.panel_atualizar.ResumeLayout(false);
            this.panel_atualizar.PerformLayout();
            this.panel_adicionar_update.ResumeLayout(false);
            this.panel_adicionar_update.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLivres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_corrigir;
        private System.Windows.Forms.DataGridView dataGridControle;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbl_vaga_id_vaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_vaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_placa_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nota_fiscal_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbl_servico_id_servico;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_inicio_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_final_uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.TextBox txt_placa;
        private System.Windows.Forms.CheckBox ck_pegar_horario_final;
        private System.Windows.Forms.CheckBox ck_pegar_horario_iniclal;
        private System.Windows.Forms.ComboBox cb_servico;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.ComboBox cb_vaga;
        private System.Windows.Forms.Button btn_update_status_vaga;
        private System.Windows.Forms.Button btn_adicionar_uso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_hora_inicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_minutos_final;
        private System.Windows.Forms.ComboBox cb_hora_final;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_minuto_inicial;
        private System.Windows.Forms.Button btn_cancelar_status;
        private System.Windows.Forms.Button btn_atualizar_vaga;
        private System.Windows.Forms.Button btn_confirmar_novo;
        private System.Windows.Forms.Button bt_cancelar_novo;
        private System.Windows.Forms.Button bt_cancelar_correcao;
        private System.Windows.Forms.Button bt_confirmar_correcao;
        private System.Windows.Forms.Panel panel_atualizar;
        private System.Windows.Forms.Panel panel_adicionar_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridLivres;
    }
}