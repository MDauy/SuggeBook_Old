using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Dao.Models
{
    /// <summary>
    /// User tel qu'on voudrait l'afficher sur sa page user
    /// </summary>
    public class User
    {
        public string UserName { get; set; }

        public List<Book> Books { get; set; }

        public List<Suggestion> Suggestions { get; set; }

        public List<Category> FavoriteCategories{ get; set; }
    }
}
