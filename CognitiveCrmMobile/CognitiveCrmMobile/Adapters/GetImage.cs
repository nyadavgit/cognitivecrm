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
using Android.Graphics.Drawables;
using CognitiveCrmMobile.Utility;
using Android.Graphics;
using System.IO;
using CognitiveCrmMobile.Core.Model;

namespace CognitiveCrmMobile.Adapters
{
    static class GetImage
    {

        public static Drawable GetImageFromURL(string url, Activity context)
        {

            Drawable headshotDrawable = null;
            try
            {
                headshotDrawable = Drawable.CreateFromStream(context.Assets.Open(url), null);

            }
            catch (Exception ex)
            {
                headshotDrawable = Drawable.CreateFromStream(context.Assets.Open("images/photo.png"), null);
            }
            return headshotDrawable;
        }

        public static Drawable GetImageFromCard(Card card, Activity context)
        {

            Drawable headshotDrawable = null;
            try
            {
                //MemoryStream stream = new MemoryStream();
                //card.bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                //BitmapFactory.DecodeStream(stream);
                headshotDrawable = new BitmapDrawable(card.bitmap);
                //headshotDrawable = Drawable.CreateFromStream(stream, null);
                return headshotDrawable;
            }
            catch (Exception ex)
            {
                headshotDrawable = Drawable.CreateFromStream(context.Assets.Open("images/photo.png"), null);
            }
            return headshotDrawable;
        }
    }
}