using System;
using System.Collections.Generic;

namespace eating_confessions.Models
{
    public class Confession
    {
        public long Id {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public DateTime TimePosted { get; set; }
        // public DateTime date {get; set;}
        // figure out how to define a new date.
    }
}