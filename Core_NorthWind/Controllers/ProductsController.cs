using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nw.Infra.Context;
using System.Threading.Tasks;

namespace Core_NorthWind.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NwContext nwContext;
        public ProductsController(NwContext nwContext_)
        {
            nwContext = nwContext_;
        }
        public async Task<IActionResult> ProductsRegister()
        {
            var northwindContext = nwContext.Products.Include(p=>p.Category).Include(p=>p.Supplier).ToListAsync();    

            return View( await northwindContext);
        }    
    }
}
