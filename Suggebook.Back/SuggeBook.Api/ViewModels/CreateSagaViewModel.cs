using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    public class CreateSagaViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public Saga ToModel()
        {
            return new Saga()
            {
                Title = Title
            };
        }
    }
}
