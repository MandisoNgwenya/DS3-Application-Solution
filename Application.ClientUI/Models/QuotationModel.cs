using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Application.ClientUI.Models
{
    public class QuotationModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Job Card")]
        public string Job_Card { get; set; }
        [Display(Name = "Name")]

        public string Name { get; set; }
        [Display(Name = "Identity Number")]
        public string IdentityNumber { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Deposit")]
        public double Deposit { get; set; }
        [Display(Name = "Total")]
        public double Total { get; set; }
        [Display(Name = "Balance")]
        public double Balance { get; set; }
        [Display(Name = "Technician")]
        public string technician { get; set; }
        [Display(Name = "Accessories")]
        public string Accessories { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Email")]
        public string techemail { get; set; }



    }
}