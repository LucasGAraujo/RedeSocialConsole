using System;
using System.Xml.Linq;
using Postagem.Blog.Interfaces;
using RedeSocial.Blog;


namespace RedeSocial
{
     class Program
    {
        private static IPostManager manager = new PostManagerInMemory();
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            Console.WriteLine("=========================== BEM AO SISTEMA DE POST ==========================");

            OpcaoMenu option = 0;

            while (menu.IsExit() == false)
            {
                menu.Print();
                option = menu.GetOptions();

                TratarOpcao(option);
            }

        }

        private static void TratarOpcao(OpcaoMenu option)
        {
            switch (option)
            {
                case OpcaoMenu.Cadastrar:
                    CadastrarPost();
                    break;
                case OpcaoMenu.Exibir:
                    ExibirPost();
                    break;
                case OpcaoMenu.Excluir:
                    ExcluirPost();
                    break;
                case OpcaoMenu.Procurar:
                    ProcurarPost();
                    break;
                case OpcaoMenu.Comentario:
                    AdicionarComentario();
                    break;

            }
        }

        private static void AdicionarComentario()
        {
            Console.WriteLine("Digite o usuário para adicionar comentário ao seus posts");
            var username = Console.ReadLine();

            var posts = manager.ObterPostPorUsuario(username);

            Console.WriteLine("Imprimindo Resultado da Busca");

            foreach (var item in posts)
            {
                item.PrintPost();

                Console.WriteLine("Deseja comentar o post? (S/N)");

                string opcao = Console.ReadLine();

                if (opcao == "S")
                {
                    Console.WriteLine("Digite o comentário do Post");
                    var comentario = Console.ReadLine();

                    Console.WriteLine("Digite o usuário que realizou o comentário");
                    var userName = Console.ReadLine();

                    Comment comment = new Comment()
                    {
                        UserName = userName,
                        Text = comentario,
                        PublishDate = DateTime.Now
                    };

                    manager.AdicionarComentario(item, comment);
                }
            }
        }

        private static void ExcluirPost()
        {
            Console.WriteLine("Digite o usuário para excluir o post");
            var username = Console.ReadLine();

            var posts = manager.ObterPostPorUsuario(username);

            Console.WriteLine("Imprimindo Resultado da Busca");

            foreach (var item in posts)
            {
                item.PrintPost();

                Console.WriteLine("Deseja excluir o post? (S/N)");

                string opcao = Console.ReadLine();

                if (opcao == "S")
                {
                    manager.Excluir(item);
                }
            }

        }

        private static void ProcurarPost()
        {
            Console.WriteLine("Digite o usuário para procurar o post");
            var username = Console.ReadLine();

            var posts = manager.ObterPostPorUsuario(username);

            Console.WriteLine("Imprimindo Resultado da Busca");

            foreach (var item in posts)
            {
                item.PrintPost();
            }
        }

        private static void CadastrarPost()
        {
            Post post = new Post();

            Console.WriteLine("Digite o texto do post");
            post.Text = Console.ReadLine();

            Console.WriteLine("Digite o usuário do post");
            post.UserName = Console.ReadLine();

            post.PublishDate = DateTime.Now;

            manager.Cadastrar(post);
        }

        private static void ExibirPost()
        {
            foreach (var item in manager.ObterTodos())
            {
                item.PrintPost();
            }
        }
    }
}
    

