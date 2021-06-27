using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SearchingSortingPagination.Dal;
using SearchingSortingPagination.Models;
using PagedList.Mvc;
using PagedList;
using SearchingSortingPagination.Utilities;

namespace SearchingSortingPagination.Controllers
{
    public class TrainerController : Controller
    {
        private MyDatabase db = new MyDatabase();

        // GET: Trainer
        public ActionResult Index(string searchFirstName, string searchLastName, int? searchMinSalary, int? searchMaxSalary, 
            DateTime? searchMinDate, DateTime? searchMaxDate, bool? searchIsAvailable, string sortOrder, int? pSize, int? page)
        {

            var trainers = db.Trainers.ToList();

            ViewBag.FNSP = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : ""; //FNSP FirstNameSortP

            ViewBag.LNSP = sortOrder == "LastNameAsc" ? "LastNameDesc" : "LastNameAsc"; //LNSP LastNameSortP
            
            ViewBag.SSSP = sortOrder == "SalaryAsc" ? "SalaryDesc" : "SalaryAsc"; //SSSP SalarySSortP

            ViewBag.HDSP = sortOrder == "HireDateAsc" ? "HireDateDesc" : "HireDateAsc";

            ViewBag.Current_Sorting = sortOrder;


            ViewBag.Filter_FName = searchFirstName;
            ViewBag.Filter_LName = searchLastName;
            ViewBag.Filter_MinSalary = searchMinSalary;
            ViewBag.Filter_MaxSalary = searchMaxSalary;
            ViewBag.Filter_MinDate = searchMinDate;
            ViewBag.Filter_MaxDate = searchMaxDate;
            ViewBag.Filter_Available = searchIsAvailable;


            #region Filtering

            if (!String.IsNullOrWhiteSpace(searchFirstName))
                trainers = trainers.Where(x => x.FirstName.ToUpper().Contains(searchFirstName.ToUpper())).ToList();

            if (!String.IsNullOrWhiteSpace(searchLastName))
                trainers = trainers.Where(x => x.LastName.ToUpper().Contains(searchLastName.ToUpper())).ToList();

            if (searchMinSalary!= null)
                    trainers = trainers.Where(x => x.Salary >= searchMinSalary).ToList();

            if (searchMaxSalary != null)
                        trainers = trainers.Where(x => x.Salary <= searchMaxSalary).ToList();

            if (searchMinDate != null)
                trainers = trainers.Where(x => Validator.Compare(x.HireDate, searchMinDate) >= 0).ToList();

            if (searchMaxDate != null)
                trainers = trainers.Where(x => Validator.Compare(x.HireDate, searchMaxDate) <= 0).ToList();

            if (searchIsAvailable != null)
                trainers = trainers.Where(x => x.isAvailable == (bool)searchIsAvailable).ToList();


            #endregion


            #region Sorting
            switch (sortOrder)
            {
                case "FirstNameDesc": 
                    trainers = trainers.OrderByDescending(x => x.FirstName).ToList(); 
                    break;
                case "LastNameAsc": 
                    trainers = trainers.OrderBy(x => x.LastName).ToList(); 
                    break;
                case "LastNameDesc": 
                    trainers = trainers.OrderByDescending(x => x.LastName).ToList(); 
                    break;
                case "SalaryAsc": 
                    trainers = trainers.OrderBy(x => x.Salary).ToList(); 
                    break;
                case "SalaryDesc": 
                    trainers = trainers.OrderByDescending(x => x.Salary).ToList(); 
                    break;
                case "HireDateAsc":
                    trainers = trainers.OrderBy(x => x.HireDate).ToList();
                    break;
                case "HireDateDesc":
                    trainers = trainers.OrderByDescending(x => x.HireDate).ToList();
                    break;
                default: 
                    trainers = trainers.OrderBy(x => x.FirstName).ToList(); 
                    break;
            }
            #endregion


            #region pagination
            int pageSize = pSize ?? 5;
            int pageNumber = page ?? 1;
            #endregion

            return View(trainers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerId,FirstName,LastName,Salary")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerId,FirstName,LastName,Salary")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
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
