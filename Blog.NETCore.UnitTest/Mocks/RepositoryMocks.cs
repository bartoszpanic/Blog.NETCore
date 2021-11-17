using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NETCore.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IPostRepository> GetPostRepository()
        {
            var posts = GetPosts();

            var mockPostRepository = new Mock<IPostRepository>();

            mockPostRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(posts);

            mockPostRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var post = posts.FirstOrDefault(c => c.PostId == id);
                return post;
            });

            mockPostRepository.Setup(repo => repo.AddAsync(It.IsAny<Post>())).ReturnsAsync(
                (Post post) =>
                {
                    posts.Add(post);
                    return post;
                });

            mockPostRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Post>())).Callback<Post>((entity) => posts.Remove(entity));

            mockPostRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Post>())).Callback<Post>((entity) =>
            {
                posts.Remove(entity);
                posts.Add(entity);
            });

            return mockPostRepository;
        }

        private static List<Post> GetPosts()
        {
            Post p1 = new Post()
            {
                Title = "Jak nauczyć się C# w 3 dni?",
                Content = "Trzeba uczyć się bardzo dużo i systematycznie",
                Description = "Aby nauka nie poszła w las",
                ImageUrl = "tinyurl.com/uh9kp3xx"
            };

            Post p2 = new Post()
            {
                Title = "C# dla początkujących",
                Content = "Dzisiaj krótka lekcja C# dla początkujących którzy chcieli by rozpocząć przygodę z tym oto językiem programowania",
                Description = "C# dla nowych adeptów programowania",
                ImageUrl = "tinyurl.com/uh9kp3xx"
            };

            Post p3 = new Post()
            {
                Title = "Gotwanie dla opornych",
                Content = "Dzisiaj pokaże wam kuchnię dla ludzi opornych, a co za tym idzie dla leniwych i nie posiadających zmysłu kulinarnego",
                Description = "Gotowanie",
                ImageUrl = "tinyurl.com/3yj4twea"
            };

            Post p4 = new Post()
            {
                Title = "Dieta cud dla programistów, jedz i chudnij",
                Content = "Dzisiaj pokaże Ci diete dzięki której zgubisz zbędne kilogramy siedząc przed komputerem i pisząc kod",
                Description = "Dieta",
                ImageUrl = "tinyurl.com/3yj4twea"
            };

            Post p5 = new Post()
            {
                Title = "Najlepsze smartfony 2021 roku",
                Content = "Oprócz kodu i gotowania lubię również elektronikę użytkową, dzisiaj zaprezentuję Ci smartfony które według mnie miały najlepszy stosunek" +
                "jakości do ceny w 2021 roku",
                Description = "Elektronika",
                ImageUrl = "tinyurl.com/fvy9pp7m"
            };

            List<Post> p = new List<Post>();
            p.Add(p1); p.Add(p2); p.Add(p3); p.Add(p4); p.Add(p5);

            return p;
        }
    }
}
