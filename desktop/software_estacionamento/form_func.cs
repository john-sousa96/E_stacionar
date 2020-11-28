using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace software_estacionamento
{
    public partial class form_func : Form
    {
        public form_func()
        {
            InitializeComponent();
        }
        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menu_relatorio_item_Click(object sender, EventArgs e)
        {
            Form Form_Relatorio = Application.OpenForms["form_relatorio_func"];
            if (Form_Relatorio != null)
            {
                Form_Relatorio.BringToFront();
            }
            else
            {
                form_relatorio_func frm = new form_relatorio_func();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menu_reservas_item_Click(object sender, EventArgs e)
        {
            Form Form_Reserva = Application.OpenForms["reservas_func"];
            if (Form_Reserva != null)
            {
                Form_Reserva.BringToFront();
            }
            else
            {
                reservas_func frm = new reservas_func();
                frm.MdiParent = this;
                frm.Show();
            }

           
        }

        private void menu_controle_item_Click(object sender, EventArgs e)
        {
            Form Form_Controle = Application.OpenForms["controle_func"];
            if (Form_Controle != null)
            {
                Form_Controle.BringToFront();
            }
            else
            {
                controle_func frm = new controle_func();
                frm.MdiParent = this;
                frm.Show();
            }

           
        }
    }
}
