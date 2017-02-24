using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using McsAdapter.Api.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace McsAdapter.Api.Services
{
    public class OcrService : IOcrService
    {
        public async Task<string> ReadContent(IFormFile formFile)
        {
            try
            {
                using (Stream fileStream = formFile.OpenReadStream())
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Add(OcrConstants.AcceptHeader, OcrConstants.AcceptValue);

                        HttpContent httpContent = new ByteArrayContent(fileStream.ToByteArray());

                        httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");

                        HttpResponseMessage response = await httpClient.PostAsync(OcrConstants.EndPoint, httpContent);

                        string result = await response.Content.ReadAsStringAsync();
                        
                        response.EnsureSuccessStatusCode();

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e);
            }

        }

        

        public async Task<string> ReadContent(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    using (Stream stream = await httpClient.GetStreamAsync(url))
                    {
                        httpClient.DefaultRequestHeaders.Add(OcrConstants.AcceptHeader, OcrConstants.AcceptValue);

                        HttpContent httpContent = new ByteArrayContent(stream.ToByteArray());

                        httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");

                        HttpResponseMessage response = await httpClient.PostAsync(OcrConstants.EndPoint, httpContent);

                        string result = await response.Content.ReadAsStringAsync();

                        response.EnsureSuccessStatusCode();

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message, e);
            }
        }
    }
}
