using System.IO;
using System.Threading.Tasks;

namespace net_core_teste.Services
{
    public interface IComputeVision
    {
        Task<string> TextToImage(MemoryStream file);
    }
}
