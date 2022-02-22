using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLWithChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Novo();
        }

        private void GravarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Gravar();
        }

        private void Gravar()
        {
            CamadaNegocio.Comissao comissao = this.DataContext as CamadaNegocio.Comissao;
            string errorMessage = string.Empty;

            if (comissao != null)
            {
                comissao.Gravar(out errorMessage);
            }
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Empresa;Data Source=DESKTOP-T60DHDP");
                sqlConnection.Open();
                string Get_Data = "select e.nome Nome, sum(valor) as Total from empregado e, comissao c where e.id = c.id group by Nome";
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = Get_Data;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                var table = ds.Tables[0];
                this.DataTable = table;
            }
            catch
            {
                MessageBox.Show("DataBase Error");
            }
        }

        public object DataTable { get; set; }

    }
}
