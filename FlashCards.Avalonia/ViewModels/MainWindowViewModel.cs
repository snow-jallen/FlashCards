using FlashCards.Data;
using FlashCards.SharedLogic;
using FlashCards.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FlashCards.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() : this(new CardRepository(new JsonDataStore()))
        {

        }

        public MainWindowViewModel(CardRepository cardRepo)
        {
            this.cardRepo = cardRepo;
        }

        public string Greeting => "Hello World!";

        private ICommand addCard;
        private readonly CardRepository cardRepo;

        public ICommand AddCard => addCard ?? (addCard = new SimpleCommand(() => ChildControlViewModel = new AddCardViewModel(cardRepo)));

        public object ChildControlViewModel { get; set; }
    }
}
