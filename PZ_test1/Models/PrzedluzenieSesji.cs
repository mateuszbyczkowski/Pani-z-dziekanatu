﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PZ_test1.Models
{
    [Table("PrzedluzenieSesji")]
    public class PrzedluzenieSesji
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey("Students")]
        public int StudentId { get; set; }

        [DisplayName("Imie Studenta")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Imie { get; set; }

        [DisplayName("Nazwisko Studenta")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwisko { get; set; }

        [DisplayName("Numer legitymacji studenckiej")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string NrLegitymacji { get; set; }

        [DisplayName("Numer semestru")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Semestr { get; set; }

        [DisplayName("Rok akademicki")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Rok { get; set; }

        [DisplayName("Kierunek studiow")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Kierunek { get; set; }

        [DisplayName("Tryb studiow")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string TrybStudiow { get; set; }

        [DisplayName("Data zlozenia formularza")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Data { get; set; }

        [DisplayName("Przedłużany przedmiot")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Przedmiot { get; set; }

        [DisplayName("Status Formularza")]
        [ScaffoldColumn(false)]
        public string Status { get; set; }

        public Students Students { get; set; }
    }
}