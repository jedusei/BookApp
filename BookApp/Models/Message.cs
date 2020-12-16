using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Models
{
    public class Message
    {
        public bool IsFromMe { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
    }
}
