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
using DapperMvcCRUD2.Services;

namespace DapperMvcCRUD2.Controllers
{
    //public class PersonelController : Controller
    //{
    //    // GET: Personel
    //    public ActionResult Index()
    //    {
    //        //return View(DapperORM.ReturnList<PersonelModel>("PersonelViewAll"));
    //        List<PersonelModel> personelList = (List<PersonelModel>)DapperORM.ReturnList<PersonelModel>("PersonelViewAll");
    //        return View(personelList);
    //    }
    //    [HttpGet]
    //    public ActionResult AddOrEdit(int id = 0)
    //    {

    //        ViewBag.BolumList = DapperORM.ReturnList<BolumModel>("BolumViewAll");

    //        if (id == 0)
    //            return View();
    //        else
    //        {
    //            DynamicParameters param = new DynamicParameters();
    //            param.Add("@PersonelID", id);
    //            return View(DapperORM.ReturnList<PersonelModel>("PersonelViewByID", param).FirstOrDefault<PersonelModel>());
    //        }

    //    }
    //    [HttpPost]
    //    public ActionResult AddOrEdit(PersonelModel personelModel)
    //    {
    //        DynamicParameters param = new DynamicParameters();
    //        param.Add("@PersonelID", personelModel.PersonelID);
    //        param.Add("@Bolumıd", personelModel.BolumID);
    //        param.Add("@Ad", personelModel.Ad);
    //        param.Add("@Soyad", personelModel.Soyad);
    //        param.Add("@DoğumTarihi", personelModel.DoğumTarihi);
    //        DapperORM.ExecuteWithoutReturn("PersonelAddOrEdit", param);
    //        return RedirectToAction("Index");
    //    }

    //    public ActionResult Delete(int id)
    //    {
    //        DynamicParameters param = new DynamicParameters();
    //        param.Add("@PersonelID", id);
    //        DapperORM.ExecuteWithoutReturn("PersonelDeleteByID", param);
    //        return RedirectToAction("Index");
    //    }

    //    public ActionResult Menu()
    //    {
    //        return View();
    //    }
    //}
}

// ... (existing code)

public class PersonelController : Controller
{
    // GET: Personel
    public async Task<ActionResult> Index()
    {
        List<PersonelModel> personelList = await WebApiHelper2.GetPersonelList();
        return View(personelList);
    }

    [HttpGet]
    public async Task<ActionResult> AddOrEdit(int id = 0)
    {
        ViewBag.BolumList = await WebApiHelper.GetBolumList();
        if (id == 0)
            return View();
        else
        {
            List<PersonelModel> personelList = await WebApiHelper2.GetPersonelList();
            foreach (var item in personelList)
            {
                if (id == item.PersonelID)
                {
                    return View(item);
                }
            }
            return View(new PersonelModel());
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddOrEdit(PersonelModel personelModel)
    {
        if (personelModel.PersonelID == 0)
        {
            bool success = await WebApiHelper2.CreatePersonel(personelModel);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
                return View(personelModel);
            }
        }
        else
        {
            bool success = await WebApiHelper2.UpdatePersonel(personelModel);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
                return View(personelModel);
            }
        }
    }

    public async Task<ActionResult> Delete(int id)
    {
        bool success = await WebApiHelper2.DeletePersonel(id);

        if (success)
        {
            return RedirectToAction("Index");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
            return RedirectToAction("Index");
        }
    }

    public ActionResult Menu()
    {
        return View();
    }
}




