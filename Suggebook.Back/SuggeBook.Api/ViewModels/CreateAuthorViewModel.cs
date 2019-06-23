using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    public class CreateAuthorViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
