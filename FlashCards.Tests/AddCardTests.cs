using FlashCards.Types;
using FlashCards.SharedLogic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Data;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddCard()
        {
            var c = new Card("title", "fullTest", "hint");
            var dataStoreMock = new Mock<IDataStore>();
            var cardRepo = new CardRepository(dataStoreMock.Object);

            var result = cardRepo.AddCard(c);
            result.Should().BeTrue();
        }

        [Test]
        public void AddCardReturnsFalseWhenDataStoreFails()
        {
            var c = new Card("title", "fullText", "hint");
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(m => m.AddCard(It.IsAny<Card>()))
                .Throws(new DataException("Your attempt to add a card failed."));
            var cardRepo = new CardRepository(dataStoreMock.Object);

            var result = cardRepo.AddCard(c);
            result.Should().BeFalse();
        }

        [Test]
        public void AddCardViaAddCardViewModel()
        {
            var dataStoreMock = new Mock<IDataStore>();
            var cardRepo = new CardRepository(dataStoreMock.Object);
            var addCardVM = new AddCardViewModel(cardRepo);

            addCardVM.Title = "title";
            addCardVM.Text = "text";
            addCardVM.Hint = "hint";

            addCardVM.AddCard.Execute(this);

            addCardVM.IsClosed.Should().BeTrue();
        }

        [Test]
        public void testWithMock()
        {
            var cards = new List<Card>();
            var mock = new Mock<IDataStore>();
            mock.Setup(m => m.AddCard(null))
                .Callback(() => throw new ArgumentNullException("card"));
            mock.Setup(m => m.AddCard(It.IsAny<Card>()))
                .Callback<Card>(c => cards.Add(c));
            mock.Setup(m => m.GetAllCards())
                .Returns(cards);
         
        }

    }

    public class BogusDataStore : IDataStore
    {
        public BogusDataStore()
        {
            cards = new List<Card>();
        }

        private List<Card> cards;

        public void AddCard(Card c)
        {

            cards.Add(c);
        }

        public IEnumerable<Card> GetAllCards()
        {
            return cards;
        }
    }

    public interface ITest
    {
        event EventHandler MyEvent;
    }
}