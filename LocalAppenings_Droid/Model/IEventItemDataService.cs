using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalAppenings;

namespace LocalAppenings_Droid
{
	public interface IEventItemDataService
	{
		//Cached List
		IReadOnlyList<EventItem> EventList { get; }

		Task RefreshData();

		Task<EventItem> GetEventItem (string objectId );

		Task SaveEventItem( EventItem eventItem);

		Task DeleteEventItem (EventItem eventItem);

		Task GetItems();
	}
}