using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentPracticeApi.Models
{
    interface IContactRepository
    {
        IEnumerable<Contact> GetAll();

        IEnumerable<Contact> GetAllActiveContact();

        IEnumerable<Contact> GetAllInActiveContact();

        Contact GetContact(string customerID);

        Contact AddContact(Contact item);

        void RemoveContact(string emailId);

        bool UpdateContact(string emailId,Contact item);
    }
}
