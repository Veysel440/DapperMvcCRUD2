using Dapper;
using DapperMvcCRUD2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static WebApiHelper;

namespace DapperMvcCRUD2.Controllers
{

    public class BolumController : Controller
    {
        // GET: Personel
        public async Task<ActionResult> Index()
        {
            List<BolumModel> bolumList = await WebApiHelper.GetBolumList();
            return View(bolumList);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                List<BolumModel> bolumList = await WebApiHelper.BolumList();
                foreach (var item in bolumList)
                {
                    if (id == item.BolumID)
                    {
                        return View(item);
                    }
                }
                return View();
            }
        }

        [HttpPost]


        public async Task<ActionResult> AddOrEdit(BolumModel bolumModel)
        {
            if (bolumModel.BolumID == 0)
            {
                bool success = await WebApiHelper.CreateBolum(bolumModel);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
                    return View(bolumModel);
                }
            }
            else
            {
                bool success = await WebApiHelper.UpdateBolum(bolumModel);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error communicating with the Web API.");
                    return View(bolumModel);
                }
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            bool success = await WebApiHelper.DeleteBolum(id);

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
    }
    //public class BolumController : Controller
    //{
    //    BolumModel b = new BolumModel();
       
    //    private readonly BolumApiClient _bolumApiClient;

    //    public BolumController()
    //    {
    //        _bolumApiClient = new BolumApiClient("https://localhost:44385/api/");
    //    }
        //public ActionResult Index()
        //{
        //    return View(DapperORM.ReturnList<BolumModel>("BolumViewAll"));
        //}

        //[HttpGet]
        //public ActionResult AddOrEdit(int id = 0)
        //{
        //    if (id == 0)
        //        return View();
        //    else
        //    {
        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@BolumID", id);
        //        return View(DapperORM.ReturnList<BolumModel>("BolumViewByID", param).FirstOrDefault<BolumModel>());

        //    }
        //}
        //[HttpPost]
        //public ActionResult AddOrEdit(BolumModel BolumModel)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@BolumID", BolumModel.BolumID);
        //    param.Add("@BolumAd", BolumModel.BolumAd);
        //    DapperORM.ExecuteWithoutReturn("BolumAddOrEdit", param);
        //    return RedirectToAction("Index");
        //}
        //public ActionResult Delete(int id)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@BolumID", id);
        //    DapperORM.ExecuteWithoutReturn("BolumDeleteByID", param);
        //    return RedirectToAction("Index");
        //}
        //public async Task<ActionResult> Index2()
        //{
        //    var bolum = await _bolumApiClient.GetBolumByIdAsync(1);

        //    return View(bolum);
        //}

    //}
}

