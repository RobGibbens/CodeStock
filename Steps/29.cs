//CodeStock.Core/Models/Session.cs
using System;
using SQLite.Net.Attributes;

namespace CodeStock.Core.Models
{
    public class Session
    {
        //TODO : Add attributes to create table in sqlite
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