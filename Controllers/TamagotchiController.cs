using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TamagotchiApp.Models;

namespace TamagotchiApp.Controllers
{
    public class TamagotchiController : Controller
    {
      [HttpGet("/tamagotchis")]
       public ActionResult Index()
       {
           List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
           return View(allTamagotchis);
       }

       [HttpGet("/tamagotchis/new")]
       public ActionResult Form()
       {
           return View();
       }

       [HttpPost("/tamagotchis/new")]
       public ActionResult Create()
       {
         Tamagotchi newTamagotchi = new Tamagotchi (Request.Form["name"],1,1,1);
         newTamagotchi.Save();
         List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
         return RedirectToAction("Index");
       }

       [HttpPost("/tamagotchis/food")]
       public ActionResult Feed()
       {
         foreach (Tamagotchi life in Tamagotchi.GetAll())
         {
           life.SetFood(1);
         }
         List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
         return RedirectToAction("Index");
       }
       [HttpGet("/tamagotchis/food/{id}")]
        public ActionResult FeedID(int id)
        {
          Tamagotchi tamagotchi = Tamagotchi.Find(id);
          tamagotchi.SetFood(2);
          List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
          return RedirectToAction("Index");
        }

       [HttpPost("/tamagotchis/play")]
       public ActionResult Play()
       {
         foreach (Tamagotchi life in Tamagotchi.GetAll())
         {
           life.SetPlay(1);
         }
         List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
         return RedirectToAction("Index");
       }

       [HttpGet("/tamagotchis/play/{id}")]
        public ActionResult PlayID(int id)
        {
          Tamagotchi tamagotchi = Tamagotchi.Find(id);
          tamagotchi.SetPlay(2);
          List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
          return RedirectToAction("Index");
        }

       [HttpPost("/tamagotchis/sleep")]
       public ActionResult Sleep()
       {
         foreach (Tamagotchi life in Tamagotchi.GetAll())
         {
           life.SetSleep(1);
         }
         List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
         return RedirectToAction("Index");
       }

       [HttpGet("/tamagotchis/sleep/{id}")]
        public ActionResult SleepID(int id)
        {
          Tamagotchi tamagotchi = Tamagotchi.Find(id);
          tamagotchi.SetSleep(2);
          List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
          return RedirectToAction("Index");
        }

       [HttpPost("/tamagotchis/delete")]
       public ActionResult Delete()
      {
          Tamagotchi.ClearAll();
          return View(Tamagotchi.GetAll());
      }
      [HttpPost("/tamagotchis/delete/{id}")]
      public ActionResult DeleteLife(int id)
      {
         Tamagotchi.ClearLife(id);
         List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
         return View("Delete", allTamagotchis);
      }

    }
}
