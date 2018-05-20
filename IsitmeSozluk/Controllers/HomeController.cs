using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IsitmeSozluk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsitmeSozluk.Controllers
{
    public class HomeController : Controller
    {
        private ISozlukRepository sozlukRepository;

        public HomeController(ISozlukRepository _sozlukRepository)
        {
            sozlukRepository = _sozlukRepository;
        }

        public IActionResult Index()
        {
            return View(sozlukRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Sozluk());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Sozluk sozluk, IFormFile file)
        {
            var _sozluk = new Sozluk();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _sozluk.Name = sozluk.Name;
            _sozluk.Media = file.FileName;

            //FileInfo fileInfo = new FileInfo(file.FileName);
            //fileInfo.Delete();

            sozlukRepository.AddSozluk(_sozluk);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult See(int id)
        {
            return View(sozlukRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(sozlukRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Sozluk sozluk, IFormFile file)
        {
            var setSozluk = sozlukRepository.GetById(sozluk.Id);

            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", sozluk.Media);

                FileInfo fileInfo = new FileInfo(path);
                fileInfo.Delete();
                setSozluk.Media = file.FileName;

                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            setSozluk.Name = sozluk.Name;
            sozlukRepository.Update(setSozluk);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var sozluk = sozlukRepository.GetById(id);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", sozluk.Media);

            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete();

            sozlukRepository.Delete(id);

            return RedirectToAction("Index");
        }

        public JsonResult GetByName(string name)
        {
            return Json(sozlukRepository.GetByName(name));
        }
    }
}