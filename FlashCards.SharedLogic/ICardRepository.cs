using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.SharedLogic
{
    public interface ICardRepository
    {
        bool AddCard(Card c);
    }
}
