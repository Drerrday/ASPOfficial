using System;
using Microsoft.AspNetCore.Mvc;

namespace ASPOfficial.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            var repo = new DepartmentRepository();
            var depo = repo.GetDepartments();

            return View(depo);
        }

        public IActionResult ViewDepartment(int id)
        {
            var repo = new DepartmentRepository();
            var DEP = repo.ViewDepartment(id);

            if (DEP == null)
            { return View("DepartmentNotFound"); }

            return View(DEP);
        }
    }
}
