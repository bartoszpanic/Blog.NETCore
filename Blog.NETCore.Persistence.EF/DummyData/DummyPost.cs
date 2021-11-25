using Blog.NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.NETCore.Persistence.EF.DummyData
{
    public static class DummyPost
    {
        public static List<Post> GetPosts()
        {
            var comments = DummyComment.GetComments();

            Post p1 = new Post()
            {
                PostId = 1,
                Title = "Jak nauczyć się C# w 3 dni?",
                Content = "Trzeba uczyć się bardzo dużo i systematycznie",
                Description = "Aby nauka nie poszła w las",
                ImageUrl = "tinyurl.com/uh9kp3xx",
                //Comments = comments.Where(c => c.PostId == 1).ToList()
            };

            Post p2 = new Post()
            {
                PostId = 2,
                Title = "C# dla początkujących",
                Content = "Dzisiaj krótka lekcja C# dla początkujących którzy chcieli by rozpocząć przygodę z tym oto językiem programowania",
                Description = "C# dla nowych adeptów programowania",
                ImageUrl = "tinyurl.com/uh9kp3xx",
                //Comments = comments.Where(c => c.PostId == 2).ToList()
            };

            Post p3 = new Post()
            {
                PostId = 3,
                Title = "Gotwanie dla opornych",
                Content = "Dzisiaj pokaże wam kuchnię dla ludzi opornych, a co za tym idzie dla leniwych i nie posiadających zmysłu kulinarnego",
                Description = "Gotowanie",
                ImageUrl = "tinyurl.com/3yj4twea",
                //Comments = comments.Where(c => c.PostId == 3).ToList()
            };

            Post p4 = new Post()
            {
                PostId = 4,
                Title = "Dieta cud dla programistów, jedz i chudnij",
                Content = "Dzisiaj pokaże Ci diete dzięki której zgubisz zbędne kilogramy siedząc przed komputerem i pisząc kod",
                Description = "Dieta",
                ImageUrl = "tinyurl.com/3yj4twea",
                //Comments = comments.Where(c => c.PostId == 4).ToList()
            };

            Post p5 = new Post()
            {
                PostId = 5,
                Title = "Najlepsze smartfony 2021 roku",
                Content = "Oprócz kodu i gotowania lubię również elektronikę użytkową, dzisiaj zaprezentuję Ci smartfony które według mnie miały najlepszy stosunek" +
                "jakości do ceny w 2021 roku",
                Description = "Elektronika",
                ImageUrl = "tinyurl.com/fvy9pp7m",
                //Comments = comments.Where(c => c.PostId == 5).ToList()
            };

            List<Post> p = new List<Post>();
            p.Add(p1); p.Add(p2); p.Add(p3); p.Add(p4); p.Add(p5);

            return p;
        }
    }
}
