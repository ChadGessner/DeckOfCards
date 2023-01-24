using CardsAPI.APIModels;
using DeckOfCards;
using Microsoft.AspNetCore.Mvc;

namespace CardsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : Controller
    {
        private Deck _deck { get; set; }
        public CardsController()
        {
            _deck = new Deck();
        }
        [HttpGet]
        public IEnumerable<CardAPIModel> Get()
        {

            return _deck
                .GetDeck()
                .Select(c => CardAPIModel.GetAPIModelFromCardModel(c));
        }
        //#region for views
        //public IActionResult ViewCards()
        //{

        //    return View(_deck.GetDeck().Select(c => CardAPIModel.GetAPIModelFromCardModel(c)));
        //}
        //#endregion
    }
}
