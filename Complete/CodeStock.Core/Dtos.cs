using System;
using System.Collections.Generic;

namespace CodeStock.Core
{
    public class AddressDto
    {
        public int streetNumber { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalArea { get; set; }
        public string country { get; set; }
    }

    public class SessionDto
    {
        public string slug { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string room { get; set; }
        public string description { get; set; }
        public List<object> links { get; set; }
        public List<object> tags { get; set; }
        public List<object> subjects { get; set; }
        public List<object> resources { get; set; }
        public List<object> prerequisites { get; set; }
        public List<object> speakers { get; set; }
        public string speakerNames { get; set; }
        public string startDescription { get; set; }
    }

    public class ConferenceDto
    {
        public string slug { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public DateTime callForSpeakersOpens { get; set; }
        public DateTime callForSpeakersCloses { get; set; }
        public DateTime registrationOpens { get; set; }
        public DateTime registrationCloses { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public DateTime lastUpdated { get; set; }
        public AddressDto address { get; set; }
        public string imageUrl { get; set; }
        public string imageUrlSquare { get; set; }
        public bool isLive { get; set; }
        public string homepageUrl { get; set; }
        public List<double> position { get; set; }
        public int defaultTalkLength { get; set; }
        public List<string> rooms { get; set; }
        public List<object> sessionTypes { get; set; }
        public List<object> subjects { get; set; }
        public List<object> tags { get; set; }
        public List<SessionDto> sessions { get; set; }
        public int numberOfSessions { get; set; }
        public bool isOnline { get; set; }
        public string dateRange { get; set; }
        public string formattedAddress { get; set; }
    }
}
