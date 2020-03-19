


using System;



namespace FM_SoundConvertor
{
	class Program
	{
		static int Main(string[] aArg)
		{
			var Option = new Option();

			int oArg = 0;
			foreach (var Arg in aArg)
			{
				if (Arg[0] == '-')
				{
					switch (Arg)
					{
						case "-fmp":
							{
								Option.bFmp = true;
								break;
							}
						case "-pmd":
							{
								Option.bPmd = true;
								break;
							}
						case "-muc":
							{
								Option.bMuc = true;
								break;
							}
						case "-dat":
							{
								Option.bDat = true;
								break;
							}
					}
					aArg[oArg] = String.Empty;
				}
				++oArg;
			}

			Fmp.Reader(aArg, Option);
			Pmd.Reader(aArg, Option);
			Muc.Reader(aArg, Option);
			Dat.Reader(aArg, Option);
			return 0;
		}
	}
}
