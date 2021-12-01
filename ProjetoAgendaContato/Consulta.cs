using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgendaContato
{
    public partial class Consulta : Form
    {

        cl_Contato cont = new cl_Contato();

        cl_ControleContato controle = new cl_ControleContato();


        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpcao.SelectedIndex == 0)
            {
                try
                {
                    int codigo = Convert.ToInt32(txtOpção.Text);
                    dataGridView1.DataSource = controle.pesquisaCodigo(codigo);
                }

                catch
                {
                    MessageBox.Show("Digite um valor inteiro para código!");
                    txtOpção.Clear();
                    txtOpção.Focus();
                }
            }
            else if (cbOpcao.SelectedIndex == 1)
            {
                string nomecontato = (txtOpção.Text);
                dataGridView1.DataSource = controle.pesquisanome(nomecontato);
            }
            
            else if (cbOpcao.SelectedIndex == 2)
            {
                string tel = (txtOpção.Text);
                dataGridView1.DataSource = controle.pesquisatel(tel);
            }
            else if(cbOpcao.SelectedIndex == 3)
            {
                string cel = (txtOpção.Text);
                dataGridView1.DataSource = controle.pesquisacel(cel);
            }
            else if(cbOpcao.SelectedIndex == 4)
            {
                string email = txtOpção.Text;
                dataGridView1.DataSource = controle.pesquisaemail(email);
            }
        }

        private void cbOpcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbOpcao.SelectedIndex < 0)
            {
                txtOpção.Enabled = false;
                btnBuscar.Enabled = false;
                lblopção.Text = "";
            }
            else
            {
                txtOpção.Enabled = true;
                lblopção.Text = "Digite o " + cbOpcao.Text;
                txtOpção.Clear();
                txtOpção.Focus();
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controle.PreencherTodos();
        }

        private void txtOpção_TextChanged(object sender, EventArgs e)
        {
            if (txtOpção.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }
    }
}
