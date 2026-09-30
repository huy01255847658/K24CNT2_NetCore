using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HmhBaithuchanh02.Models;
using System.Linq;
using System;

namespace HmhBaithuchanh02.Controllers
{
    public class HmhAccountController : Controller
    {
        public IActionResult Index()
        {
            List<HmhAccount> accounts = new List<HmhAccount>
            {
                new HmhAccount()
                {
                    Id = 1, Name="Hoàng Anh", Email="anh@gmail.com", Phone="0986456789", Address="Hà Nội",
                    Avatar= Url.Content("~/images/HmhAvatar/01.jpg"), Gender=1, Bio="My name is small", Birthday= new DateTime(1998,7,15)
                },
                new HmhAccount()
                {
                    Id = 2, Name="Trường Giang", Email="giang@gmail.com", Phone="0986456789", Address="Hà Nội",
                    Avatar= Url.Content("~/images/HmhAvatar/02.jpg"), Gender=1, Bio="My name is small", Birthday= new DateTime(1998,7,15)
                },
                new HmhAccount()
                {
                    Id = 3, Name="Hoàng Thúy", Email="thuy@gmail.com", Phone="0986456789", Address="Hà Nội",
                    Avatar= Url.Content("~/images/HmhAvatar/03.jpg"), Gender=1, Bio="My name is small", Birthday= new DateTime(1998,7,15)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }

        // Action Profile with Route Name
        [Route("hmh-ho-so-cua-toi", Name = "hmhprofile")]
        public IActionResult Profile(int id)
        {
            List<HmhAccount> accounts = new List<HmhAccount>
            {
                new HmhAccount()
                {
                    Id = 1, Name="Hoàng Anh", Email="anh@gmail.com", Phone="0986456789", Address="Hà Nội",
                    Avatar= Url.Content("~/images/HmhAvatar/01.jpg"), Gender=1, Bio="My name is small", Birthday= new DateTime(1998,7,15)
                },
                new HmhAccount()
                {
                    Id = 2, Name="Trường Giang", Email="giang@gmail.com", Phone="0986456789", Address="Hà Nội",
                    Avatar= Url.Content("~/images/HmhAvatar/02.jpg"), Gender=1, Bio="My name is small", Birthday= new DateTime(1998,7,15)
                },
                new HmhAccount()
                {
                    Id = 3, Name="Hoàng Thúy", Email="thuy@gmail.com", Phone="0986456789", Address="Hà Nội",
                    Avatar= Url.Content("~/images/HmhAvatar/03.jpg"), Gender=1, Bio="My name is small", Birthday= new DateTime(1998,7,15)
                }
            };
            
            HmhAccount account = accounts.FirstOrDefault(ac => ac.Id == id);
            if (account == null)
            {
                account = accounts.FirstOrDefault();
            }
            ViewBag.account = account;
            return View();
        }
    }
}
