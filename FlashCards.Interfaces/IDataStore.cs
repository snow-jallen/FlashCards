using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.Types
{
    public interface IDataStore
    {
        void AddCard(Card c);
        IEnumerable<Card> GetAllCards();
    }
}
