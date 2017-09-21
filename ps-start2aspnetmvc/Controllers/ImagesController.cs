using ps_start2aspnetmvc.Data;
using ps_start2aspnetmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ps_start2aspnetmvc.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        ImageStore imageStore = new ImageStore();
        // GET: Images
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(HttpPostedFileBase image)
        {
            if (image != null)
            {
                var imageId = await imageStore.SaveImage(image.InputStream);
                return RedirectToAction("Show", new { id = imageId });
            }

            return View();
        }

        public ActionResult Show(string id)
        {
            var model = new ShowModel()
            {
                Uri = imageStore.GetUri(id)
            };

            return View(model);
        }

    }
}