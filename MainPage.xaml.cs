using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlMvvm
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            
        }

        public async void GoToList(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new NoteDetail());

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

        }



    }
}