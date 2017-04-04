using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ClientUI.Models
{
    public class BookingViewModel
    {
        [Key]
        public int BookingID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdentityNumber { get; set; }

        public string Address { get; set; }

        public string CellNo { get; set; }


        public string Device { get; set; }


        public string Date { get; set; }

        public string Clerk { get; set; }

        public string Technician { get; set; }

        public string JobCard { get; set; }
        public string Title { get; set; }

        public string Country { get; set; }
        public string Province { get; set; }
        public string AreaCode { get; set; }

        public string DateOfBirth { get; set; }

 
        public string SerialNo { get; set; }
       


        public string Email { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}