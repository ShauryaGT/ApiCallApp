using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace XamlMvvm
{
    public class SQLiteHelper
    {
        private readonly SQLiteConnection db;
        //private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath,false);
            db.CreateTable<NoteModel>();
            //db.CreateTableAsync<NoteModel>();
        }
        public int CreateNote(NoteModel note)
        {
            return db.Insert(note);
            //return db.InsertAsync(note);
        }
        public List<NoteModel> ReadNote()
        {
            return db.Table<NoteModel>().ToList();
        }
        public int count()
        {
            return db.Table<NoteModel>().Count();
        }
        public int DeleteNote()
        {
            return db.DeleteAll<NoteModel>();
        }
    }
}

