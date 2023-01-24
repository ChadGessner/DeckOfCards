namespace DeckOfCards
{
    public class Card
    {
        public suits Suit { get;set; }
        public faceValues Value { get;set; }
        public bool IsHidden { get; set; } = false;
        public string ReverseImage { get; set; } = @"/images/backside.png";
        public override string ToString()
        {
            string suit = $"{Suit}";
            string value = $"{Value}";
            string isHidden = IsHidden.ToString();
            string reverse = ReverseImage;
            return $"{suit} {value} {isHidden} {reverse}";
        }
        public string GetFullImageUrl()
        {
            string incompleteUrl = @"/images/";
            string[] properties = this.ToString().Split(' ');
            return @"" + incompleteUrl + properties[0] + "_" + properties[1] + ".png";
        }
        
    }
    
}