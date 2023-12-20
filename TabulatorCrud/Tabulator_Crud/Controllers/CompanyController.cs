using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Tabulator_Crud.DTO_s;
using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;
using Tabulator_Crud.Repository;

namespace Tabulator_Crud.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepository;
        public CompanyController (ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CompanyDTO company)
        {
            Company newcomp = new Company();

            newcomp.ComName = company.ComName;
            newcomp.Basic= company.Basic;
            newcomp.HRent=company.HRent;
            newcomp.medical=company.medical;
            newcomp.IsInactive=company.IsInactive;
            _companyRepository.Add(newcomp);
            return Json(company);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var companies= _companyRepository.GetAll();

            return Json(companies);
        }

        public IActionResult Edit(int id)
        {
            var company = _companyRepository.GetById(id);

            return View(company);
        }
        [HttpPost]
        public IActionResult Edit(Company company)
        {

            _companyRepository.Update(company);


            return RedirectToAction("Create");
        }
        
        public IActionResult Show()
        {
            List<Company> companies = _companyRepository.GetAll().ToList();
            return View(companies);
          
        }

        // Action to handle the selection and save the selected company in the session
        [HttpPost]
        public IActionResult SaveSelectedCompanyToSession(int companyId)
        {
            List<Company> companies = _companyRepository.GetAll().ToList();

            // Find the selected company in the list
            Company selectedCompany = companies.Find(c => c.ComId == companyId);

            if (selectedCompany != null)
            {
                // Serialize the selected company to JSON
                string selectedCompanyJson = Newtonsoft.Json.JsonConvert.SerializeObject(selectedCompany);

                // Set the cookie
                Response.Cookies.Append("selectedCompany", selectedCompanyJson, new CookieOptions
                {
                    Path = "/"
                });
                string selectedCompanyName = HttpContext.Request.Cookies["selectedCompany"];

                // Include the company name in the AJAX response
                return Json(new { success = true, companyName = selectedCompanyName });
            }
            else
            {
                // Handle the case where the selected company is not found
                return Json(new { success = false });
            }
        }
        public IActionResult? GetSelectedCompanyName()
        {
            // Retrieve the selected company name from the cookie
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
            if (selectedCompanyJson != null) {
                Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
                return Json(selectedCompany);
            }
            else
                return Json(new { success = false });
            // Now you can access properties of the selectedCompany object
         //   string companyName = selectedCompany.ComName;

            // Include the company name in the AJAX response
        

            // Include the company name in the AJAX response
        }

        public IActionResult Delete(int id)
        {
            _companyRepository.Delete(id);


            return RedirectToAction("Create");
        }
    }
}
