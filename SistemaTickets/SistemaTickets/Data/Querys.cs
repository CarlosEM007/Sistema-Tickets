using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTickets.Data
{
    public class Querys
    {
        public static string QuerySelector(int i)
        {
            switch (i)
            {
                case 1: // Retorna os dados de todos os funcionários
                    return "SELECT * FROM funcionario";
                case 2: // Retorna o valores dos tickets + o nome do Funcionario
                    return "SELECT t.Id, f.Nome, t.Quantidade, t.Situacao, t.DtEntrega FROM ticket t Inner join funcionario f on t.IdFuncionario = f.Id";
                case 3: // Soma do total de tickets
                    return "SELECT SUM(quantidade) FROM ticket";
                case 4:
                    return "SELECT Id from funcionario";
                case 5:
                    return "SELECT CPF from funcionario";
            }
            return "";
        }

        public static string QueryParamSelector(int i, string[] param)
        {
            switch (i)
            {
                case 1:

                    return $"SELECT SUM(quantidade) FROM ticket WHERE IdFuncionario = {param[0]}";
                case 2:

                    return $"SELECT * FROM funcionario Where DtAlteracao >= '{param[0]}' and  DtAlteracao <= '{param[1]}'";

                case 3:
                    string query = "SELECT SUM(quantidade) FROM ticket WHERE 1=1";

                    if (!string.IsNullOrEmpty(param[0]))
                    {
                        query += $" AND DtEntrega >= '{param[0]}'";
                    }

                    if (!string.IsNullOrEmpty(param[1]))
                    {
                        query += $" AND DtEntrega <= '{param[1]}'";
                    }

                    return query;

                case 4:
                    return $"SELECT * FROM funcionario WHERE Id = {param[0]}";

                case 5:
                    return $"SELECT * FROM ticket WHERE Id = {param[0]}";

                case 6:
                    return $"UPDATE funcionario SET Nome = '{param[0]}', CPF = '{param[1]}', situacao = '{param[2]}', DtAlteracao = '{param[3]}' WHERE Id = '{param[4]}'";

                case 7:
                    return $"UPDATE ticket SET IdFuncionario = '{param[0]}', Quantidade = '{param[1]}', situacao = '{param[2]}', DtEntrega = '{param[3]}' WHERE Id = {param[4]}";

                case 8:
                    return $"INSERT INTO funcionario (Nome, CPF, situacao, DtAlteracao) Values ('{param[0]}', '{param[1]}', '{param[2]}', '{param[3]}')";

                case 9:
                    return $"INSERT INTO ticket (IdFuncionario, Quantidade, situacao, DtEntrega) Values ('{param[0]}', '{param[1]}', '{param[2]}', '{param[3]}')";
            }
            return "";
        }
    }
}
