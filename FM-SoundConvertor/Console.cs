


using System.Linq;
using System.Collections.Generic;

using static System.Console;



namespace FM_SoundConvertor
{
	public class Console
	{
		public static void Log(int Val)
		{
			WriteLine("{0}", Val.ToString());
		}



		public static void Log(string Str)
		{
			WriteLine("{0}", Str);
		}



		public static void Log(string Pref, string Str)
		{
			WriteLine("{0} : {1}", Pref, Str);
		}



		public static void Log(IEnumerable<string> aStr)
		{
			aStr.ToList().ForEach(Str => Log(Str));
		}
	}
}
