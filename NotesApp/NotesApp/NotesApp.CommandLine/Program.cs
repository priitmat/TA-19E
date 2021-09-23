using NotesApp.CommandLine.Models;
using System;

namespace NotesApp.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = true;
            while (run)
            {
                Console.WriteLine(  
                 @"1.Vaata märkmeid
                2.Lisa
                3.Muuda
                4.Kustuta
                5.Exit
                            ");
                var answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine("headaega");
                        run = false;
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }            
        }
    }
}
