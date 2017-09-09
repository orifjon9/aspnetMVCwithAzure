using ps_start2aspnetmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ps_start2aspnetmvc.Controllers
{
    public class DocumentController : Controller
    {
        CourseStore courseStore;
        public DocumentController()
        {
            courseStore = new CourseStore();
        }

        // GET: Document
        public ActionResult Index()
        {
            var model = courseStore.GetAllCourses();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert()
        {
            var data = new SimpleData().GetCourses();
            await courseStore.InsertCourses(data);

            return RedirectToAction(nameof(Index));
        }
    }
}