using SistemaTickets.Data;
using System.Data;
using System.Windows;
using SistemaTickets.Controller;

namespace SistemaTickets
{
    public partial class MainWindow : Window
    {
        int tabela;
        public MainWindow()
        {
            InitializeComponent();
            TotalTicket();
            tabela = 1;
        }

        private void TotalTicket()
        {
            CarregarDadosTabela(1, null);
            string valorTotal = DbContext.ExecQuery(3, null);
            ValorTotal.Text = $"Total Tickets: {valorTotal}";
        }

        private void CarregarDadosTabela(int i, string[] valores)
        {
            DataTable table = DbContext.LoadData(i, valores);

            Tabela.ItemsSource = table.DefaultView;
        }

        // Troca para tabela Funcionário
        private void Btn_Func_Click(object sender, RoutedEventArgs e)
        {
            CarregarDadosTabela(1, null);
            tabela = 1;
        }

        // Troca para tabela Ticket
        private void Btn_Ticket_Click(object sender, RoutedEventArgs e)
        {
            CarregarDadosTabela(2, null);
            tabela = 2;
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            MainController.OpenEdit(null, tabela);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainController.OpenAdd(null, tabela);
        }

        private void Tabela_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Tabela.SelectedItem != null)
            {
                DataRowView row = (DataRowView)Tabela.SelectedItem;
                string id = row["Id"].ToString();

                FiltrarPorPessoa(id);
            }
        }

        private void FiltrarPorPessoa(string id)
        {
            string[] Array = { id };
            string valorTotal = DbContext.ExecQuery(1, Array);
            ValorTotal.Text = $"Total Tickets: {valorTotal}";
        }

        private void FiltrarData_Click(object sender, RoutedEventArgs e)
        {
            string dataInicial = DataInicial.SelectedDate.HasValue ? DataInicial.SelectedDate.Value.ToString("yyyy-MM-dd") : "";
            string dataFinal = DataFinal.SelectedDate.HasValue ? DataFinal.SelectedDate.Value.ToString("yyyy-MM-dd") : "";

            string[] array = { dataInicial, dataFinal };

            string valorTotal = DbContext.ExecQuery(3, array);
            ValorTotal.Text = $"Total Tickets: {valorTotal}";
            CarregarDadosTabela(2, array);
            
        }

        private void Tabela_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Tabela.SelectedItem != null)
            {
                DataRowView row = (DataRowView)Tabela.SelectedItem;
                string idref = row["Id"].ToString();

                MainController.OpenEdit(idref, tabela);
            }
        }

        private void Btn_Reload_Click(object sender, RoutedEventArgs e)
        {
            MainWindow novaJanela = new MainWindow();

            novaJanela.WindowState = WindowState.Maximized;

            novaJanela.Show();

            this.Close();
        }

    }
}
