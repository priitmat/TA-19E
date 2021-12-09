using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Console.Models
{
    class Note
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public DateTime edited { get; set; }
    }
}
