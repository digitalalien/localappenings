using System;
using NUnit.Framework;
using LocalAppenings;
using System.Collections.Generic;
using LocalAppenings_Droid;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Parse;

namespace LocalAppenings_Droid_Tests
{

	[TestFixture]
	public class LocalAppeningsTestFixture
	{
		IEventItemDataService _eiService;
		[SetUp]
		public void Setup ()
		{
			_eiService = new EventItemParseService ();
		}

		
		[TearDown]
		public void Tear ()
		{
		}

		[Test]
		public async void CreateEventItem()
		{
			EventItem newEvent = new EventItem();
			newEvent.city = "Louisville";
			newEvent.date = "2014-10-01";
			newEvent.isPublic = true;
			newEvent.location = "My House";
			newEvent.name = "House Party";
			newEvent.state = "KY";
			newEvent.zipcode = "40245";
			newEvent.description = "Cool party at my house";

			await _eiService.SaveEventItem(newEvent);

			var testId = newEvent.objectId;

			//refresh the cache to be sure the data was saved
			//await _eiService.RefreshCache();

			//verify event exists
			EventItem ei = await _eiService.GetEventItem(testId);
			Assert.NotNull(ei);
			Assert.AreEqual (ei.name, "House Party");
		}

		[Test]
		public async void UpdateEventItem()
		{
			EventItem newEvent = new EventItem();
			newEvent.city = "Louisville";
			newEvent.date = "2014-10-01";
			newEvent.isPublic = true;
			newEvent.location = "My House";
			newEvent.name = "Update Test";
			newEvent.state = "KY";
			newEvent.zipcode = "40245";
			newEvent.description = "Testing Update event";

			await _eiService.SaveEventItem(newEvent);

			var testId = newEvent.objectId;

			//refresh the cache to be sure the data was saved
			//await _eiService.RefreshCache();

			EventItem testEI = await _eiService.GetEventItem (testId);
			testEI.description = "Updated Description for Event";
			await _eiService.SaveEventItem (testEI);

			//refres the cache
			//await _eiService.RefreshCache ();

			EventItem ei = await _eiService.GetEventItem(testId);
			Assert.NotNull(ei);
			Assert.AreEqual(ei.description, "Updated Description for Event");
		}

		[Test]
		public async void DeleteEventItem()
		{
			EventItem newEvent = new EventItem();
			newEvent.city = "Louisville";
			newEvent.date = "2014-10-01";
			newEvent.isPublic = true;
			newEvent.location = "My House";
			newEvent.name = "Update Test";
			newEvent.state = "KY";
			newEvent.zipcode = "40245";
			newEvent.description = "Testing Update event";

			await _eiService.SaveEventItem(newEvent);

			var testId = newEvent.objectId;

			//refresh the cache to be sure the data was saved
			//await _eiService.RefreshCache();

			EventItem delEI = await _eiService.GetEventItem (testId);
			Assert.NotNull (delEI);
			await _eiService.DeleteEventItem (delEI);

			//Refresh the cache
			//await _eiService.RefreshCache ();

			EventItem ei = await _eiService.GetEventItem (testId);
			Assert.Null (ei);
		}

		[Test]
		public async void GetEventItems()
		{
			List<EventItem> result = await _eiService.GetItems ();

			Assert.NotNull (result);
			Assert.IsTrue (result.Count () > 1);
		}
	}
}

