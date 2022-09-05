using Postagem.Blog.Interfaces;
using RedeSocial.Blog;
using System.Collections.Generic;
using System.Linq;

namespace RedeSocial
{
    public class PostManagerInMemory : IPostManager
    {
        private List<Post> _post = new List<Post>();

        public void Cadastrar(Post post)
        {
            _post.Add(post);
        }

        public List<Post> ObterTodos()
        {
            return _post;
        }

        public void Excluir(Post post)
        {
            _post.Remove(post);
        }

        public void AdicionarComentario(Post post, Comment comment)
        {
            post.Comments.Add(comment);
        }

        public List<Post> ObterPostPorUsuario(string userName)
        {
            return _post.Where(x => x.UserName == userName).ToList();
        }
    }
}