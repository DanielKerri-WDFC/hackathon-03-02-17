using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using McsAdapter.Api.Services;
using System.Threading.Tasks;
using McsAdapter.Api.Models;
using Microsoft.AspNetCore.Http;

namespace McsAdapter.Api.Controllers
{
    [Route("Ocr")]
    public class OcrController : Controller
    {
        private readonly IOcrService _ocrService;

        public OcrController(IOcrService ocrService)
        {
            _ocrService = ocrService;
        }
        
        [HttpPost]
        public async Task<IActionResult> NewRequest()
        {
            if (Request.Form?.Files?.Any() != true)
            {
                return BadRequest("File to read is missing");
            }

            IFormFile file = Request.Form.Files.First();

            string ocrContent = await _ocrService.ReadContent(file);

            if (string.IsNullOrWhiteSpace(ocrContent))
            {
                return NoContent();
            }

            return Content(ocrContent);
        }

        [HttpPost("v2")]
        public async Task<IActionResult> NewRequestFormUrlEncoded(OcrBindingModel ocrBindingModel)
        {
            return await NewRequest(ocrBindingModel);
        }

        [HttpPost("v3")]
        public async Task<IActionResult> NewRequestJson([FromBody]OcrBindingModel ocrBindingModel)
        {
            return await NewRequest(ocrBindingModel);
        }

        private async Task<IActionResult> NewRequest(OcrBindingModel ocrBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ocrBindingModel);
            }

            string ocrContent = await _ocrService.ReadContent(ocrBindingModel.Url);

            if (string.IsNullOrWhiteSpace(ocrContent))
            {
                return NoContent();
            }

            return Content(ocrContent);
        }
    }
}
