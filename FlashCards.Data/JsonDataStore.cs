using FlashCards.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlashCards.Data
{
    public class JsonDataStore : IDataStore
    {
        private const string Path = "flashCards.json";

        public JsonDataStore()
        {
            if (File.Exists(Path))
            {
                cards = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText(Path));
            }
            else
            {
                cards = new List<Card>();
            }
        }

        private List<Card> cards;

        public void AddCard(Card c)
        {
            cards.Add(c);
            syncToDisk();
        }

        private void syncToDisk()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(cards));
        }

        public IEnumerable<Card> GetAllCards()
        {
            return cards;
        }
    }
}
