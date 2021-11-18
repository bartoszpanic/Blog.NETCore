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
            var comments = GetComments();

            Post p1 = new Post()
            {
                PostId = 1,
                Title = "Jak nauczyć się C# w 3 dni?",
                Content = "Trzeba uczyć się bardzo dużo i systematycznie",
                Description = "Aby nauka nie poszła w las",
                ImageUrl = "tinyurl.com/uh9kp3xx",
                Comments = comments.Where(c => c.PostId == 1).ToList()
            };

            Post p2 = new Post()
            {
                PostId = 2,
                Title = "C# dla początkujących",
                Content = "Dzisiaj krótka lekcja C# dla początkujących którzy chcieli by rozpocząć przygodę z tym oto językiem programowania",
                Description = "C# dla nowych adeptów programowania",
                ImageUrl = "tinyurl.com/uh9kp3xx",
                Comments = comments.Where(c => c.PostId == 2).ToList()
            };

            Post p3 = new Post()
            {
                PostId = 3,
                Title = "Gotwanie dla opornych",
                Content = "Dzisiaj pokaże wam kuchnię dla ludzi opornych, a co za tym idzie dla leniwych i nie posiadających zmysłu kulinarnego",
                Description = "Gotowanie",
                ImageUrl = "tinyurl.com/3yj4twea",
                Comments = comments.Where(c => c.PostId == 3).ToList()
            };

            Post p4 = new Post()
            {
                PostId = 4,
                Title = "Dieta cud dla programistów, jedz i chudnij",
                Content = "Dzisiaj pokaże Ci diete dzięki której zgubisz zbędne kilogramy siedząc przed komputerem i pisząc kod",
                Description = "Dieta",
                ImageUrl = "tinyurl.com/3yj4twea",
                Comments = comments.Where(c => c.PostId == 4).ToList()
            };

            Post p5 = new Post()
            {
                PostId = 5,
                Title = "Najlepsze smartfony 2021 roku",
                Content = "Oprócz kodu i gotowania lubię również elektronikę użytkową, dzisiaj zaprezentuję Ci smartfony które według mnie miały najlepszy stosunek" +
                "jakości do ceny w 2021 roku",
                Description = "Elektronika",
                ImageUrl = "tinyurl.com/fvy9pp7m",
                Comments = comments.Where(c => c.PostId == 5).ToList()
            };

            List<Post> p = new List<Post>();
            p.Add(p1); p.Add(p2); p.Add(p3); p.Add(p4); p.Add(p5);

            return p;
        }

        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = GetComments();
            var mockCommentRepository = new Mock<ICommentRepository>();

            mockCommentRepository.Setup(repo => repo.AddAsync(It.IsAny<Comment>())).ReturnsAsync(
                (Comment comment) =>
                {
                    comments.Add(comment);
                    return comment;
                });

            mockCommentRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Comment>())).Callback<Comment>((entity) => comments.Remove(entity));

            mockCommentRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Comment>())).Callback<Comment>((entity) =>
            {
                comments.Remove(entity);
                comments.Add(entity);
            });

            return mockCommentRepository;
        }

        private static List<Comment> GetComments()
        {
            Comment c1 = new Comment()
            {
                Author = "Kalamaz",
                Content = "Super, daje 5 gwiazdek",
                PostId = 1
            };
            Comment c2 = new Comment()
            {
                Author = "KawowySmakosz",
                Content = "Nie podoba mi się, zalecałbym poprawę",
                PostId = 1
            };
            Comment c3 = new Comment()
            {
                Author = "Samalka",
                Content = "Najlepszy!!",
                PostId = 1
            };
            Comment c4 = new Comment()
            {
                Author = "ElektrykSamouk",
                Content = "Jak łatwo nauczyć się innego języka?",
                PostId = 2
            };
            Comment c5 = new Comment()
            {
                Author = "Lavazza",
                Content = "C# Najlepszy!",
                PostId = 2
            };
            Comment c6 = new Comment()
            {
                Author = "HpLover",
                Content = "Jest to dla mnie najlepsza cześć tego bloga!",
                PostId = 3
            };
            Comment c7 = new Comment()
            {
                Author = "KuchennySmakosz",
                Content = "Nie bierz się za gotowanie, zdecydowanie nie masz o tym pojęcia",
                PostId = 3
            };
            Comment c8 = new Comment()
            {
                Author = "FanGwiezdnychWojen",
                Content = "Super dieta, schudłem już 10 kg!",
                PostId = 4
            };
            Comment c9 = new Comment()
            {
                Author = "UveFD",
                Content = "Wiecej ruchu, a nie diety i każdy z was schudnie",
                PostId = 4
            };
            Comment c10 = new Comment()
            {
                Author = "Omoplata",
                Content = "Mi się podoba, wyprobuję",
                PostId = 4
            };
            Comment c11 = new Comment()
            {
                Author = "LGFan",
                Content = "Dlaczego nie pojawił się LG?",
                PostId = 5
            };

            List<Comment> c = new List<Comment>();
                c.Add(c1); c.Add(c2); c.Add(c3); c.Add(c4); c.Add(c5); c.Add(c6);
                c.Add(c7); c.Add(c8); c.Add(c9); c.Add(c10); c.Add(c11);


            return c;
        }
    }
}
