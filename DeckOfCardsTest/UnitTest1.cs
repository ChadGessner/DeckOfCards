using DeckOfCards;

namespace DeckOfCardsTest
{
    public class UnitTest1
    {
        [Fact]
        public void NewDeckReturnsFiftyTwoCards()
        {
            Deck sut = new Deck();
            int result = sut.GetCount();
            Assert.Equal(52, result);
        }
        [Fact]
        public void NewDeckReturnsFifteenOfEachSuit()
        {
            Deck sut = new Deck();
            int resultOne = sut.GetDeck().Where(x => x.Suit == suits.hearts).Count();
            int resultTwo = sut.GetDeck().Where(x => x.Suit == suits.clubs).Count();
            int resultThree = sut.GetDeck().Where(x => x.Suit == suits.diamonds).Count();
            int resultFour = sut.GetDeck().Where(x => x.Suit == suits.spades).Count();
            Assert.Equal(13,resultOne);
            Assert.Equal(13,resultTwo);
            Assert.Equal(13,resultThree);   
            Assert.Equal(13,resultFour);
        }
        [Fact]
        public void ShuffleDeckMethodReturnsSufficientlyRandomizedDeck()
        {
            Deck sut = new Deck();
            Deck sutTwo = new Deck();
            sutTwo.GetRandomizedDeck();
            
            List<bool> sames = new List<bool>();
            for(int i = 0; i < sut.GetCount(); i++)
            {
                bool isTheSame = sut
                    .GetDeck()[i].Suit == sutTwo
                    .GetDeck()[i].Suit && sut
                    .GetDeck()[i].Value == sutTwo
                    .GetDeck()[i].Value;
                sames.Add(isTheSame);
            }
            int areTheSame = sames.Where(x => x == true).Count();
            Assert.True(4 > areTheSame); // five or more cards are almost never found in the same spot as the unshuffled deck, three cards being the same is farely common
        }
        [Fact]
        public void FirstCardInNewUnRandomizedDeckShowsProperStringValue()
        {
            Deck sut = new Deck();
            string ace = sut.GetDeck()[0].ToString();
            int count = 1;
            for(int i = 0; i < sut.GetDeck().Count; i++)
            {
                string[] vals = sut.GetDeck()[i].ToString().Split(' ');
                if(i / 13 < 1)
                {
                    Assert.True("hearts" == vals[0]);
                    continue;
                }
                if(i / 13 >= 1 && i / 13 < 2)
                {
                    Assert.True("clubs" == vals[0]);
                    continue;
                }
                if(i / 13 >= 2 && i / 13 < 3)
                {
                    Assert.True("diamonds" == vals[0]);
                    continue;
                }
                if(i / 13 >= 3 && i / 13 < 4)
                {
                    Assert.True("spades" == vals[0]);
                    continue;
                }
                count++;
            }
            Assert.True(sut.GetDeck()[0].ToString() == ace);
            
        }
    }
}