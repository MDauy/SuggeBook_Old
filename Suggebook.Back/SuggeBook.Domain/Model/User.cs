using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Model
{
    public class User : BaseModel
    {
        public string Firstname{ get; set; }
        public string Lastname { get; set; }
        public string Mail{ get; set; }      
        public string UserName { get; set; }
        public List<string> FavoriteCategories { get; set; }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
