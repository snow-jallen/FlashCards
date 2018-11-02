using FlashCards.Types;
using FlashCards.SharedLogic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Data;

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
    }
}