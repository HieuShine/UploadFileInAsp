using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using uploadFile.Models;

namespace uploadFile.Controllers
{
    public class tailieudinhkemsController : Controller
    {
        private Models.DbContext db = new Models.DbContext();
        private List<hrefFile> hrefFiles = new List<hrefFile>();
        // GET: tailieudinhkems
        public ActionResult Index()
        {
            return View(db.tailieudinhkems.ToList());
        }

        // GET: tailieudinhkems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tailieudinhkem tailieudinhkem = db.tailieudinhkems.Find(id);
            if (tailieudinhkem == null)
            {
                return HttpNotFound();
            }
            return View(tailieudinhkem);
        }

        // GET: tailieudinhkems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tailieudinhkems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tailieudinhkem tailieudinhkem, HttpPostedFileBase DuongDanFile, HttpPostedFileBase filePDF)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (DuongDanFile != null)
                    {
                        var allowExtension = new[] { ".jpg", ".jpeg" };

                        string morong = Path.GetExtension(DuongDanFile.FileName).ToLower();          //llaaysteen file mở rộng (pdf, jpeg)
                        if (allowExtension.Contains(morong))
                        {
                            string ten = Path.GetFileNameWithoutExtension(DuongDanFile.FileName); //lấy file name
                            string nameFile = ten + DateTime.Now.ToString("yyMMddmmssfff") + morong; //cách để ko bị đè file
                            DuongDanFile.SaveAs(Path.Combine(Server.MapPath("~/Upload"), nameFile));
                            tailieudinhkem.DuongDan = nameFile;
                        }
                        else
                        {
                            //TempData["err"] = "Chỉ được tải tệp word, pdf, jpg";
                            //return View(tailieudinhkem);
                            throw new Exception("Tệp ảnh không hợp lệ, vui lòng kiểm tra lại");
                        }


                    }
                    if (filePDF != null)
                    {
                        var allowExtension = new[] { ".doc", ".docx", ".pdf", ".jpg", ".jpeg" };

                        string morong = Path.GetExtension(filePDF.FileName);          //llaaysteen file mở rộng (pdf, jpeg)
                        if (allowExtension.Contains(morong))
                        {
                            string ten = Path.GetFileNameWithoutExtension(filePDF.FileName); //lấy file name
                            string nameFile = ten + morong; //cách để ko bị đè file
                            var path = Path.Combine(Server.MapPath("~/Upload"), nameFile);
                            filePDF.SaveAs(path);

                            tailieudinhkem.filePdf = nameFile;

                        }
                        else
                        {
                            //TempData["err"] = "Chỉ được tải tệp word, pdf, jpg";
                            //return View(tailieudinhkem);
                            throw new Exception("Tệp thư mục không hợp lệ, vui lòng kiểm tra lại");
                        }

                    }
                    db.tailieudinhkems.Add(tailieudinhkem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


            return View(tailieudinhkem);
        }



        // GET: tailieudinhkems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tailieudinhkem tailieudinhkem = db.tailieudinhkems.Find(id);
            if (tailieudinhkem == null)
            {
                return HttpNotFound();
            }
            return View(tailieudinhkem);
        }

        // POST: tailieudinhkems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tailieudinhkem tailieudinhkem, HttpPostedFileBase DuongDanFile, HttpPostedFileBase filePDF)
        {
            if (ModelState.IsValid)
            {
                if (DuongDanFile != null)
                {
                    string more = Path.GetExtension(DuongDanFile.FileName); //lấy đuôi trước để có thể validate file
                    var allowFile = new[] { ".jpg", ".jpeg" };
                    if (allowFile.Contains(more))
                    {
                        string name = Path.GetFileNameWithoutExtension(DuongDanFile.FileName);
                        string fullname = name + DateTime.Now.ToString("yyMMddssmmfff") + more;
                        DuongDanFile.SaveAs(Path.Combine(Server.MapPath("~/Upload"), fullname));
                        tailieudinhkem.DuongDan = fullname;
                    }
                    else
                    {
                        TempData["errImage"] = "Chỉ được tải tệp jpg, jpeg";
                        return View(tailieudinhkem);
                    }

                }
                if (filePDF != null)
                {
                    string more = Path.GetExtension(filePDF.FileName); //lấy đuôi trước để có thể validate file
                    var allowFile = new[] { ".docx", ".doc",".pdf" };
                    if (allowFile.Contains(more))
                    {
                        string name = Path.GetFileNameWithoutExtension(filePDF.FileName);
                        string fullname = name + DateTime.Now.ToString("yyMMddssmmfff") + more;
                        filePDF.SaveAs(Path.Combine(Server.MapPath("~/Upload"), fullname));
                        tailieudinhkem.filePdf = fullname;
                    }
                    else
                    {
                        TempData["errFile"] = "Chỉ được tải tệp pdf, doc";
                        return View(tailieudinhkem);
                    }

                }
               
                db.Entry(tailieudinhkem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tailieudinhkem);
        }

        // GET: tailieudinhkems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tailieudinhkem tailieudinhkem = db.tailieudinhkems.Find(id);
            if (tailieudinhkem == null)
            {
                return HttpNotFound();
            }
            return View(tailieudinhkem);
        }

        // POST: tailieudinhkems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tailieudinhkem tailieudinhkem = db.tailieudinhkems.Find(id);
            db.tailieudinhkems.Remove(tailieudinhkem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
