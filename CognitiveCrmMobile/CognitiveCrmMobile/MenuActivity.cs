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

namespace CognitiveCrmMobile
{
    [Activity(Label = "CRM Cognitive", MainLauncher = true, Icon = "@drawable/crm_apps_icon_hi_contrast_32x32")]
    public class MenuActivity : Activity
    {
        private Button openButton;
        private Button aboutButton;
        private Button mapButton;
        private Button takePictureButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);
            FindViews();
            HandleEvents();
            
        }

        private void FindViews()
        {
            openButton = FindViewById<Button>(Resource.Id.openButton);
            //cartButton = FindViewById<Button>(Resource.Id.viewAllButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            openButton.Click += OpenButton_Click;
            aboutButton.Click += AboutButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
            mapButton.Click += MapButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CardMenuActivity));
            StartActivity(intent);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof(MapActivity));
            //StartActivity(intent);
        }
    }
}