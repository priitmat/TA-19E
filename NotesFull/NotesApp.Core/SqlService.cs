using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using NotesApp.Core.Models;

namespace NotesApp.Core
{
    public class SqlService
    {
        SQLiteConnection _sqlConnection;
        public SqlService()
        {
            CreateConnection();
        }
        public void CreateConnection()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "notesdb2.db3");

            _sqlConnection = new SQLiteConnection(dbPath);
        }
        public void CreateTable()
        {
            _sqlConnection.CreateTable<Note>();
        }
        public void InsertData(Note note)
        {
            _sqlConnection.Insert(note);
        }
        public void UpdateData(Note note)
        {
            _sqlConnection.Update(note);
        }
        public List<Note> GetAllNotes()
        {
            return _sqlConnection.Table<Note>().ToList();
        }
        public Note GetNote(int id)
        {
            return _sqlConnection.Table<Note>().Where(x => x.Id == id).FirstOrDefault();
        }
        public void DeleteData(Note note)
        {
            _sqlConnection.Delete(note);
        }

    }
}
