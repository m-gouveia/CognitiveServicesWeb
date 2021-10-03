using Microsoft.AspNetCore.Mvc;
using net_core_teste.Services;
using System.IO;
using System.Threading.Tasks;

namespace net_core_teste.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ModeradorController : ControllerBase
    {
        private IComputeVision _computeVision;
        private IContentModerator _contentModerator;

        public ModeradorController(IComputeVision computeVision, IContentModerator contentModerator)
        {
            _computeVision = computeVision;
            _contentModerator = contentModerator;
        }

        [HttpPost]
        public async Task<string> OCRText()
        {
            var files = Request.Form.Files;

            if (files == null)
                return "Imagem não possui texto";

            using (MemoryStream ms = new MemoryStream())
            {
                await files[0].CopyToAsync(ms);

                ms.Position = 0;

                string textoDaImagem = await _computeVision.TextToImage(ms);

                if (textoDaImagem.Trim().Length > 0)
                {
                    string resultado = _contentModerator.Text(textoDaImagem);

                    return resultado;
                }
            }

            //TODO: Responder em formato JSON
            return "Imagem não possui texto";
        }
    }
}
