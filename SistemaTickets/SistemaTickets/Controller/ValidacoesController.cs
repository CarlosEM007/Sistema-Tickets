using SistemaTickets.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaTickets.Controller
{
    public class ValidacoesController
    {
        public static string ValidaNome(string nome)
        {
            if (nome != null && nome.Length > 3)
            {
                return nome;
            }
            else
            {
                MessageBox.Show("Nome Inválido");
            }
            return null;
        }
        public static string ValidaCPF(string cpf, int refe)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Length == 11 || cpf.Length == 15)
            {
                if (cpf.All(char.IsDigit))
                {
                    
                    string cpfFormatado = $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";

                    if (refe == 0)
                    {
                        return cpfFormatado;
                    }
                    else
                    {
                        return ComparaCPF(cpfFormatado);
                    }
                }
                else
                {
                    MessageBox.Show("O CPF deve conter somente números!");
                }
            }
            else if (!string.IsNullOrEmpty(cpf) && System.Text.RegularExpressions.Regex.IsMatch(cpf, @"\d{3}\.\d{3}\.\d{3}-\d{2}"))
            {
                return cpf; 
            }
            else
            {
                MessageBox.Show("CPF inválido. Deve ter exatamente 11 dígitos.");
            }

            return null;
        }

        public static string ValidaSituacao(string situacao)
        {
            if (situacao == "A" || situacao == "a")
            {
                return situacao.ToUpper();
            }
            else if (situacao == "I" || situacao == "i")
            {
                return situacao.ToUpper();
            }
            else
            {
                MessageBox.Show("Insira um valor válido! (A ou I)");
            }
            return null;
        }
        public static string ValidaIdFunc(string idFunc)
        {
            DataTable valores = DbContext.LoadData(4);

            foreach (DataRow row in valores.Rows)
            {
                if (row["Id"].ToString() == idFunc)
                {
                    return idFunc;
                }
            }
            MessageBox.Show("Id de usuário inexistente");
            return "";
        }
        public static string ValidaQuant(string quantidade)
        {
            try
            {
                int refe = int.Parse(quantidade);
                return quantidade;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Somente valores numéricos: {ex.Message}");
                return "";
            }
        }
        public static string ComparaCPF(string cpf)
        {
            DataTable valores = DbContext.LoadData(5);

            foreach (DataRow row in valores.Rows)
            {
                if (row["CPF"].ToString() == cpf)
                {
                    MessageBox.Show("CPF já cadastrado");
                    return "";
                }
            }
            return cpf;
        }
        

    }
}
