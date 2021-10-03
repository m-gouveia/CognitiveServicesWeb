using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_teste.Models;
using System.Diagnostics;

namespace net_core_teste.Controllers
{
    public class HomeController : Controller
    {
        ////Define uma instância de IHostingEnvironment
        //IHostingEnvironment _appEnvironment;
        ////Injeta a instância no construtor para poder usar os recursos
        //public HomeController(IHostingEnvironment env)
        //{
        //    _appEnvironment = env;
        //}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //Retorna a View Index.cshtml que será o formulário para
        //selecionar os arquivos a serem enviados 
        //public IActionResult Index()
        //{
        //    return View();
        //}

        ////método para enviar os arquivos usando a interface IFormFile
        //public async Task<IActionResult> EnviarArquivo(List<IFormFile> arquivos)
        //{
        //    long tamanhoArquivos = arquivos.Sum(f => f.Length);
        //    // caminho completo do arquivo na localização temporária
        //    var caminhoArquivo = Path.GetTempFileName();
        //    // processa o arquivo enviado

        //    //percorre a lista de arquivos selecionados
        //    foreach (var arquivo in arquivos)
        //    {
        //        //verifica se existem arquivos 
        //        if (arquivo == null || arquivo.Length == 0)
        //        {
        //            //retorna a viewdata com erro
        //            ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
        //            return View(ViewData);
        //        }

        //        // < define a pasta onde vamos salvar os arquivos >
        //        string pasta = "Arquivos_Usuario";
        //        // Define um nome para o arquivo enviado incluindo o sufixo obtido de milesegundos
        //        string nomeArquivo = "Usuario_arquivo_" + DateTime.Now.Millisecond.ToString();

        //        //verifica qual o tipo de arquivo : jpg, gif, png, pdf ou tmp
        //        if (arquivo.FileName.Contains(".jpg"))
        //            nomeArquivo += ".jpg";
        //        else if (arquivo.FileName.Contains(".gif"))
        //            nomeArquivo += ".gif";
        //        else if (arquivo.FileName.Contains(".png"))
        //            nomeArquivo += ".png";
        //        else if (arquivo.FileName.Contains(".pdf"))
        //            nomeArquivo += ".pdf";
        //        else
        //            nomeArquivo += ".tmp";

        //        //< obtém o caminho físico da pasta wwwroot >
        //        string caminho_WebRoot = _appEnvironment.WebRootPath;
        //        // monta o caminho onde vamos salvar o arquivo :  ~\wwwroot\Arquivos\Arquivos_Usuario\Recebidos
        //        string caminhoDestinoArquivo = caminho_WebRoot + "\\Arquivos\\" + pasta + "\\";
        //        // incluir a pasta Recebidos e o nome do arquiov enviado : ~\wwwroot\Arquivos\Arquivos_Usuario\Recebidos\
        //        string caminhoDestinoArquivoOriginal = caminhoDestinoArquivo + "\\Recebidos\\" + nomeArquivo;

        //        //copia o arquivo para o local de destino original
        //        using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
        //        {
        //            await arquivo.CopyToAsync(stream);
        //        }
        //    }

        //    //monta a ViewData que será exibida na view como resultado do envio 
        //    ViewData["Resultado"] = $"{arquivos.Count} arquivos foram enviados ao servidor, " +
        //     $"com tamanho total de : {tamanhoArquivos} bytes";

        //    //retorna a viewdata
        //    return View(ViewData);
        //}
    }
}
