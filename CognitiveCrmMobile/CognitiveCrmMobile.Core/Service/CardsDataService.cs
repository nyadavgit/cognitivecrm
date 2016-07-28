using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CognitiveCrmMobile.Core.Repository;
using CognitiveCrmMobile.Core.Model;

namespace CognitiveCrmMobile.Core.Service
{
    public class CardsDataService
    {
        private static CardRepository cardRepository = new CardRepository();
        public List<Card> GetAllCards()
        {
            return cardRepository.GetAllCards();
        }
        public List<CardGroup> GetGroupedCards()
        {
            return cardRepository.GetGroupedCards();
        }
        public List<CardGroup> GetCardsForGroup(int cardGroupId)
        {
            return cardRepository.GetCardsForGroup(cardGroupId);
        }
        public List<Card> GetFavoriteCards()
        {
            return cardRepository.GetFavoriteCards();
        }
        public Card GetCardById(int id)
        {
            return cardRepository.GetCardById(id);
        }

        public void AddCard(Card card)
        {
            cardRepository.AddCard(card);
        }
    }
}
