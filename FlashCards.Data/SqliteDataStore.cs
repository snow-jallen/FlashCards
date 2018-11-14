using FlashCards.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.Data
{
    public class SqliteDataStore : IDataStore
    {
        private readonly FlashCardsContext context;

        public SqliteDataStore()
        {
            context = new FlashCardsContext();
        }

        public void AddCard(Card c)
        {
            context.Cards.Add(c);
            context.SaveChanges();
        }

        public IEnumerable<Card> GetAllCards()
        {
            return context.Cards;
        }
    }

    class FlashCardsContext : DbContext
    {
        private static bool _created = false;

        public FlashCardsContext()
        {
            if (!_created)
            {
                _created = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();

            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=flashcards.db");
        }

        public DbSet<Card> Cards { get; set; }
    }
}
