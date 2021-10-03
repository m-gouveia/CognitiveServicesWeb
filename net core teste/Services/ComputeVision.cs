using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace net_core_teste.Services
{
    public class ComputeVision : IComputeVision
    {
        private readonly AzureParams _azureParams;

        public ComputeVision(AzureParams azureParams)
        {
            _azureParams = azureParams;
        }

        public async Task<string> TextToImage(MemoryStream myfile)
        {
            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(_azureParams.Key));
            client.Endpoint = _azureParams.Url;

            var result = await client.RecognizePrintedTextInStreamAsync(false, myfile);

            //result.Wait();

            //var rst = result.Result;

            StringBuilder retorno = new StringBuilder();

            foreach (var r in result.Regions)
            {
                foreach (var t in r.Lines)
                {
                    foreach (var w in t.Words)
                    {
                        retorno.Append($" {w.Text}");
                    }
                }
            }

            return retorno.ToString().Trim();
        }
    }
}
