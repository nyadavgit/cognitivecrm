using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CognitiveCrmMobile.Core.Model;

namespace CognitiveCrmMobile.Core.Repository
{
    class BusinessCardRepository
    {
        private static List<BusinessCardGroup> BusinessCardGroups = new List<BusinessCardGroup>()
        {

            new BusinessCardGroup()
            {
             ImagePath="", Title ="Group of Business Cards"
                , BusinessCards = new List<BusinessCard>()
                {
                    new BusinessCard() { },
                    new BusinessCard() { },
                    new BusinessCard() { }
                }
            }
        };
        public List<BusinessCard> GetAllBusinesCards()
        {
            IEnumerable<BusinessCard> businessCards = from businessCardGroup in BusinessCardGroups
                                                      from businessCard in businessCardGroup.BusinessCards

            select businessCard;

            return businessCards.ToList<BusinessCard>();
        }

        public BusinessCard GetBusinesCardById(int id)
        {
            IEnumerable<BusinessCard> businessCards = from businessCardGroup in BusinessCardGroups
                                                      from businessCard in businessCardGroup.BusinessCards
                                                      where businessCard.id == id
                                                      select businessCard;

            return businessCards.FirstOrDefault();
        }
    }
}
