using SistemaTickets.Controller;
using SistemaTickets.Data;
using System.Data;
using System.Windows;

namespace SistemaTickets
{
    public partial class Editar : Window
    {
        public int referencia;
        public string pagina;
        string IdEntidade = null;

        public Editar(int referencia, string pagina, string IdEntidade)
        {
            InitializeComponent();
            this.referencia = referencia;
            this.pagina = pagina;
            this.IdEntidade = IdEntidade;
            toTicket();
            EditSpecific(IdEntidade, referencia);
        }

        public void toTicket()
        {
            if (referencia != 1)
            {
                TopValue.Text = "Identificador do Usuário (Id)";
                MiddleValue.Text = "Quantidade";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Text_value.Text = pagina;
         
        }

        private void EditSpecific(string idref, int referencia)
        {
            string[] parametros = { idref };

            if (idref == null)
            {
                ValorNome.Text = "";
                ValorCPF.Text = "";
                ValorAtivo.Text = "";
            } 
            else
            {
                ValorId.Visibility = Visibility.Collapsed;
                IdText.Visibility = Visibility.Collapsed;
            }

            if (referencia == 1 && idref != null) //Valores Funcionario
            {
                DataTable table = DbContext.LoadData(4, parametros);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    string nome = row["Nome"].ToString();
                    string cpf = row["CPF"].ToString();
                    string situacao = row["situacao"].ToString();

                    ValorNome.Text = nome;
                    ValorCPF.Text = cpf;
                    ValorAtivo.Text = situacao;
                }
            }
            else if (referencia == 2 && idref != null) // Valores Ticket
            {
                DataTable table = DbContext.LoadData(5, parametros);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    string idfunc = row["IdFuncionario"].ToString();
                    string quant = row["Quantidade"].ToString();
                    string situacao = row["Situacao"].ToString();

                    ValorNome.Text = idfunc;
                    ValorCPF.Text = quant;
                    ValorAtivo.Text = situacao;
                }
            }
        }

        private void Btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (IdEntidade == null)
            {
                IdEntidade = ValidacoesController.ValidaIdFunc(ValorId.Text);
            }

            if (referencia == 1)
            {
                string Nome = ValidacoesController.ValidaNome(ValorNome.Text);
                string Cpf = ValidacoesController.ValidaCPF(ValorCPF.Text, 0);
                string Situacao = ValidacoesController.ValidaSituacao(ValorAtivo.Text);
                string DtAlteracao = DateTime.Now.ToString("yyyy-MM-dd");

                // Verifica se todos os valores têm conteúdo
                if (!string.IsNullOrWhiteSpace(Nome) &&
                    !string.IsNullOrWhiteSpace(Cpf) &&
                    !string.IsNullOrWhiteSpace(Situacao) &&
                    !string.IsNullOrEmpty(IdEntidade))
                {
                    string[] parametros = { Nome, Cpf, Situacao, DtAlteracao, IdEntidade };
                    DbContext.ExecQuery(6, parametros);
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

                //Verifica se todos os elementos tem valores
                if (!string.IsNullOrWhiteSpace(IdFunc) &&
                    !string.IsNullOrWhiteSpace(Quantidade) &&
                    !string.IsNullOrWhiteSpace(Situacao) &&
                    !string.IsNullOrEmpty(IdEntidade))
                {
                    string[] parametros = { IdFunc, Quantidade, Situacao, DtAlteracao, IdEntidade };
                    DbContext.ExecQuery(7, parametros);
                    MessageBox.Show("Valor atualizado com sucesso!");
                    Close();
                }
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
