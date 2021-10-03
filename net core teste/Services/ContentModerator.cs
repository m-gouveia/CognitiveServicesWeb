using CognitiveServicesFiap.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace net_core_teste.Services
{
    public class ContentModerator : IContentModerator
    {
        private AzureParams _azureParams;
        private string _uriProcessText;
        private string _uriProcessImage;

        public ContentModerator(AzureParams azureParams)
        {
            _azureParams = azureParams;
            _uriProcessText = azureParams.Url + "/contentmoderator/moderate/v1.0/ProcessText/Screen";
            _uriProcessImage = azureParams.Url + "/contentmoderator/moderate/v1.0/ProcessImage/Evaluate";
        }

        public string Text(string text)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _azureParams.Key);

            byte[] byteData = Encoding.UTF8.GetBytes(text);

            using var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            HttpResponseMessage response = client.PostAsync(_uriProcessText, content).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            dynamic jsonretorno = JsonConvert.DeserializeObject(result);

            Newtonsoft.Json.Linq.JArray jTerms = (Newtonsoft.Json.Linq.JArray)jsonretorno.Terms;

            string palavroes = ContadorPalavroes(jTerms);

            TextModerator tMod = new TextModerator
            {
                Palavroes = palavroes,
                TextoDaImagem = jsonretorno.OriginalText
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(tMod);
        }

        public string ContadorPalavroes(Newtonsoft.Json.Linq.JArray terms)
        {
            string retorno = "";

            if (terms != null && ((Newtonsoft.Json.Linq.JArray)terms).Count > 0)
                retorno = $"O texto informado na imagem possui {((Newtonsoft.Json.Linq.JArray)terms).Count} palavroes!! \n";
            else
                retorno = "O texto informado na imagem nao possui palavroes! \n";

            return retorno;
        }

        public async Task<string> Image()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _azureParams.Key);

            //URL da Imagem
            var jsonContent = @"{
                                  'DataRepresentation':'URL',
                                  'Value':'https://istoe.com.br/wp-content/uploads/sites/14/2021/08/mulher-melao-1.jpg'
                                }";

            byte[] byteData = Encoding.UTF8.GetBytes(jsonContent);

            using var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            HttpResponseMessage response = await client.PostAsync(_uriProcessImage, content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
