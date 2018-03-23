using DTO;
using Manager.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controller
{
    public class HelloController : ApiController
    {
        dbaContacts _dbaContacts = new dbaContacts();
        public List<ContactDTO> Get()
        {
            var result = _dbaContacts.selectAll().ToList();
            return result;
        }
    }
}
