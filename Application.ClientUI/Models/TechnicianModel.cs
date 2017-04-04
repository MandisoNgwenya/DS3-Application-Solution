using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Application.ClientUI.Models
{
    public class TechnicianModel
    {

        [Key]
        public int Id { get; set; }

        public string name { get; set;  }



    }
}