using FlashCards.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FlashCards.XamarinForms
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IDataStore dataStore;

        public MainPageViewModel(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            Cards = new ObservableCollection<Card>(DataStore.GetAllCards());
        }

        public IDataStore DataStore => dataStore;

        private string title;
        public string Title
        {
            get { return title; }
            set { SetField(ref title, value); }
        }

        private string fullText;
        public string FullText
        {
            get { return fullText; }
            set { SetField(ref fullText, value); }
        }

        private string hint;
        public string Hint
        {
            get { return hint; }
            set { SetField(ref hint, value); }
        }

        private Command addCardCommand;
        public Command AddCardCommand => addCardCommand ?? (addCardCommand = new Command(
            () =>
            {
                DataStore.AddCard(new Card(
                    Title,
                    FullText,
                    Hint));
                Cards.Clear();
                foreach (var c in DataStore.GetAllCards())
                    Cards.Add(c);
                Title = null;
            }));

        public ObservableCollection<Card> Cards { get; private set; }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

    }
}
