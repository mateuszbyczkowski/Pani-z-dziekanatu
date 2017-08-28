using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PZ_test1.Models
{
    [Table("ListaKierunkow")]
    public class ListaKierunkow
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PowtarzanePrzedmioty> PowtarzanePrzedmioty { get; set; }
        public virtual ICollection<KierunkiStudiow> KierunkiStudiow { get; set; }
    }
}