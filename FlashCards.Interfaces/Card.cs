using FlashCards.Types;
using System;
using System.ComponentModel.DataAnnotations;

namespace FlashCards.Types
{
    public class Card
    {
        public Card()
        {
            //Details = $"This was created on {DateTime.Now}";
        }
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
        //public string Details { get; set; }
    }
}
