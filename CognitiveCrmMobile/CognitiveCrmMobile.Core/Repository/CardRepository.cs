using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CognitiveCrmMobile.Core.Model;
using System.IO;

namespace CognitiveCrmMobile.Core.Repository
{
    class CardRepository
    {

        private static List<CardGroup> BusinessCardGroups = new List<CardGroup>()
        {

            new CardGroup()
            {
             ImagePath="", Title ="Group of Business Cards", id=1
                , BusinessCards = new List<Card>()
                {
                    new Card() { id=1, name="Jane Smith", nameDesignation = "Jane Smith", addressLine1 ="123 Main Street Anytown, USA", phoneNumber1 ="900-888-1234" , emailAddress1="Jane@Smith.com", height=300, width=500, filePath="images/one.jpg" },
                    new Card() { id=2, name="Koalu Sala", nameDesignation = "Koalu Sala", addressLine1 ="Taikos g. 104-55", phoneNumber1 ="(8-5)245-3377" , emailAddress1="koalusala@sebra.lt" , height=675, width=1125, filePath="images/two.jpg"},
                    new Card() { id=3, name="April Ulichnie", nameDesignation = "April Ulichnie", phoneNumber1 ="843-795-6233" , emailAddress1="Salon424andSpa@gmail.com", webSite="www.Salon424Spa.com" , height=676, width=1126, filePath="images/three.jpg"},
                    new Card() { id=2, name="Firstname Lastname", nameDesignation = "FirstName LastName Owner Manager", addressLine1 ="address line1", phoneNumber1 ="+123 4567890" , emailAddress1="you@yourbusiness.com" , height=675, width=1125, filePath="images/four.jpg"},
                    new Card() { id=3, name="Hackathon Reston", nameDesignation = "April Ulichnie", phoneNumber1 ="843-795-6233" , emailAddress1="Salon424andSpa@gmail.com", webSite="www.Salon424Spa.com" , height=676, width=1126, filePath="images/five.jpg"},
                    new Card() { id=2, name="Avanti Unisex Salon", nameDesignation = "Koalu Sala", addressLine1 ="Taikos g. 104-55", phoneNumber1 ="(8-5)245-3377" , emailAddress1="koalusala@sebra.lt" , height=675, width=1125, filePath="images/six.jpg"}
                    //new Card() { id=2, name="Test", nameDesignation = "Mr. Test", addressLine1 ="Taikos g. 104-55", phoneNumber1 ="(8-5)245-3377" , emailAddress1="koalusala@sebra.lt" , height=675, width=1125, filePath="/storage/emulated/0/Pictures/RaysHotDogs/Photo_ffb0bafb-53af-4805-bcb0-e7ca4e1cca23.jpg"}
                }
            }
        };
        public List<Card> GetAllCards()
        {
            IEnumerable<Card> businessCards = from businessCardGroup in BusinessCardGroups
                                                      from businessCard in businessCardGroup.BusinessCards

            select businessCard;

            return businessCards.ToList<Card>();
        }
        public List<CardGroup> GetGroupedCards()
        {
            IEnumerable<CardGroup> businessCards = from businessCardGroup in BusinessCardGroups
                                              select businessCardGroup;

            return businessCards.ToList<CardGroup>();
        }
        public List<CardGroup> GetCardsForGroup(int id)
        {
            IEnumerable<CardGroup> businessCards = from businessCardGroup in BusinessCardGroups
                                                   where businessCardGroup.id == id
                                                   select businessCardGroup;

            return businessCards.ToList<CardGroup>();
        }
        public List<Card> GetFavoriteCards()
        {
            IEnumerable<Card> businessCards = from businessCardGroup in BusinessCardGroups
                                              from businessCard in businessCardGroup.BusinessCards
                                              where businessCard.isFavorite == true
                                              select businessCard;

            return businessCards.ToList<Card>();
        }

        public Card GetCardById(int id)
        {
            IEnumerable<Card> businessCards = from businessCardGroup in BusinessCardGroups
                                              from businessCard in businessCardGroup.BusinessCards
                                              where businessCard.id == id
                                              select businessCard;

            return businessCards.FirstOrDefault();
        }

        public void AddCard(Card card)
        {
            List<CardGroup> group = this.GetCardsForGroup(1);
            group[0].BusinessCards.Add(card);
        }
    }
}
