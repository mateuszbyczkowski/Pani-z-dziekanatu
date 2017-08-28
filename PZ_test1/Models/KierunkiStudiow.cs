using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PZ_test1.Models
{
    [Table("KierunkiStudiow")]
    public class KierunkiStudiow
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        [ForeignKey("ListaKierunkow")]
        public int CoursId { get; set; }
        public string Degree { get; set; }
        public string Semestr { get; set; }
        public string TypeOfStudy { get; set; }

        public virtual ListaKierunkow ListaKierunkow { get; set; }
        public virtual Students Students { get; set; }
    }
}