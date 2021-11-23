using Blog.NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Persistence.EF.DummyData
{
    public static class DummyComment
    {
        public static List<Comment> GetComments()
        {
            Comment c1 = new Comment()
            {
                CommentId = 1,
                Author = "Kalamaz",
                Content = "Super, daje 5 gwiazdek",
                PostId = 1
            };
            Comment c2 = new Comment()
            {
                CommentId = 2,
                Author = "KawowySmakosz",
                Content = "Nie podoba mi się, zalecałbym poprawę",
                PostId = 1
            };
            Comment c3 = new Comment()
            {
                CommentId = 3,
                Author = "Samalka",
                Content = "Najlepszy!!",
                PostId = 1
            };
            Comment c4 = new Comment()
            {
                CommentId = 4,
                Author = "ElektrykSamouk",
                Content = "Jak łatwo nauczyć się innego języka?",
                PostId = 2
            };
            Comment c5 = new Comment()
            {
                CommentId = 5,
                Author = "Lavazza",
                Content = "C# Najlepszy!",
                PostId = 2
            };
            Comment c6 = new Comment()
            {
                CommentId = 6,
                Author = "HpLover",
                Content = "Jest to dla mnie najlepsza cześć tego bloga!",
                PostId = 3
            };
            Comment c7 = new Comment()
            {
                CommentId = 7,
                Author = "KuchennySmakosz",
                Content = "Nie bierz się za gotowanie, zdecydowanie nie masz o tym pojęcia",
                PostId = 3
            };
            Comment c8 = new Comment()
            {
                CommentId = 8,
                Author = "FanGwiezdnychWojen",
                Content = "Super dieta, schudłem już 10 kg!",
                PostId = 4
            };
            Comment c9 = new Comment()
            {
                CommentId = 9,
                Author = "UveFD",
                Content = "Wiecej ruchu, a nie diety i każdy z was schudnie",
                PostId = 4
            };
            Comment c10 = new Comment()
            {
                CommentId = 10,
                Author = "Omoplata",
                Content = "Mi się podoba, wyprobuję",
                PostId = 4
            };
            Comment c11 = new Comment()
            {
                CommentId = 11,
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
