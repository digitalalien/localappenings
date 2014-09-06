using System;
using Parse;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LocalAppenings_Droid
{
	[Activity (Label = "LocalAppenings_Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class EventListActivity : Activity
	{
		//int count = 1;
		ListView _eventListView;
		EventListViewAdapter _adapter;
		string[] items;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.EventList);

			_eventListView = FindViewById<ListView> (Resource.Id.eventListView);

			_adapter = new EventListViewAdapter (this);
			_eventListView.Adapter = _adapter;
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			//MenuInflater.Inflate (Resource.Menu.EventListViewMenu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

//		public override bool OnOptionsItemSelected (IMenuItem item)
//		{
//			switch (item.ItemId) {
//				case Resource.Id.actionNew:
//				//placeholder for creating new event
//				return true;
//
//				case Resource.Id.actionRefresh:
//				//EventData.Service.RefreshCache ();
//				_adapter.NotifyDataSetChanged ();
//				return true;
//
//				default:
//				return base.OnOptionsItemSelected (item);
//			}

	//	}
	}
}


