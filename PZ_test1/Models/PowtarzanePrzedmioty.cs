using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PZ_test1.Models
{
    [Table("PowtarzanePrzedmioty")]
    public class PowtarzanePrzedmioty
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Students")]
        public int? StudentId { get; set; }
        [ForeignKey("ListaKierunkow")]
        public int CourseId { get; set; }
        public string SubjectName { get; set; }
        public int ECTS { get; set; }
        public bool Passed { get; set; }

        public virtual  ListaKierunkow ListaKierunkow { get; set; }
        public virtual Students Students { get; set; }
    }
}