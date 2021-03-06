﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Ownner { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ShowDate { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
