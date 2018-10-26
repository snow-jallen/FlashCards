using FlashCards.SharedLogic;
using FluentAssertions;
using Moq;
using NUnit.Framework;

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
            var cardRepoMock = new Mock<ICardRepository>();
            cardRepoMock.Setup(m => m.AddCard(It.IsAny<Card>())).Returns(true);
            var cardRepo = cardRepoMock.Object;
            cardRepo.AddCard(c).Should().BeTrue();
        }
    }
}