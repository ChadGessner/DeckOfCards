using CardsHost.Models;
using DeckOfCards;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;

namespace CardsHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsHostController : Controller
    {
        private Deck _deck { get; set; }
        public CardsHostController()
        {
            _deck= new Deck();
        }
        public List<CardVM> Get()
        {
            List<CardVM> cardVMs = _deck
                .GetRandomizedDeck()
                .Select(c => CardVM.GetCardVMFromCardModel(c))
                .ToList();
            //var resourcePath = "CardHost.Controllers" + Path.GetFullPath(@"C:\Users\Chad\Desktop\C#\DeckOfCards\CardsHost\wwwRoot\Images\");
            //using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            //{
            //    Console.WriteLine(imageStream.Length);
            //}
            return cardVMs;
        }
    }
}
