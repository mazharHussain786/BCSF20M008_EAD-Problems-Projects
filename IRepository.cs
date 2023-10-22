using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public interface IRepository
    {
        void InsertData(string firstName, string lastName, string email, string primaryPhoneNumber, string createdBy);
        void DeleteData(long id);
        void SelectEmployee(long id);
        void UpdateEmployee(long id, string firstName, string lastName, string email, string primaryPhoneNumber, string modifiedBy);
        void showAll();
    }
}
