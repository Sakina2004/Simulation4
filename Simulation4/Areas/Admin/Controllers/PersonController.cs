using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Simulation4.DataAccessLayer;
using Simulation4.ViewModel.PersonViewModel;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using Simulation4.Models;
using NuGet.Packaging.Signing;
using Simulation4.ViewModel.PositionViewModel;

namespace Simulation4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController(AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var persons = await _context.Persons.Select(x => new PersonGetVm
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                Words = x.Words,
                PositionId = x.PositionId,
            }).ToListAsync();
            return View(persons);
        }
        public async Task<IActionResult> Create()
        {
            await ViewBags();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonCreateVm vm)
        {
            await ViewBags();
            if (!ModelState.IsValid) return View(vm);

            if (vm.Image.Length * 1024 * 1024 > 2)
            {
                ModelState.AddModelError("ImageFile", "Shekilin olchusu max 2kb olmalidir!");

            }
            if (!vm.Image.ContentType.StartsWith("image"))
            {
                ModelState.AddModelError("ImageFile", "Datanin shekil formatinda olduguna diqqet edek!");

            }
            string filename = Guid.NewGuid().ToString() + vm.Image.FileName;
            string path = Path.Combine("wwwroot", "imgs", filename);
            using FileStream stream = new(path, FileMode.OpenOrCreate);
            await vm.Image.CopyToAsync(stream);
            Person person = new()
            {
                Name = vm.Name,
                ImagePath = filename,
                Words = vm.Words,
                PositionId = vm.PositionId,

            };
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id < 1) return BadRequest();
            var entity = await _context.Persons.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (entity == 0) return NotFound();
            return RedirectToAction(nameof(Index));
        }
        private async Task ViewBags()
        {
            var positions = await _context.Positions.Select(x => new PositionGetVm()
            {
               Id= x.Id,
               Name= x.Name,
            }).ToListAsync();
            ViewBag.Positions = positions;
        }
        public async Task<IActionResult>Update(int? id)
        {
            await ViewBags();
            if (!id.HasValue)
                return BadRequest();
        }
    }
}
