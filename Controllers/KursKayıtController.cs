using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efcoreApp.Controllers  
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _context;


        public KursKayitController(DataContext context)
        {
            _context = context;
        }


         

        public IActionResult Index()  
        {
            
            var kayitlar = _context.KursKayıtları
            .Include(x=>x.Ogrenci)
            .Include(x=> x.Kurs).ToList();
            return View(kayitlar);  
        }

   public IActionResult Create()  
        {
            ViewBag.Ogrenciler = new SelectList( _context.Ogrenciler.ToList(), "Id" ,"AdSoyad");
            ViewBag.Kurslar = new SelectList( _context.Kurslar.ToList(), "KursId" ,"Baslik");
            return View();  
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create(KursKayıt model)
         {
            model.KayıtTarihi = DateTime.Now;
            _context.KursKayıtları.Add(model);

            await _context.SaveChangesAsync();

            return RedirectToAction("");

               

         }










    }
}
