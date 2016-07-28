using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CognitiveCrmMobile.Core.Model;
using CognitiveCrmMobile.Core.Service;
using CognitiveCrmMobile.Adapters;

namespace CognitiveCrmMobile
{
    [Activity(Label = "My Cards", Icon = "@drawable/crm_apps_icon_hi_contrast_32x32")]
    public class CardMenuActivity : ListActivity
    {
        //private ListView cardMenuView;
        private List<Card> allCards;
        private CardsDataService cardDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.CardMenuView);
            //cardMenuView = FindViewById<ListView>(Resource.Id.cardListView);

            // Get Data
            cardDataService = new CardsDataService();
            this.allCards = cardDataService.GetAllCards();
            
            // Use Adapter
            //cardMenuView.Adapter = new CardListAdapter(this, allCards);
            // Enable Fast Scroll
            //cardMenuView.FastScrollEnabled = true;
            ListView.Adapter = new CardListAdapter(this, allCards);
            ListView.FastScrollEnabled = true;
        }

        protected override void OnListItemClick(ListView l, View u, int position, long id)
        {
            // Get Data
            //cardDataService = new CardsDataService();
            //allCards = cardDataService.GetAllCards();

            List<string> cardsList = new List<string>();
            cardsList.Add(this.allCards[position].id.ToString());

            //cardsList.Add(allCards[position].addressLine1);
            //cardsList.Add(allCards[position].addressLine2);
            //cardsList.Add(allCards[position].addressLine3);
            //cardsList.Add(allCards[position].companyName);
            //cardsList.Add(allCards[position].designation);
            //cardsList.Add(allCards[position].emailAddress1);
            //cardsList.Add(allCards[position].emailAddress2);
            //cardsList.Add(allCards[position].filePath);
            //cardsList.Add(allCards[position].height.ToString());
            //cardsList.Add(allCards[position].ignoreText);
            //cardsList.Add(allCards[position].name);
            //cardsList.Add(allCards[position].nameDesignation);
            //cardsList.Add(allCards[position].phoneNumber1);
            //cardsList.Add(allCards[position].phoneNumber1PhoneNumber2);
            //cardsList.Add(allCards[position].phoneNumber2);
            //cardsList.Add(allCards[position].webSite);
            //cardsList.Add(allCards[position].width.ToString());
            var intent = new Intent(this, typeof(CardDetailActivity));

            //intent.PutStringArrayListExtra("Card", cardsList);
            //StartActivity(intent);
            intent.PutExtra("selectedCardId", this.allCards[position].id);
            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedCard = cardDataService.GetCardById(data.GetIntExtra("selectedCardId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format("You've added {0} to CRM", selectedCard.name));
                dialog.Show();
            }
        }
    }
}