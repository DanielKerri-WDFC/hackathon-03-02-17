using System.Threading.Tasks;
using McsAdapter.Api.Models;
using Microsoft.AspNetCore.Http;

namespace McsAdapter.Api.Services
{
    public interface IOcrService
    {
        Task<string> ReadContent(IFormFile formFile);

        Task<string> ReadContent(string url);
    }
}