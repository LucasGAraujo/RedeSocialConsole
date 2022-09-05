using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial
{

    public enum OpcaoMenu
    {
        Cadastrar = 1,
        Exibir = 2,
        Excluir = 3,
        Procurar = 4,
        Comentario = 5,
        Sair = 6,
        Invalido = -1

    }

    public class Menu
    {

        private bool Exit { get; set; }

        public void Print()
        {
            Console.WriteLine("1 - Cadastrar Post");
            Console.WriteLine("2 - Exibir Post");
            Console.WriteLine("3 - Excluir Post");
            Console.WriteLine("4 - Procurar Post");
            Console.WriteLine("5 - Comentar Postagem");
            Console.WriteLine("6 - Sair");
        }

        public OpcaoMenu GetOptions()
        {
            OpcaoMenu option;
            int optionTemp;

            if (int.TryParse(Console.ReadLine(), out optionTemp) == false)
            {
                option = OpcaoMenu.Invalido;
                Console.WriteLine("Opção Invalida, Tente novamente");
            }


            if (optionTemp == 6)
            {
                Exit = true;
                option = OpcaoMenu.Sair;
            }

            option = (OpcaoMenu)optionTemp;

            return option;
        }

        public bool IsExit()
        {
            return Exit;
        }


    }
}