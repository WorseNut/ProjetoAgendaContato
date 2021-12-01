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
    public partial class FormCadastro : Form
    {
            cl_Contato cont = new cl_Contato();
            cl_ControleContato controle = new cl_ControleContato();


        public FormCadastro()
        {
            InitializeComponent();
        }

        private void limpar()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
            txtNome.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            {
                MessageBox.Show("Forneça um nome:");
            }
            else
            {
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.cadastrar(cont));
                limpar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text == "") 
            {
                MessageBox.Show("Informe o código desejado!");
            
            }
            else
            {
                cont.Codcontato = int.Parse(txtCodigo.Text);
                txtCodigo.Clear();
                MessageBox.Show(controle.excluir(cont));
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                cont.Codcontato = int.Parse(txtCodigo.Text);
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;
                MessageBox.Show(controle.Alterar(cont));
                limpar();
            }
            catch
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cont = controle.buscar(int.Parse(txtCodigo.Text));

                if (cont is null)
                {
                    MessageBox.Show("Não foi encontrado registro com o código informado!");
                    limpar();
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
                else
                {
                    txtCodigo.Text = cont.Codcontato.ToString();
                    txtNome.Text = cont.Nome;
                    txtEmail.Text = cont.Email;
                    txtTelefone.Text = cont.Telefone;
                    txtCelular.Text = cont.Celular;
                    txtEmail.Text = cont.Email;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
    
}
