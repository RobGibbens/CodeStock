using System;
using SQLite.Net.Attributes;

namespace CodeStock.Core.Models
{
    public class Session
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public string ConferenceSlug { get; set; }
    }
}