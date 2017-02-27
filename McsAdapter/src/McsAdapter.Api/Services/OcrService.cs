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
using Microsoft.Extensions.Logging;

namespace McsAdapter.Api.Services
{
    public class OcrService : IOcrService
    {
        private readonly ILogger<OcrService> _ocrServiceLogger;

        public OcrService(ILogger<OcrService> ocrServiceLogger)
        {
            _ocrServiceLogger = ocrServiceLogger;
        }

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

                        if (!response.IsSuccessStatusCode)
                        {
                            _ocrServiceLogger.LogError($"{response.StatusCode} : {response.ReasonPhrase}");
                        }

                        response.EnsureSuccessStatusCode();

                        string result = await response.Content.ReadAsStringAsync();

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                _ocrServiceLogger.LogError(new EventId(), e, "ReadContent(IFormFile formFile) request failure");
                return null;
            }

        }

        public async Task<string> ReadContent(string fileLocationUrl)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    using (Stream fileStream = await httpClient.GetStreamAsync(fileLocationUrl))
                    {
                        httpClient.DefaultRequestHeaders.Add(OcrConstants.AcceptHeader, OcrConstants.AcceptValue);

                        HttpContent httpContent = new ByteArrayContent(fileStream.ToByteArray());

                        httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");

                        HttpResponseMessage response = await httpClient.PostAsync(OcrConstants.EndPoint, httpContent);

                        if (!response.IsSuccessStatusCode)
                        {
                            _ocrServiceLogger.LogError($"{response.StatusCode} : {response.ReasonPhrase}");
                        }

                        response.EnsureSuccessStatusCode();

                        string result = await response.Content.ReadAsStringAsync();

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                _ocrServiceLogger.LogError(new EventId(), e, "ReadContent(string fileLocationUrl) request failure");
                return null;
            }
        }
    }
}
