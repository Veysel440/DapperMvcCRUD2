using Dapper;
using DapperMvcCRUD2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;

namespace DapperMvcCRUD2.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            //return View(DapperORM.ReturnList<PersonelModel>("PersonelViewAll"));
            List<PersonelModel> personelList = (List<PersonelModel>)DapperORM.ReturnList<PersonelModel>("PersonelViewAll");
            //test
            //test 2
            //crud 1
            return View(personelList);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            
            ViewBag.BolumList = DapperORM.ReturnList<BolumModel>("BolumViewAll");

            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PersonelID", id);
                return View(DapperORM.ReturnList<PersonelModel>("PersonelViewByID", param).FirstOrDefault<PersonelModel>());
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(PersonelModel personelModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PersonelID", personelModel.PersonelID);
            param.Add("@Bolumıd", personelModel.BolumID);
            param.Add("@Ad", personelModel.Ad);
            param.Add("@Soyad", personelModel.Soyad);
            param.Add("@DoğumTarihi", personelModel.DoğumTarihi);
            DapperORM.ExecuteWithoutReturn("PersonelAddOrEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PersonelID", id);
            DapperORM.ExecuteWithoutReturn("PersonelDeleteByID", param);
            return RedirectToAction("Index");
        }

        public ActionResult Menu()
        {
            return View();
        }
    }
}

// ... (existing code)

//public class BolumController : Controller
//{
//    // GET: Personel
//    public async Task<ActionResult> Index()
//    {
//        List<BolumModel> bolumList = await WebApiHelper.GetBolumList();
//        return View(bolumList);
//    }

//    [HttpGet]
//    public async Task<ActionResult> AddOrEdit(int id = 0)
//    {
//        ViewBag.BolumList = await WebApiHelper.GetBolumList();
//        if (id == 0)
//            return View();
//        else
//        {
//            List<BolumModel> bolumList = await WebApiHelper.GetBolumList();
//            foreach (var item in bolumList)
//            {
//                if (id == item.BolumID)
//                {
//                    return View(item);
//                }
//            }
//            return View(new BolumModel());
//        }
//    }

//    [HttpPost]
//    public async Task<ActionResult> AddOrEdit(BolumModel bolumModel)
//    {
//        if (BolumModel.BolumID == 0)
//        {
//            bool success = await WebApiHelper.CreateBolum(bolumModel);

//            if (success)
//            {
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
//                return View(bolumModel);
//            }
//        }
//        else
//        {
//            bool success = await WebApiHelper.UpdateBolum(bolumModel.BolumID, bolumModel);

//            if (success)
//            {
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
//                return View(bolumModel);
//            }
//        }
//    }

//    public async Task<ActionResult> Delete(int id)
//    {
//        bool success = await WebApiHelper.Deletebolum(id);

//        if (success)
//        {
//            return RedirectToAction("Index");
//        }
//        else
//        {
//            ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
//            return RedirectToAction("Index");
//        }
//    }
//}
//}




