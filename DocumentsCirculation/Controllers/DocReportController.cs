﻿using DocumentsCirculation.DAO;
using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentsCirculation.Controllers
{
    public class DocReportController : Controller
    {
        DocReportDAO docreport = new DocReportDAO();
        AdministrationDAO admin = new AdministrationDAO();

        // GET: DocReport
        public ActionResult DocReportIndex()
        {
            return View(docreport.GetAllReports());
        }

        // GET: DocReport/Details/5
        public ActionResult DocReportDetails(int id)
        {
            List<DocumentReport> drList = docreport.GetAllReports();
            int pos = 0;
            for (int i = 0; i < drList.Count; i++)
                if (id == drList[i].documentID)
                {
                    pos = i;
                }
            return View(drList[pos]);
        }

        // GET: DocReport/Create
        public ActionResult DocReportCreate()
        {
            return View();
        }

        // POST: DocReport/Create
        [HttpPost]
        public ActionResult DocReportCreate(DocumentReport dr)
        {
            try
            {
                if (docreport.AddReport(dr))
                    return RedirectToAction("DocReportIndex");
                else return View("DocReportCreate");
            }
            catch
            {
                return View("DocReportCreate");
            }
        }

        // GET: DocReport/Edit/5
        public ActionResult DocReportEdit(int id)
        {
            List<DocumentReport> drList = docreport.GetAllReports();
            int pos = 0;
            for (int i = 0; i < drList.Count; i++)
                if (id == drList[i].documentID)
                {
                    pos = i;
                }
            return View(drList[pos]);
        }

        // POST: DocReport/Edit/5
        [HttpPost]
        public ActionResult DocReportEdit(int id, DocumentReport dr)
        {
            try
            {
                if (docreport.ChangeReport(id,dr))
                    return RedirectToAction("DocReportIndex");
                else return View("DocReportEdit");
            }
            catch
            {
                return View("DocReportEdit");
            }
        }

        // GET: DocReport/Delete/5
        public ActionResult DocReportDelete(int id)
        {
            List<DocumentReport> drList = docreport.GetAllReports();
            int pos = 0;
            for (int i = 0; i < drList.Count; i++)
                if (id == drList[i].documentID)
                {
                    pos = i;
                }
            return View(drList[pos]);
        }

        // POST: DocReport/Delete/5
        [HttpPost]
        public ActionResult DocReportDelete(int id, FormCollection collection)
        {
            try
            {
                if (admin.DropDoc(id))
                    return RedirectToAction("DocReportIndex");
                else return View("DocReportDelete");
            }
            catch
            {
                return View("DocReportDelete");
            }
        }
    }
}
