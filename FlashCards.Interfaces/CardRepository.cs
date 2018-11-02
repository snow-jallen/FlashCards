using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.Types
{
    public class CardRepository
    {
        private readonly IDataStore dataStore;

        public CardRepository(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public bool AddCard(Card c)
        {
            try
            {
                dataStore.AddCard(c);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Card> GetAllCards()
        {
            return dataStore.GetAllCards();
        }
    }
}
