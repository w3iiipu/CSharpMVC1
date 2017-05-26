using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace HelloMVC.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            PeopleBusinessLayer peopleBusinessLayer = new PeopleBusinessLayer();
            List<People> people = peopleBusinessLayer.Peoples.ToList();

            return View(people);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// using formcollection
        /// </summary>
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    ///To demonstratre whats inside the formcollection object
        //    ///to loop through the formcollection object for allkeys inside the object
        //    ///formcollection object will receive data from the form
        //    //foreach (string key in formCollection.AllKeys )
        //    //{
        //    //    Response.Write("Key = " + key + " ");
        //    //    Response.Write(formCollection[key]);
        //    //    Response.Write("<br/>");
        //    //}

        //    //people object to populate by the form
        //    People people = new People();
        //    people.Name = formCollection["Name"];
        //    people.Email = formCollection["Email"];
        //    people.Phone = formCollection["Phone"];
        //    people.Birthday = Convert.ToDateTime(formCollection["Birthday"]);

        //    //create instance of PeopleBusinessLayer
        //    PeopleBusinessLayer peopleBusinesslayer = new PeopleBusinessLayer();
        //    //add the people object
        //    peopleBusinesslayer.addPeople(people);

        //    return RedirectToAction("Index");
        //}

        /// ALTERNATIVE
        /// If not using formCollection, can specify parameters manually that is alrdy mapped automatically
        //[HttpPost]
        //public ActionResult Create(string name, string email, string phone, DateTime birthday)
        //{
        //    People people = new People();
        //    people.Name = name;
        //    people.Email = email;
        //    people.Phone = phone;
        //    people.Birthday = birthday;

        //    PeopleBusinessLayer peopleBusinesslayer = new PeopleBusinessLayer();
        //    peopleBusinesslayer.addPeople(people);

        //    return RedirectToAction("Index");
        //}

        ///ALTERNATIVE
        ///pass the peopel object directly
        //[HttpPost]
        //public ActionResult Create(People people)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        PeopleBusinessLayer peopleBusinesslayer = new PeopleBusinessLayer();
        //        peopleBusinesslayer.addPeople(people);

        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        ///ALTERNATIVE
        ///without passing any parameters or object
        ///it is renamed so it is not the same as the Get Create() since there is no parameters being passed into the actionresult
        ///[ActionName] redirects the actionresult
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(People people)
        {

            //People people = new People();

            //used to bind posted data to the people object
            //it inspects the httprequest input sucj as posted form data, querystring cookies and server variables and populate the people object
            //tryupdatemodel will not throw exception and give user chance to reenter information
            //TryUpdateModel(people);

            //the People object can be passed into the method instead of using tryupdate model for the same result

            if (ModelState.IsValid)
            {
                PeopleBusinessLayer peopleBusinesslayer = new PeopleBusinessLayer();
                peopleBusinesslayer.addPeople(people);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PeopleBusinessLayer peopleBusinessLayer = new PeopleBusinessLayer();
            People people = peopleBusinessLayer.Peoples.Single(emp => emp.ID == id);

            return View(people);
        }

        /// <summary>
        /// passing string array to include exclude from model binding to UpdateModel function
        /// </summary>
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            PeopleBusinessLayer peopleBusinessLayer = new PeopleBusinessLayer();
            People people = peopleBusinessLayer.Peoples.Single(x => x.ID == id);
            UpdateModel(people, new string[] { "ID", "Email", "Phone", "Birthday" });   //model binding include list

            if (ModelState.IsValid)
            {
               
                peopleBusinessLayer.savePeople(people);

                return RedirectToAction("Index");
            }
            return View(people);
        }

        /// <summary>
        /// Including and excluding properties from model binding using bind attribute
        /// field cannot be [Required] in object class
        /// </summary>
        [HttpPost]
        public ActionResult Edit_Post([Bind(Include = "ID, Email, Phone, Birthday")]People people)
        {
            PeopleBusinessLayer peopleBusinessLayer = new PeopleBusinessLayer();
            people.Name = peopleBusinessLayer.Peoples.Single(x => x.ID == people.ID).Name; //name property binded to the object

            if (ModelState.IsValid)
            {

                peopleBusinessLayer.savePeople(people);

                return RedirectToAction("Index");
            }
            return View(people);
        }

        /// <summary>
        /// model binding using interface to update only the desired field and 
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit_Post1(int id)
        {
            PeopleBusinessLayer peopleBusinessLayer = new PeopleBusinessLayer();
            People people = peopleBusinessLayer.Peoples.Single(x => x.ID == id);
            UpdateModel<IPeople>(people);   //update using the interface

            if (ModelState.IsValid)
            {

                peopleBusinessLayer.savePeople(people);

                return RedirectToAction("Index");
            }
            return View(people);
        }

        ///
        ///DeleteAction method with http get by default without any atrribute specification
        ///It is bad because it opens a security hole where an image or html page with the get request will execute and runs the delete upon execution
        ///
        //public ActionResult Delete(int id)
        //{
        //    PeopleBusinessLayer peopleBusinessLayer = new PeopleBusinessLayer();
        //    peopleBusinessLayer.deletePeople(id);
        //    return RedirectToAction("Index");

        //}

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PeopleBusinessLayer peopleBusinessLayer = new PeopleBusinessLayer();
            peopleBusinessLayer.deletePeople(id);
            return RedirectToAction("Index");

        }



    }


}