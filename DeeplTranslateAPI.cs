using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace C_Sharp_TranslateCUI
{
    public class DeeplTranslateAPI
    {

        public static DeeplTranslateAPI GetAPI(string word)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api-free.deepl.com/v2/translate";
                string apiKey = "";
                client.DefaultRequestHeaders.Add("Authorization", $"DeepL-Auth-Key {apiKey}");
                Dictionary<string, string> form = new Dictionary<string, string> {
                    { "text", word },
                    { "target_lang", "JA" }
                };
                HttpContent content = new FormUrlEncodedContent(form);
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    DeeplTranslateAPI? weather = JsonConvert.DeserializeObject<DeeplTranslateAPI>(json);
                    return weather;
                }
            }
            return null;
        }

        public Translation[] translations { get; set; }

        public class Translation
        {
            public String text { get; set; }
            public String target_lang { get; set; }
        }
    }
}
