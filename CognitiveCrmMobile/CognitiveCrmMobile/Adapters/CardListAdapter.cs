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
using CognitiveCrmMobile.Utility;

namespace CognitiveCrmMobile.Adapters
{

    public class CardListAdapter: BaseAdapter<Card>
    {
        List<Card> items;
        Activity context;

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override Card this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public CardListAdapter(Activity context, List<Card> items): base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return items[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            //var filePath = @"C:\dev\github\cognitivecrm\CognitiveCrmMobile\CognitiveCrmMobile\Resources\drawable\" + item.filePath;
            //var imageBitmap = ImageHelper.GetImageBitmapFromFilePath(filePath, item.width, item.height);
            if (convertView == null)
            {
                // If null then create a new row
                //convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            }
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.name;
            // Get a reference to the built-in Icon ImageView 
            ImageView img = convertView.FindViewById<ImageView>(Android.Resource.Id.Icon);
            // set the image using the SetImageDrawable method. We'll use a helper function in a static class
            // to return the image based on the the ImgURL from the people object

            if (item.bitmap == null)
            {
                img.SetImageDrawable(GetImage.GetImageFromURL(item.filePath, context));
                return convertView;
            }

            img.SetImageDrawable(GetImage.GetImageFromCard(item, context));
            return convertView;

        }
    }
}