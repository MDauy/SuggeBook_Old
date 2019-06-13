using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    public class CreateAuthorViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        public string BabelioId{ get; set; }

        public Author ToModel()
        {
            return new Author
            {
                Firstname =  FirstName,
                Lastname = LastName,
                BabelioId =  BabelioId
            };
        }
    }
}
