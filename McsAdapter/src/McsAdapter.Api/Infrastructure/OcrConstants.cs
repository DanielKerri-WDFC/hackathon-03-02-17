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

        public static string AcceptValue { get; } = "1234567890"; // todo: update as needed
    }
}
