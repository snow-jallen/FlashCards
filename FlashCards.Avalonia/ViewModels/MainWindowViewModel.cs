using FlashCards.Data;
using FlashCards.SharedLogic;
using FlashCards.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Linq;

namespace FlashCards.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() : this(new CardRepository(new SqliteDataStore("my.db")))
        {

        }

        public MainWindowViewModel(CardRepository cardRepo)
        {
            this.cardRepo = cardRepo;
            var cards = cardRepo.GetAllCards();
            Greeting = $"found {cards.Count()} cards!";
        }

        public string Greeting { get; set; }

        private ICommand addCard;
        private readonly CardRepository cardRepo;

        public ICommand AddCard => addCard ?? (addCard = new SimpleCommand(() =>
        {
            cardRepo.AddCard(new Card("title", DateTime.Now.ToString(), "hint"));
        }));

        public object ChildControlViewModel { get; set; }
    }
}
