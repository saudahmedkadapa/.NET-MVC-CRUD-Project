using _001Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _001Mvc.Controllers
{
    public class TestController : Controller
    {
        sauddbEntities obj = new sauddbEntities();
        // GET: Test
        public ActionResult Show()
        {
            try
            {
                var allemps = obj.Emps.ToList();
                return View(allemps);

            }
            catch(Exception ex) {
                return View("Error", ex);
            }

            
           
        }
        public ActionResult Delete(int id)
        {
            try
            {
                Emp empToBeDeleted = (from emp in obj.Emps.ToList()
                                      where emp.Id == id
                                      select emp).First();
                obj.Emps.Remove(empToBeDeleted);
                obj.SaveChanges();
                return Redirect("/Test/Show");


            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public ActionResult Edit(int id) {

            try
            {
                Emp empToBeEdited = (from emp in obj.Emps.ToList()
                                     where emp.Id == id
                                     select emp).First();
                return View(empToBeEdited);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public ActionResult AfterEdit(FormCollection entireForm)
        {
            try
            {

                int NoOfTheEmpToEdit = Convert.ToInt32(entireForm["Id"]);
                Emp empToBeEdited = (from emp in obj.Emps.ToList()
                                     where emp.Id == NoOfTheEmpToEdit
                                     select emp).First();

                empToBeEdited.Name = entireForm["Name"].ToString();
                empToBeEdited.Address = entireForm["Address"].ToString();
                obj.SaveChanges();



                return Redirect("/Test/Show");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }
        public ActionResult Create()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }
        public ActionResult AfterCreate(FormCollection entireForm)
        {
            try
            {
                Emp empToBeAdded = new Emp()
                {
                    Id = Convert.ToInt32(entireForm["Id"]),
                    Name = entireForm["Name"].ToString(),
                    Address = entireForm["Address"].ToString()
                };

                obj.Emps.Add(empToBeAdded);

                obj.SaveChanges();
                return Redirect("/Test/Show");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }




    }


    }
