using CardsHost.Models;
using DeckOfCards;
using Microsoft.AspNetCore.Mvc;

namespace CardsHost.Controllers
{
    public class CardsController : Controller
    {
        private Deck _deck;
        public CardsController()
        {
            _deck = new Deck();
        }
        public IActionResult Index()
        {
            return View(_deck.GetRandomizedDeck().Select(c=>CardVM.GetCardVMFromCardModel(c)));
        }
    }
}
