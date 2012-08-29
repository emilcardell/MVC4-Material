using System.Linq;
using System.Web.Mvc;
using Raven.Client;
using Store_Front_Base.Data;

namespace Store_Front_Base.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDocumentSession _documentSession;

        public ProductController(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public ActionResult List()
        {
            return Json(_documentSession.Query<Product>().ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Display(string productId)
        {
            return Json(_documentSession.Load<Product>(productId), JsonRequestBehavior.AllowGet);
        }

    }
}
