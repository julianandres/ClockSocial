using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
namespace ClockSocial.Net
{
    public class Mongo<T>
    {
        public interface IMongo
        {
            void loadDocuments(List<T> documents);
            void insertar(int i);
        }
        const String URL_BASE = "https://api.mongolab.com/api/1/databases/";
        HttpClient client;
        String url;
        String apikey;
        public Mongo(String apikey, String dbName, String CollectionName)
        {
            client = new HttpClient();
            this.apikey = "apiKey=" + apikey;
            url = URL_BASE + dbName + "/collections/" + CollectionName + "?" + this.apikey;
        }
        public async void insertDocument(T document,IMongo imongo)
        {
            JsonSerializerSettings property = new JsonSerializerSettings();
            property.NullValueHandling = NullValueHandling.Ignore;
            String json = JsonConvert.SerializeObject(document, Formatting.None, property);
            HttpStringContent content = new HttpStringContent(json);
            HttpMediaTypeHeaderValue contentType = new HttpMediaTypeHeaderValue("application/json");
            content.Headers.ContentType = contentType;
                HttpResponseMessage x = await client.PostAsync(new Uri(url), content);
                if (x.ReasonPhrase.Equals("OK"))
                {
                    MessageBox.Show("El Usuario se agregó correctamente");
                    imongo.insertar(2);
                }
                else {
                    MessageBox.Show("Error al agregar usuario, revise su conexión");
                    imongo.insertar(1);
                }

        }
        public async void  findAllDocuments(IMongo imongo) {

            HttpResponseMessage var = await client.GetAsync(new Uri(url));
            String jsonarray = var.Content.ToString();
            try
            {
                List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonarray);
                imongo.loadDocuments(data);
            }
            catch(Exception e) {
                MessageBox.Show("Error, revise conexión");   
            }
            

        }
    }
}
