using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
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
    public partial class FormRelatorio : Form
    {
        cl_conexao c = new cl_conexao();
        public FormRelatorio()
        {
            InitializeComponent();
        }

        private void FormRelatorio_Load(object sender, EventArgs e)
        {
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone," +
                "celular as Celular, email as Email from tbcontato;";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, c.con);

            DsContatos ds = new DsContatos();
            da.Fill(ds.Tables["tbcontato"]);
            ReportDocument cr = new ReportDocument();
            cr = new cr_Contatos();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            ReportDocument cryRpt = new ReportDocument();
        }
    }
}
