using System.Collections.Generic;

namespace SuggeBookScrapper.JsonObjects
{
    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public List<string> Categories { get; set; }
        public List<IndustryIdentifier> IndustryIdentifiers { get; set; }
    }
}
