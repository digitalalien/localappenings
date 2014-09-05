using System;
using Android.App;
using Android.Views;
using Android.Widget;
using LocalAppenings;

namespace LocalAppenings_Droid
{
	public class EventListViewAdapter : BaseAdapter<EventItem>
	{
		private readonly Activity _context;

		public EventListViewAdapter (Activity context)
		{
			_context = context;
		}

		public override int Count {
			get {
				return EventData.Service.EventList.Count;
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override EventItem this[int position]
		{
			get { 
				return EventData.Service.EventList [position];
			}
		}

		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			View view = convertView;
			if(view == null){
				view = _context.LayoutInflater.Inflate (Resource.Layout.EventListItem, null);
			}

			//Get event Item at Position
			EventItem ei = EventData.Service.EventList [position];

			//Set the nameTextView to the Event Name
			view.FindViewById<TextView> (Resource.Id.nameTextView).Text = ei.name; 

			//Set the Address if Available
			if (String.IsNullOrEmpty (ei.address)) {
				view.FindViewById<TextView> (Resource.Id.addrTextView).Visibility = ViewStates.Gone;
			} else {
				view.FindViewById<TextView> (Resource.Id.addrTextView).Text = ei.address;
			}

			return view;

		}
	}
}

