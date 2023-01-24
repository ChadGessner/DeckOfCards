using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public class Deck
    {
        private List<Card> _deck { get; set; } = new List<Card>();
        public Deck()
        {
            GenerateDeck();
        }
        private void GenerateDeck()
        {
            foreach(suits s in Enum.GetValues(typeof(suits)))
            {
                foreach(faceValues v in Enum.GetValues(typeof(faceValues)))
                {
                    _deck.Add(new Card() { Suit = s, Value = v });
                }
            }
        }
        public List<Card> GetDeck()
        {
            return _deck;
        }
        public List<Card> GetRandomizedDeck()
        {
            ShuffleDeck();
            ShuffleDeck();
            ShuffleDeck();
            return _deck;
        }
        private void ShuffleDeck()
        {
            List<Card> shuffled = new List<Card>();
            List<int> randoms = new List<int>();
            Random random = new Random();
            while(randoms.Count < GetCount())
            {
                int randInt = random.Next(0, GetCount());
                if (randoms.Contains(randInt))
                {
                    continue;
                }
                randoms.Add(randInt);
                shuffled.Add(_deck[randInt]);
            }
            _deck = shuffled;
        }
        public int GetCount()
        {
            return _deck.Count;
        }
    }
}
