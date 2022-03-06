using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Domain.Entities;
using Nw.Infra.Context;
using System.Linq;
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
            var northwindContext = nwContext.Products.Include(p => p.Category).Include(p => p.Supplier).OrderByDescending(x=>x.ProductId).ToListAsync();

            return View(await northwindContext);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(nwContext.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(nwContext.Suppliers, "SupplierId", "CompanyName");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,Id")] Products products)
        {
            if (ModelState.IsValid)
            {
                nwContext.Add(products);
                await nwContext.SaveChangesAsync();
                return RedirectToAction(nameof( ProductsRegister));
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await nwContext.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(nwContext.Categories, "CategoryId", "CategoryName", products.CategoryId);
            ViewData["SupplierId"] = new SelectList(nwContext.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

    }
}
