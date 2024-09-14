using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace SistemaTickets.Data
{
    public class DbContext
    {
        //Função para a tabela
        public static DataTable LoadData(int i, string[] values = null)
        {
            string connectionString = "server=localhost;uid=root;database=sistematickets;password=12345";
            DataTable table = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = values == null ? Querys.QuerySelector(i) : Querys.QueryParamSelector(i, values);

                    MySqlDataAdapter data = new MySqlDataAdapter(query, conn);
                    data.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

            return table;
        }

        //Função para query que retornam somente um valor
        public static string ExecQuery(int i, string[] values = null)
        {
            string connectionString = "server=localhost;uid=root;database=sistematickets;password=12345";
            string resultado = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = values == null ? Querys.QuerySelector(i) : Querys.QueryParamSelector(i, values);

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object valor = cmd.ExecuteScalar();

                    resultado = valor != null && valor != DBNull.Value ? valor.ToString() : " ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            return resultado;
        }
    }
}
