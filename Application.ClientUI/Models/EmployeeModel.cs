using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.ClientUI.Models
{
    public class EmployeeModel
    {
        public int id
        {
            get; set;
        }

        public string Identitynumber
        {
            get; set;
        }
        public string role
        {
            get; set;//Clerk Admin Technician 
        }
        public string eName
        {
            get; set;
        }
    }
}