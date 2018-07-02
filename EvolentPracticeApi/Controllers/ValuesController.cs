using EvolentPracticeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvolentPracticeApi.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private static readonly IContactRepository _contactRepository = new ContactRepository();

       
        // GET api/values
        [HttpGet]
        [Route("Contacts")]
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepository.GetAll();
        }

        [HttpGet]
        [Route("GetAllActive")]
        public IEnumerable<Contact> GetAllActiveContacts()
        {
            return _contactRepository.GetAllActiveContact();
        }

        [HttpGet]
        [Route("GetAllInactive")]
        public IEnumerable<Contact> GetAllInactiveContacts()
        {
            return _contactRepository.GetAllInActiveContact();
        }

       
        [HttpGet]
        [Route("InformationById")]
        public Contact GetContactInfo(string id)
        {
           var contact= _contactRepository.GetContact(id);
            //if (contact == null)
            //{
            //    throw Exception();
            //}

            return contact;
            
        }

        // POST api/values
        [HttpPost]
        public bool PostContactInfo([FromBody]Contact contact)
        {

            if (ModelState.IsValid)
            {
                var result = _contactRepository.AddContact(contact);
                return true;

            }
            else
                return false;
        }

        // PUT api/values/5
        [HttpPut]
        public bool Put(string emailid, [FromBody]Contact value)
        {
            if (value == null) throw new ArgumentNullException("contact");

            return _contactRepository.UpdateContact(emailid, value);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(string emailid)
        {
            var product = _contactRepository.GetContact(emailid);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _contactRepository.RemoveContact(emailid);
        }
    }
}
