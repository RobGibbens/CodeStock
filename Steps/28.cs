//CodeStock.Core/Models/Conference.cs
using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace CodeStock.Core.Models
{
    public class Conference
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Unique]
        public string Slug { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Description { get; set; }

        public string City { get; set; }
        public string ImageUrl { get; set; }

        [Ignore]
        public List<Session> Sessions { get; set; } 
    }
}