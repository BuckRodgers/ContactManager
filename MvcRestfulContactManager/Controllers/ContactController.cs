using MvcRestfulContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net;
using System.Web;
using MvcRestfulContactManager.Services;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcRestfulContactManager.Controllers
{// : ApiController
    public class ContactController : Controller //ApiController //Controller for views, ApiController for JSON Post and get
    {

        private ContactRepository contactRepository;

        public ContactController()
        {
            
            this.contactRepository = new ContactRepository();
        }


        // GET: /Contact/
        public ActionResult Index()
        {
            //return contactRepository.GetAllContacts();
            Contact contact = new Contact();
            ViewData["Contact"] = contact;
            //return Controller
            return View(contactRepository.GetAllContacts());
        }

        public ActionResult Create()
        {
            return View();
        }


        // POST: /Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,Name")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                this.contactRepository.SaveContact(contact);
                ViewData["Contact"] = contact;
                ViewData["Contacts"] = contactRepository.GetAllContacts();
                //var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        /*
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }
        
        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
        */

    }
}
