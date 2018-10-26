using System;

namespace FlashCards.SharedLogic
{
    public class Card
    {
        public Card(string title, string fullText, string hint)
        {
            Title = title;
            FullText = fullText;
            Hint = hint;
        }

        public string Title { get; }
        public string FullText { get; }
        public string Hint { get; }
    }
}
