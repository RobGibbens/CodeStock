//CodeStock.Core/Models/Conference.cs
using System;
using System.Collections.Generic;

namespace CodeStock.Core.Models
{
    //TODO : Create Model
    public class Conference
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public List<Session> Sessions { get; set; } 
    }
}