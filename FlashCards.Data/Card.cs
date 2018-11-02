using System;

namespace FlashCards.Data
{
    public class Card
    {
        public Card(string title, string fullText, string hint)
        {
            Title = title;
            FullText = fullText;
            Hint = hint;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string FullText { get; set; }
        public string Hint { get; set; }
    }
}
