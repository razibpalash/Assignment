using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using BusinessEntity = Data.BusinessEntity;

namespace Aero.Controllers
{
    public class BusinessEntitiesController : Controller
    {
        private BusinessEntityServices businessEntityServices = new BusinessEntityServices();
        // GET: BusinessEntities
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBusinessEntity()
        {
            return Json(new { data = businessEntityServices.GetAllBusinessEntity() }, JsonRequestBehavior.AllowGet);
        }
        
        // POST: BusinessEntity/Create
        public JsonResult Create(BusinessEntity aBusinessEntity)
        {
            return Json(businessEntityServices.AddBusinessEntity(aBusinessEntity), JsonRequestBehavior.AllowGet);
        }

        // POST: BusinessEntity/Edit
        public JsonResult Edit(BusinessEntity aBusinessEntity)
        {
            return Json(businessEntityServices.UpdateBusinessEntity(aBusinessEntity), JsonRequestBehavior.AllowGet);
        }

        // GET: BusinessEntity/Details/5
        public JsonResult Details(int id)
        {
            return Json(businessEntityServices.GetBusinessEntity(id), JsonRequestBehavior.AllowGet);
        }

        // POST: BusinessEntity/Delete/5
        public JsonResult Delete(int id)
        {
            return Json(businessEntityServices.DeleteBusinessEntity(id), JsonRequestBehavior.AllowGet);
        }
    }
}