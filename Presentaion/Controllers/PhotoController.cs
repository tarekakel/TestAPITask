using Contracts.RequestFile;
using Contracts.Shared;
using CoreHtmlToImage;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using Services.Abstractions;
using System.Drawing;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhotoController : ControllerBase
    {
        private IServiceManager _serviceManager { get; }


        public PhotoController(IServiceManager serviceManager)
        {

            _serviceManager = serviceManager;
        }



        [HttpGet]

        public virtual async Task<IActionResult> Get([FromQuery] PageRequestDto pageRequestDto)
        {
            try
            {
                return Ok(await _serviceManager.PhotoService.GetAllAsync(pageRequestDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-photo-by-id/{id}")]

        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _serviceManager.PhotoService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetImage")]
        public virtual IActionResult GetImg([FromQuery] string url)
        {

            return PhysicalFile(url, "image/jpg");
        }


        [HttpGet("GetTemplatPDf")]
        public virtual IActionResult GetTemplatePDf([FromQuery] RequestFileDto requestFileDto)
        {

            var mobileView = new HtmlToPdf();
            var fullView = new HtmlToPdf();
            fullView.Options.PdfPageSize = PdfPageSize.A4;

            StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot\\templates", "template.html"));
            string s = sr.ReadToEnd();
            string newString = s.Replace("{{imagePath}}", requestFileDto.ImagePath).Replace("{{fontSize}}", "font-size:" + requestFileDto.fontSize.ToString() + "px")
                 .Replace("{{contentTitle}}", requestFileDto.ContentTitle).Replace("{{contentText}}", requestFileDto.ContentText);
            sr.Close();
            if (requestFileDto.type == "A4")
            {
                var pdf = fullView.ConvertHtmlString(newString);
                var pdfBytes = pdf.Save();

                return File(pdfBytes, "application/pdf");
            }
            else if (requestFileDto.type == "MobilePdf")
            {
                mobileView.Options.WebPageWidth = 250;
                mobileView.Options.WebPageHeight = 250;
                mobileView.Options.PdfPageSize = PdfPageSize.Custom;
                mobileView.Options.PdfPageCustomSize = new SizeF(Convert.ToInt32(250), Convert.ToInt32(350)); ;
                var pdf = mobileView.ConvertHtmlString(newString);
                var pdfBytes = pdf.Save();

                return File(pdfBytes, "application/pdf");
            }
            else
            {
                var converter = new HtmlConverter();
                var bytes = converter.FromHtmlString(newString);
                return File(bytes, "image/jpg");
            }



        }



        [HttpPost("add-new-download/{photoId}/{typeId}")]
        public virtual async Task<IActionResult> AddNewDownload([FromRoute] int photoId, [FromRoute] int typeId)
        {


            try
            {
                return Ok(await _serviceManager.PhotoDownloadTypeService.UpdateAsync(photoId, typeId));
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
