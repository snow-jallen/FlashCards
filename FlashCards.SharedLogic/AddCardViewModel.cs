using FlashCards.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace FlashCards.SharedLogic
{
    public class AddCardViewModel : INotifyPropertyChanged
    {
        private readonly CardRepository repo;

        public AddCardViewModel(CardRepository repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetField(ref title, value); }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set { SetField(ref text, value); }
        }

        private string hint;
        public string Hint
        {
            get { return hint; }
            set { SetField(ref hint, value); }
        }

        private ICommand addCard;
        public ICommand AddCard => addCard ?? (addCard = new SimpleCommand(() =>
        {
            if (repo.AddCard(new Card(Title, Text, Hint)))
                IsClosed = true;
        }));

        private bool isClosed;
        public bool IsClosed
        {
            get { return isClosed; }
            set { SetField(ref isClosed, value); }
        }


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
