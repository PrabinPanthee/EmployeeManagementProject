using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using System.Web;
using System;
using System.Data.Entity.Migrations.Model;

namespace WebApplication3LearningBusinessObjects.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            BusinessEmployeeLayer businessEmployeeLayer = new BusinessEmployeeLayer();
            List<Employee> employees = businessEmployeeLayer.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Create")] //so we use this action name atribute to specify the action 
                               // public ActionResult Create(string name ,string city ,string gender,DateTime dateOfBirth)/And this the example of requesting data using parameters with the help of model binder
                               //public ActionResult create(Employee employee) //instead of p[assing all the data or properties we can use Employye as parameter to retrive all data
        public ActionResult Create_1() //this is the process of posting data without any parameter using Updatemodel function
        //in the same way the name of the controller functiom cannot me same as we are not passing any parameter so there is no method overloading 
        {
            /*We can request user input data from web using FormCollection in this way.
             * Employee employee = new Employee();
            employee.Name = formCollection["Name"];
            employee.City = formCollection["City"];
            employee.Gender = formCollection["Gender"];
            employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);*/

            //this is the example of reqesting data with parameters 
            /* Employee employee = new Employee();
             employee.Name = name;
             employee.City = city;
             employee.Gender = gender;
             employee.DateOfBirth = dateOfBirth;
             BusinessEmployeeLayer businessEmployeeLayer2 = new BusinessEmployeeLayer();
             businessEmployeeLayer2.AddEmmployee(employee);


             return RedirectToAction("Index");*/


            //this is the example of requesting the data using emplyee parameter
            /* if (ModelState.IsValid)
             {
                 BusinessEmployeeLayer businessEmployeeLayer2 = new BusinessEmployeeLayer();
                 businessEmployeeLayer2.AddEmmployee(employee);
                 return RedirectToAction("Index");
             }
             return View();*/

            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                //Employee employee = new Employee();
                //UpdateModel(employee);
                BusinessEmployeeLayer businessEmployeeLayer = new BusinessEmployeeLayer();
                businessEmployeeLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            BusinessEmployeeLayer businessEmployeeLayer = new BusinessEmployeeLayer();
            Employee employee = businessEmployeeLayer.Employees.Single(emp => emp.ID.Equals(id));

            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post([Bind(Include = "ID, Gender, City, DateOfBirth") ]Employee employee)
        {
            BusinessEmployeeLayer businessEmployeeLayer = new BusinessEmployeeLayer();
            employee.Name = businessEmployeeLayer.Employees.Single(emp => emp.ID == employee.ID).Name;
           
            if (ModelState.IsValid)
            {

               
                businessEmployeeLayer.SaveEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();



        }
    }
}