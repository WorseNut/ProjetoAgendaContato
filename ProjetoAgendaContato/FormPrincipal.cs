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
    public partial class FormPrincipal : Form
    {

        cl_ControleContato controle = new cl_ControleContato();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.ShowDialog();
            
            cl_conexao c = new cl_conexao();
            MessageBox.Show(c.conectar());
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastro cadastro = new FormCadastro();
            cadastro.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta consultar = new Consulta();
            consultar.ShowDialog();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(controle.Backup("C:\\Backup"), "Backup do Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void restauraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
               // OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "sql files (*.sql)|*.sql|All files(*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string CaminhoBackup = openFileDialog1.FileName;
                    MessageBox.Show(controle.Retore(CaminhoBackup), "Restauração do BD",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
        }

        private void rélatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRelatorio relatorio = new FormRelatorio();
            relatorio.Show();
        }
    }
}
