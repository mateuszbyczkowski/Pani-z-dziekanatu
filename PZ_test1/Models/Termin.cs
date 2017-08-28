using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PZ_test1.Models
{
    [Table("Termin")]
    public class Termin
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        [ForeignKey("Students")]
        public int? StudentId { get; set; }
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Students Students { get; set; }
    }
}