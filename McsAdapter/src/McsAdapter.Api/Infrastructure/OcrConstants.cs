using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McsAdapter.Api.Infrastructure
{
    public static class OcrConstants
    {
        public static string EndPoint { get; } = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr";

        public static string AcceptHeader { get; } = "Ocp-Apim-Subscription-Key";

        public static string AcceptValue { get; } = "55b5b552735540319888a389ebb6bf1f";
    }
}
