using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace CognitiveCrmMobile.Core.Model
{
    public class CardGroup
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public List<Card> BusinessCards { get; set; }
}
}
