using DeckOfCards;

namespace CardsHost.Models
{
    public class CardVM
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public bool IsHidden { get; set; }
        public string ReverseImage { get; set; }
        public string ImageUrl { get; set; }
        
        public static CardVM GetCardVMFromCardModel(Card card)
        {
            string[] properties = card.ToString().Split(' ');
            return new CardVM()
            {
                Suit = properties[0],
                Value = properties[1],
                IsHidden = properties[2] == "True",
                ReverseImage = properties[3],
                ImageUrl = card.GetFullImageUrl()
            };
        }
    }
}
