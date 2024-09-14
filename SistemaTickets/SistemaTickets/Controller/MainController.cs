using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTickets.Controller
{
    public class MainController
    {
        public static void OpenEdit(string idref, int tabela)
        {
            Editar edit;
            if (idref == null)
            {
                if (tabela == 1)
                {
                    edit = new(tabela, "Editar Funcionário", null);
                }
                else
                {
                    edit = new(tabela, "Editar Ticket", null);
                }
            }
            else
            {
                if (tabela == 1)
                {
                    edit = new(tabela, "Editar Funcionário", idref);
                }
                else
                {
                    edit = new(tabela, "Editar Ticket", idref);
                }
            }

            edit.Show();
        }

        public static void OpenAdd(string idref, int tabela)
        {
            Adicionar add;
            {
                if (tabela == 1)
                {
                    add = new(tabela, "Adicionar Funcionário");
                }
                else
                {
                    add = new(tabela, "Adicionar Ticket");
                }
            }
            add.Show();
        }
    }
}
