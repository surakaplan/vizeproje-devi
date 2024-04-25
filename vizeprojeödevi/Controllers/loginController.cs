using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vizeprojeödevi.Models;

namespace vizeprojeödevi.Controllers
{
    public class loginController : Controller
    {
        private YourDbContext _context; // Veritabanı bağlantısı
        public loginController()
        {
            _context = new YourDbContext(); // DbContext nesnesini oluşturun
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Kullanıcı bilgilerini veritabanından çek
            var user = _context.kullanici.FirstOrDefault(u => u.kullaniciadi == username);

            // Kullanıcı bulunamadıysa veya şifre yanlışsa
            if (user == null || user.sifre != password)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                return View("Index");
            }
            else
            {
                // Giriş işlemi başarılı olduğunda yönlendirilecek sayfa
                return RedirectToAction("AnaSayfa", "Home");
            }
        }
}