using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using MvcRestfulContactManager.Services;
using System.Net.Http;
using MvcRestfulContactManager.Models;

namespace MvcRestfulContactManager.Controllers
{
    public class ContactApiController : ApiController
    {
         private ContactRepository contactRepository;

        public ContactApiController()
        {
            this.contactRepository = new ContactRepository();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }

    }
}