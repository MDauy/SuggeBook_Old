using System.Configuration;

namespace SuggeBookScrapper
{
    public static class ApiUrls
    {
        private static string BASIC_URL = ConfigurationManager.AppSettings["api_url"];
        public static string LIVRADDICT_BASE_URL = ConfigurationManager.AppSettings["livraddict_base_url"];
        public static string REGISTER_MISSED_AUTHOR = $"{BASIC_URL}{ConfigurationManager.AppSettings["register_missed_author_url"]}";

        public static string CREATE_SAGA = $"{BASIC_URL}{ConfigurationManager.AppSettings["create_saga_url"]}";

        public static string CREATE_AUTHOR = $"{BASIC_URL}{ConfigurationManager.AppSettings["create_author_url"]}";
    }
}
