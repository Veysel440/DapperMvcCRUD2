using Dapper;
using DapperMvcCRUD2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperMvcCRUD2.Controllers
{
    public class SectionController : Controller
    {
        // GET: Section
        public ActionResult Index()
        {
            return View(DapperORM2.ReturnList<SectionModel>("SectionHepsiniGör"));
        }

        [HttpGet]
        public ActionResult Ekle(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param2 = new DynamicParameters();
                param2.Add("@SectionID", id);
                return View(DapperORM2.ReturnList<SectionModel>("SectionGörüntüleme", param2).FirstOrDefault<SectionModel>());

            }
        }
        [HttpPost]
        public ActionResult Ekle(SectionModel sectionModel)
        {
            DynamicParameters param2 = new DynamicParameters();
            param2.Add("@SectionId", sectionModel.SectionID);
            param2.Add("@PersonelID", sectionModel.PersonelID);
            param2.Add("@Name", sectionModel.Name);
            DapperORM2.ExecuteWithoutReturn("SectionEkle", param2);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            DynamicParameters param2 = new DynamicParameters();
            param2.Add("@SectionID", id);
            DapperORM2.ExecuteWithoutReturn("SectionSilme", param2);
            return RedirectToAction("Index");
        }
    }
}