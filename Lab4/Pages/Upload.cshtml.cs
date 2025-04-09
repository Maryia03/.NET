using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab4.Pages
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }
        private string imagesDir;
        MagickImage watermark;
        public UploadModel(IWebHostEnvironment environment)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
            watermark = new MagickImage("watermark.png");
        }

        public IActionResult OnPost()
        {
            if (Upload != null)
            {
                string extension = ".jpg";
                switch (Upload.ContentType)
                {
                    case "image/png":
                        extension = ".png";
                        break;
                    case "image/gif":
                        extension = ".gif";
                        break;
                }
                var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extension;
                var path = Path.Combine(imagesDir, fileName);
                using var image = new MagickImage(Upload.OpenReadStream());
                // przezroczystosc znaku wodnego
                watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 3);
                // narysowanie znaku wodnego
                image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);
                image.Write(path);
            }
            return RedirectToPage("Index");
        }
        public void OnGet()
        {
        }
    }
}
