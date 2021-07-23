using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Lab09_LINQ
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 0;
			// taking JObject key of features and putting it into the list.
			IList<JToken> featureList = ParseJSON()["features"].ToList();
			IEnumerable<string> neighborhoods =
				from feature in featureList
				where ((string)feature.SelectToken("properties.neighbordhood") != "")
				// Cast the selectoken method result to a string, where we are passing in our desired input.
				select (string)feature.SelectToken("properties.neighborhood");
			foreach (string names in neighborhoods)
			{
				Console.WriteLine(names);
				count++;
			}
			Console.WriteLine(count);

			//IEnumerable<JToken> filteredFeatures =
			//from feature in featureList
			//where ((string)feature.SelectToken("properties.neighbordhood") != "")
			//select feature;

			// THIS PROJECT......
		}

		public static JObject ParseJSON()
		{
			using (StreamReader reader = File.OpenText("../../../data.json"))
			{
				JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
				return o;
			}
		}
	}
}
