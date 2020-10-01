namespace software_estacionamento
{
    partial class FormConsultaVeiculo
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
            this.dataGridVeiculos = new System.Windows.Forms.DataGridView();
            this.placa_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_prop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cor_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVeiculos)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridVeiculos.Location = new System.Drawing.Point(26, 38);
            this.dataGridVeiculos.Name = "dataGridVeiculos";
            this.dataGridVeiculos.Size = new System.Drawing.Size(1193, 74);
            this.dataGridVeiculos.TabIndex = 0;
            this.dataGridVeiculos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.Estado_veiculo.HeaderText = "Estado";
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
            // FormConsultaVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 143);
            this.Controls.Add(this.dataGridVeiculos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConsultaVeiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de veículos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVeiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridVeiculos;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_prop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cor_veiculo;
    }
}