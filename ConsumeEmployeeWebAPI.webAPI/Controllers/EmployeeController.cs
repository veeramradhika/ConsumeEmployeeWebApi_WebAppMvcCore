using ConsumeEmployeeWebAPI.webAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeEmployeeWebAPI.webAPI.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseUri = new Uri("https://localhost:7123/api");

        HttpClient client = new HttpClient();

        List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();

        public IActionResult Index()
        {
            client.BaseAddress = baseUri;
            HttpResponseMessage response = client.GetAsync(baseUri + "/employees").Result;
            if (response.IsSuccessStatusCode)
            {
                string EmployeeData = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(EmployeeData); ;

            }
            return View(employeeList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(EmployeeViewModel employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7123/api/employees");
                var post = client.PostAsJsonAsync<EmployeeViewModel>("employees", employee);
                post.Wait();
                var result = post.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError(string.Empty, "Server Error");
                return View(employee);
            }
        }
        public ActionResult Update(int id)
        {
            client.BaseAddress = baseUri;
            HttpResponseMessage response = client.GetAsync(baseUri + "/employees").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            var emp = employeeList.Where(e => e.id == id).FirstOrDefault();
            return View(emp);
        }
        
        public IActionResult Save(EmployeeViewModel employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7123/api/employees");
                var put = client.PutAsJsonAsync<EmployeeViewModel>($"employees?empId={employee.id}", employee);
                put.Wait();
                var result = put.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "server error");
            return View();

        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7123/api/employees");
                var delete = client.DeleteAsync($"employees?empId={id}");
                delete.Wait();
                var result = delete.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "server error");
            return View();

        }
        public ActionResult Search(string searchString)
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            HttpResponseMessage response = client.GetAsync(baseUri + "/employees/" + searchString).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            return View("Index", employeeList);
        }
    }
   

}
