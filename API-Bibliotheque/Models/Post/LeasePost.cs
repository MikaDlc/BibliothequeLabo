﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class LeasePost
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public int LibraryID { get; set; }
        [Required]
        [Length(1,100)]
        public List<int> Books { get; set; }

    }
}
