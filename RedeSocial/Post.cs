using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RedeSocial.Blog
{
    public class Post
    {
        public Post()
        {
            this.Comments = new List<Comment>();
        }

        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }
        private int QuantityLike { get; set; }

        public int GetCommentLenght()
        {
            return Comments.Count();
        }

        public void LikePost()
        {
            QuantityLike = QuantityLike + 1;
        }

        public void UnlikePost()
        {
            QuantityLike = QuantityLike - 1;

            if (QuantityLike < 0)
                QuantityLike = 0;
        }

        public void PrintPost()
        {
            Console.WriteLine($"===========================================");
            Console.WriteLine($"Post realizado por {UserName} \t\t Data {PublishDate}");
            Console.WriteLine($"Text: {Text}");

            foreach (var item in Comments)
            {
                Console.WriteLine($"------------------------ Comentarios -----------------");
                Console.WriteLine($"Comentario: {item.Text}");
                Console.WriteLine($"Usuario: {item.UserName}");
                Console.WriteLine($"Data: {item.PublishDate}");
                Console.WriteLine($"---------------------------------------------");
            }

            Console.WriteLine($"Like: {QuantityLike}");
            Console.WriteLine($"===========================================");

        }
    }
}
