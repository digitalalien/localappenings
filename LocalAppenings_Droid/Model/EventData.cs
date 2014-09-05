using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalAppenings;
using System.IO;

namespace LocalAppenings_Droid
{
	public class EventData
	{
		public static readonly IEventItemDataService Service = new EventItemParseService();
	}
}

