using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalAppenings;
using Parse;

namespace LocalAppenings_Droid
{
	public class EventItemParseService : IEventItemDataService
	{

		private List<EventItem> _events = new List<EventItem>();

		public EventItemParseService ()
		{
			//ParseStorage.ParseConnect ();
			GetItems ().ConfigureAwait(false);
		}

		#region IEventItemDataService implementation

		public async Task RefreshData ()
		{
			//clear the list
			//_events.Clear ();

			//get items and add to cache list
//			var query = ParseObject.GetQuery ("Event");
//			var ie = await query.FindAsync ();
//
//			foreach (var t in ie) {
//				_events.Add (ParseStorage.FromParseObject (t, "EventItem") as EventItem);
//			}

		}

		public async Task GetItems () 
		{
			var query = ParseObject.GetQuery ("Event").OrderBy ("date");
			var ie = await query.FindAsync ();

			//var tl = new List<EventItem> ();
			foreach (var t in ie) {
				_events.Add (ParseStorage.FromParseObject (t, "EventItem") as EventItem);
			}

			//return EventList;
		}

		public async Task<EventItem> GetEventItem (string objectId)
		{
			var query = ParseObject.GetQuery ("Event").WhereEqualTo ("objectId", objectId);
			var t = await query.FirstAsync();
			return ParseStorage.FromParseObject (t, "EventItem") as EventItem;
		}

		public async Task SaveEventItem (EventItem eventItem)
		{

			await ParseStorage.ToParseObject (eventItem).SaveAsync();

		}

		public async Task DeleteEventItem (EventItem eventItem)
		{
			try{
				await ParseStorage.ToParseObject(eventItem).DeleteAsync();
			}
			catch(Exception e){
				Console.Error.WriteLine (@"ERROR{0}", e.Message);
			}
		}

		public IReadOnlyList<EventItem> EventList {
			get {
				return _events;
			}
		}

		#endregion
	}
}

