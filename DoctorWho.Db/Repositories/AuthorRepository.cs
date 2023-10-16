using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        void CreateAuthor(string authorName)
        {
            var author = new Author
            {
                AuthorName = authorName
            };

            _context.Authors.Add(author);
            _context.SaveChanges();

        }
        public Author GetAuthorById(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            return author;
        }
        void UpdateAuthor(int authorId, string newAuthorName)
        {
            var episode = new Episode()
            {
                SeriesNumber = 6,
                EpisodeNumber = 4,
                EpisodeType = "NotRegular",
                Title = "The moon",
                EpisodeDate = DateTime.Now,
            };

            var author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);

            if (author != null)
            {
                author.AuthorName = newAuthorName;
                author.Episodes.Add(episode);
            }

            _context.SaveChanges();
            Console.WriteLine("gone");
        }
        void DeleteAuthor(int authorId)
        {
            var author = _context.Authors
                .Include(a => a.Episodes)
                .FirstOrDefault(a => a.AuthorId == authorId);

            if (author != null)
            {
                _context.Authors.Remove(author);
            }

            _context.SaveChanges();
        }


    }
}
