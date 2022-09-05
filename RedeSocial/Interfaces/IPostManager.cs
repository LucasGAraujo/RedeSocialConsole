using RedeSocial.Blog;
using System.Collections.Generic;

namespace Postagem.Blog.Interfaces
{
    public interface IPostManager
    {
        void Cadastrar(Post obj);
        void Excluir(Post obj);
        List<Post> ObterTodos();
        void AdicionarComentario(Post post, Comment comment);
        List<Post> ObterPostPorUsuario(string userName);

    }
}