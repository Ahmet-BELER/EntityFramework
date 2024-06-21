using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efcoreApp.Controllers
{

    public class KursController : Controller
    {

        private readonly DataContext _context;

        public KursController(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurslar.ToListAsync());
        }


        public async Task<IActionResult> Create()
        {

            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "Ad");
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(Kurs model)
        {

            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }




        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }



            var kurs = await _context
                                    .Kurslar
                                    .AsNoTracking()
                                    .Where(o => o.KursId == id)
                                    .Include(x => x.Ogretmen)
                                    .Include(o => o.KursKayitlari)
                                    .ThenInclude(o => o.Ogrenci)
                                    .FirstOrDefaultAsync();



            if (kurs == null)
            {
                return NotFound();
            }

            return View(kurs);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(int? KursId, Kurs model)
        {
            if (KursId != model.KursId)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();

                }
                catch (System.Exception)
                {

                    throw;
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var kurs = await _context.Kurslar.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();

            }

            _context.Kurslar.Remove(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }



}
