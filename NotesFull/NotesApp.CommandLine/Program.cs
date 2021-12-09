using NotesApp.Core;
using NotesApp.Core.Models;
using System;
using System.Collections.Generic;

namespace NotesApp.CommandLine
{
    class Program
    {
        static public SqlService SqlService = new SqlService();
        static void Main(string[] args)
        {
            
            SqlService.CreateTable();
            List<Note> Notes = new List<Note>();



            var run = true;
            while (run)
            {
                
                List<string> list = new List<string>();
                String[] str = new string[1];
                Console.WriteLine(@"
1. Vaata
2. Lisa
3. Muuda
4. Kustuta
5. Exit");
                var answer = int.Parse(Console.ReadLine());
                var notes = SqlService.GetAllNotes();
                switch (answer)
                {
                    case 1:
                        
                        Console.WriteLine("Note-d:");
                        foreach (Note note in notes)
                        {
                            Console.WriteLine($"Pealkiri: {note.Heading}");
                            Console.WriteLine($"Sisu: {note.Content} ");
                            Console.WriteLine($"Muutmise Kellaaeg: {note.ChangeDateTime} \n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Pealkiri ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Sisu ");
                        string description = Console.ReadLine();
                        var newnote = new Note();
                        newnote.Heading = title;
                        newnote.Content = description;
                        newnote.ChangeDateTime = DateTime.Now;
                        SqlService.InsertData(newnote);
                        break;
                    case 3:
                        for (int i = 0; i < notes.Count; i++)
                        {
                            Console.WriteLine($"{i}: {notes[i].Heading}");
                        }
                        answer = int.Parse(Console.ReadLine());
                        Console.WriteLine("1. Pealkiri\n2. Sisu");
                        int answer2 = int.Parse(Console.ReadLine());
                        if (answer2 == 1)
                        {
                            Console.WriteLine("Uus pealkiri ");
                            notes[answer].Heading = Console.ReadLine();
                        }
                        else if (answer2 == 2)
                        {
                            Console.WriteLine("Uus sisu ");
                            notes[answer].Content = Console.ReadLine();
                        }
                        SqlService.UpdateData(notes[answer]);
                        break;
                    case 4:
                        for (int i = 0; i < notes.Count; i++)
                        {
                            Console.WriteLine($"{i}: {notes[i].Heading}");
                        }
                        int deleteAnswer = int.Parse(Console.ReadLine());
                        SqlService.DeleteData(notes[deleteAnswer]);

                        Console.WriteLine("Kustutatud!");
                        break;
                    case 5:
                        Console.WriteLine("Cya!");
                        run = false;
                        break;

                }
            }
        }
    }
}
