using System.Threading.Tasks;

namespace net_core_teste.Services
{
    public interface IContentModerator
    {
        string Text(string text);

        Task<string> Image();
    }
}
