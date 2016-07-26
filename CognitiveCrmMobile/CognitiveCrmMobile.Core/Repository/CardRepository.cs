using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CognitiveCrmMobile.Core.Model;

namespace CognitiveCrmMobile.Core.Repository
{
    class CardRepository
    {
        private static List<CardGroup> BusinessCardGroups = new List<CardGroup>()
        {

            new CardGroup()
            {
             ImagePath="", Title ="Group of Business Cards"
                , BusinessCards = new List<Card>()
                {
                    new Card() { nameDesignation = "Jane Smith", addressLine1 ="123 Main Street Anytown, USA", phoneNumber1 ="900-888-1234" , emailAddress1="Jane@Smith.com" },
                    new Card() { nameDesignation = "Koalu Sala", addressLine1 ="Taikos g. 104-55", phoneNumber1 ="(8-5)245-3377" , emailAddress1="koalusala@sebra.lt" },
                    new Card() { nameDesignation = "April Ulichnie", phoneNumber1 ="843-795-6233" , emailAddress1="Salon424andSpa@gmail.com", webSite="www.Salon424Spa.com" },
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
    }
}
