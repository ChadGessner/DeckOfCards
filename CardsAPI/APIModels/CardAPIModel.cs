using DeckOfCards;

namespace CardsAPI.APIModels
{
    public class CardAPIModel
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public bool IsHidden { get; set; }
        public string ImageUrl { get; set; }
        public string ReverseImage { get; set; }

        public static CardAPIModel GetAPIModelFromCardModel(Card card)
        {
            string[] cardStringArray = card.ToString().Split(' ');
            return new CardAPIModel()
            {
                Suit = cardStringArray[0],
                Value = cardStringArray[1],
                IsHidden = cardStringArray[2] == "True",
                ImageUrl = card.GetFullImageUrl(),
                ReverseImage = cardStringArray[3]
            };
        }
    }
}
