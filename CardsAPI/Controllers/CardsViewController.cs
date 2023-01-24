using CardsAPI.APIModels;
using DeckOfCards;
using Microsoft.AspNetCore.Mvc;

namespace CardsAPI.Controllers
{
    public class CardsViewController : Controller
    {
        private Deck _deck { get; set; }
        public CardsViewController()
        {
            _deck = new Deck();
        }
        public IActionResult ViewCards()
        {

            return View(_deck.GetDeck().Select(c => CardAPIModel.GetAPIModelFromCardModel(c)));
        }

    }
}
