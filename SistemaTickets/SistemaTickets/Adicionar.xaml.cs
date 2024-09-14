using SistemaTickets.Controller;
using SistemaTickets.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SistemaTickets
{
    /// <summary>
    /// Lógica interna para Adicionar.xaml
    /// </summary>
    public partial class Adicionar : Window
    {
        public int referencia;
        public string pagina;

        public Adicionar(int referencia, string pagina)
        {
            this.referencia = referencia;
            this.pagina = pagina;
            InitializeComponent();
            toTicket();

        }

        public void toTicket()
        {
            if(referencia != 1)
            {
                TopValue.Text = "Identificador do Usuário (Id)";
                MiddleValue.Text = "Quantidade";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Text_value.Text = pagina;
        }

        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
            if (referencia == 1)
            {
                string Nome = ValidacoesController.ValidaNome(ValorNome.Text);
                string Cpf = ValidacoesController.ValidaCPF(ValorCPF.Text, 1);
                string Situacao = ValidacoesController.ValidaSituacao(ValorAtivo.Text);
                string DtAlteracao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                if (!string.IsNullOrWhiteSpace(Nome) &&
                    !string.IsNullOrWhiteSpace(Cpf) &&
                    !string.IsNullOrWhiteSpace(Situacao))
                {
                    string[] parametros = { Nome, Cpf, Situacao, DtAlteracao };
                    DbContext.ExecQuery(8, parametros);
                    MessageBox.Show("Valor atualizado com sucesso!");
                    Close();
                }
            }
            else
            {
                string IdFunc = ValidacoesController.ValidaIdFunc(ValorNome.Text);
                string Quantidade = ValidacoesController.ValidaQuant(ValorCPF.Text);
                string Situacao = ValidacoesController.ValidaSituacao(ValorAtivo.Text);
                string DtAlteracao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                if (!string.IsNullOrWhiteSpace(IdFunc) &&
                    !string.IsNullOrWhiteSpace(Quantidade) &&
                    !string.IsNullOrWhiteSpace(Situacao))
                {
                    string[] parametros = { IdFunc, Quantidade, Situacao, DtAlteracao };
                    DbContext.ExecQuery(9, parametros);
                    MessageBox.Show("Valor atualizado com sucesso!");
                    Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
