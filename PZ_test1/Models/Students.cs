using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PZ_test1.Models
{
    [Table("Students")]
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public int Index { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Pesel { get; set; }
        public string PostCode { get; set; }
        public string Local { get; set; }
        //[ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        //public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<Warunki> Warunki { get; set; }
        public virtual ICollection<PrzedluzenieSesji> PrzedluzeniaSesji { get; set; }
        public virtual ICollection<Termin> Termin { get; set; }

    }
}