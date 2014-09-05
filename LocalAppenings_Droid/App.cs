using System;
using Android.App;
using Android.Runtime;
using Parse;

namespace LocalAppenings_Droid
{
	[Application]
	public class App : Application
	{
		public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{

		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			ParseClient.Initialize ("3BpgkH2jIyX00MXvL4J5d2ghOi2ezPXbcQI5crY0", "RisMh3o6zowO6Qx47vu10k2M3f1mX27gmgOQLwH8");
		}
	}
}

