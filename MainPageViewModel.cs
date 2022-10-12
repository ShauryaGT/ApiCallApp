using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using System;
using Newtonsoft.Json;

namespace XamlMvvm
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string strurl;
        string strurltest;
        public MainPageViewModel()
        {
            Notes = new ObservableCollection<NoteModel>();

            SaveNoteCommand = new Command(() =>
            {
                
                strurl = string.Format(NoteText);
                WebRequest requestObjGet = WebRequest.Create(strurl);
                requestObjGet.Method = "GET";
                HttpWebResponse responseObjGet = null;
                responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();
                using (Stream stream = responseObjGet.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strurltest = sr.ReadToEnd();
                    sr.Close();
                    Notes.Add(new NoteModel { Text = strurltest });
                    App.MyDatabase.CreateNote(new NoteModel { Text = strurl + "\n" + strurltest });
                }
                NoteText = string.Empty;
            },
            () => !string.IsNullOrEmpty(NoteText));

            EraseNotesCommand = new Command(() =>
            {
                Notes.Clear();
                App.MyDatabase.DeleteNote();
                }
                );
            
        
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(NoteText)));

                SaveNoteCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<NoteModel> Notes { get; }

        public Command SaveNoteCommand { get; }
        public Command EraseNotesCommand { get; }

        /*public async void storeOutput(object sender, EventArgs e)
        {

            await App.MyDatabase.CreateNote(new NoteModel { Text = strurltest });

        }*/
    }
}