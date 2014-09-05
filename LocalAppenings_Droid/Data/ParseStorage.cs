using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;

using LocalAppenings;

namespace LocalAppenings_Droid
{
	public class ParseStorage
	{
		protected ParseStorage ()
		{

		}

		/**
		 * Takes an object and converts it into a ParseObject 
		**/
		public static ParseObject ToParseObject (object obj){
			string parseClass = "";

			//Get the type of Object
			Type t = obj.GetType ();

			//Get only the items with Json Property Attribute because they are the only ones that need to go into parse
			IList<PropertyInfo> props = new List<PropertyInfo>(t.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(JsonPropertyAttribute))));

			//if parse class name is set in class
			if (!string.IsNullOrEmpty (t.GetProperty ("ParseClassName").GetValue (obj).ToString ())) {
				parseClass = obj.GetType().GetProperty ("ParseClassName").GetValue (obj, null).ToString ();
			}else{
				//Set Parse Class name to class name
				parseClass = t.Name;
			}

			var po = new ParseObject(parseClass);

			foreach (PropertyInfo prop in props) {
				string name = prop.Name;
				//put object key and value into  parse object
				po [name] = prop.GetValue (obj, null);
			}

			return po;
		}


		/**
		 * Takes a Parse Object and converts it into the object passed 
		**/
		public static object FromParseObject(ParseObject po, string className){
			//Get the Type of Object
			Type t = Type.GetType (className);

			//Get only the items with Json Property Attribute because they are the only ones that need to go into parse
			IList<PropertyInfo> props = new List<PropertyInfo>(t.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(JsonPropertyAttribute))));

			object item = Activator.CreateInstance (t);

			//loop through the objects properties and set them if they are in the Parse Object being passed
			foreach (PropertyInfo prop in props) {
				t.GetProperty (prop.Name).SetValue (item, po [prop.Name], null);
			}

			return item;

		}

	}
}

