//CodeStock.Core/Models/Session.cs
using System;

namespace CodeStock.Core.Models
{
    //TODO : Create Model
    public class Session
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public string ConferenceSlug { get; set; }
    }
}