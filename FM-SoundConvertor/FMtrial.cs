


using System;

using static FM_SoundConvertor.Path;
using static FM_SoundConvertor.File;
using static FM_SoundConvertor.Console;



namespace FM_SoundConvertor
{
	class FMtrial
	{
		enum eName
		{
			Name0, Name1, Name2, Name3, Name4, Name5, Name6, Name7, Name8, Name9, Name10, Name11, Name12, Name13, Name14, Name15,
			Name16, Name17, Name18, Name19, Name20, _0, _1, _2,
		}
		
		enum ePut
		{
			_0,
			AL, FB,
			_1, _2, _3, _4, _5, _6, _7, _8, _9,
			AR0, DR0, SR0, RR0, SL0, TL0, KS0, ML0, DT1_0, DT2_0, WF0,
			AR1, DR1, SR1, RR1, SL1, TL1, KS1, ML1, DT1_1, DT2_1, WF1,
			AR2, DR2, SR2, RR2, SL2, TL2, KS2, ML2, DT1_2, DT2_2, WF2,
			AR3, DR3, SR3, RR3, SL3, TL3, KS3, ML3, DT1_3, DT2_3, WF3,
			_10, _11, MX, _13, _14, _15, _16, _17, _18, _19,
			_20, _21, _22, _23, _24, _25, _26, _27, _28, _29,
			_30, _31, _32, _33, _34, _35, _36, _37, _38, _39,
			_40, _41, _42, _43, _44, _45, _46, _47, _48, _49,
			OS, PB,
		}
		



		static int ToneLength()
		{
			return 0x124;
		}

		static int HeadLength()
		{
			return 0xa0;
		}

		static int NameLength()
		{
			return System.Enum.GetNames(typeof(eName)).Length;
		}

		static int PutLength()
		{
			return NameLength() + (System.Enum.GetNames(typeof(ePut)).Length * sizeof(float));
		}

		static int FxbLength()
		{
			return HeadLength() + (ToneLength() * PutLength());
		}



		public static byte[] New()
		{
			return new byte[FxbLength()];
		}



		static int Get(byte[] Buffer, int O, int e, int Max)
		{
			return (int)Math.Round(BitConverter.ToSingle(Buffer, O + (e * sizeof(float))) * Max);
		}



		static void Get(ref Tone @Tone, byte[] Buffer, int i)
		{
			int o = HeadLength() + (i * PutLength());
			int O = o + NameLength();
			Tone.aOp[0].AR = Get(Buffer, O, (int)ePut.AR0, 31);
			Tone.aOp[1].AR = Get(Buffer, O, (int)ePut.AR1, 31);
			Tone.aOp[2].AR = Get(Buffer, O, (int)ePut.AR2, 31);
			Tone.aOp[3].AR = Get(Buffer, O, (int)ePut.AR3, 31);
			Tone.aOp[0].DR = Get(Buffer, O, (int)ePut.DR0, 31);
			Tone.aOp[1].DR = Get(Buffer, O, (int)ePut.DR1, 31);
			Tone.aOp[2].DR = Get(Buffer, O, (int)ePut.DR2, 31);
			Tone.aOp[3].DR = Get(Buffer, O, (int)ePut.DR3, 31);
			Tone.aOp[0].SR = Get(Buffer, O, (int)ePut.SR0, 31);
			Tone.aOp[1].SR = Get(Buffer, O, (int)ePut.SR1, 31);
			Tone.aOp[2].SR = Get(Buffer, O, (int)ePut.SR2, 31);
			Tone.aOp[3].SR = Get(Buffer, O, (int)ePut.SR3, 31);
			Tone.aOp[0].RR = Get(Buffer, O, (int)ePut.RR0, 15);
			Tone.aOp[1].RR = Get(Buffer, O, (int)ePut.RR1, 15);
			Tone.aOp[2].RR = Get(Buffer, O, (int)ePut.RR2, 15);
			Tone.aOp[3].RR = Get(Buffer, O, (int)ePut.RR3, 15);
			Tone.aOp[0].SL = Get(Buffer, O, (int)ePut.SL0, 15);
			Tone.aOp[1].SL = Get(Buffer, O, (int)ePut.SL1, 15);
			Tone.aOp[2].SL = Get(Buffer, O, (int)ePut.SL2, 15);
			Tone.aOp[3].SL = Get(Buffer, O, (int)ePut.SL3, 15);
			Tone.aOp[0].TL = Get(Buffer, O, (int)ePut.TL0, 127);
			Tone.aOp[1].TL = Get(Buffer, O, (int)ePut.TL1, 127);
			Tone.aOp[2].TL = Get(Buffer, O, (int)ePut.TL2, 127);
			Tone.aOp[3].TL = Get(Buffer, O, (int)ePut.TL3, 127);
			Tone.aOp[0].KS = Get(Buffer, O, (int)ePut.KS0, 3);
			Tone.aOp[1].KS = Get(Buffer, O, (int)ePut.KS1, 3);
			Tone.aOp[2].KS = Get(Buffer, O, (int)ePut.KS2, 3);
			Tone.aOp[3].KS = Get(Buffer, O, (int)ePut.KS3, 3);
			Tone.aOp[0].ML = Get(Buffer, O, (int)ePut.ML0, 15);
			Tone.aOp[1].ML = Get(Buffer, O, (int)ePut.ML1, 15);
			Tone.aOp[2].ML = Get(Buffer, O, (int)ePut.ML2, 15);
			Tone.aOp[3].ML = Get(Buffer, O, (int)ePut.ML3, 15);
			Tone.aOp[0].DT = Get(Buffer, O, (int)ePut.DT1_0, 99);
			Tone.aOp[1].DT = Get(Buffer, O, (int)ePut.DT1_1, 99);
			Tone.aOp[2].DT = Get(Buffer, O, (int)ePut.DT1_2, 99);
			Tone.aOp[3].DT = Get(Buffer, O, (int)ePut.DT1_3, 99);
			Tone.aOp[0].DT2 = Get(Buffer, O, (int)ePut.DT2_0, 3);
			Tone.aOp[1].DT2 = Get(Buffer, O, (int)ePut.DT2_1, 3);
			Tone.aOp[2].DT2 = Get(Buffer, O, (int)ePut.DT2_2, 3);
			Tone.aOp[3].DT2 = Get(Buffer, O, (int)ePut.DT2_3, 3);
			Tone.AL = Get(Buffer, O, (int)ePut.AL, 7);
			Tone.FB = Get(Buffer, O, (int)ePut.FB, 7);

			var aChar = new char[]
			{
				(char)Buffer[o + (int)eName.Name0],
				(char)Buffer[o + (int)eName.Name1],
				(char)Buffer[o + (int)eName.Name2],
				(char)Buffer[o + (int)eName.Name3],
				(char)Buffer[o + (int)eName.Name4],
				(char)Buffer[o + (int)eName.Name5],
				(char)Buffer[o + (int)eName.Name6],
				(char)Buffer[o + (int)eName.Name7],
				(char)Buffer[o + (int)eName.Name8],
				(char)Buffer[o + (int)eName.Name9],
				(char)Buffer[o + (int)eName.Name10],
				(char)Buffer[o + (int)eName.Name11],
				(char)Buffer[o + (int)eName.Name12],
				(char)Buffer[o + (int)eName.Name13],
				(char)Buffer[o + (int)eName.Name14],
				(char)Buffer[o + (int)eName.Name15],
				(char)Buffer[o + (int)eName.Name16],
				(char)Buffer[o + (int)eName.Name17],
				(char)Buffer[o + (int)eName.Name18],
				(char)Buffer[o + (int)eName.Name19],
				(char)Buffer[o + (int)eName.Name20],
			};
			Tone.Name = "";
			foreach (var Char in aChar) if (Char != 0) Tone.Name += Char.ToString();

			Tone.Number = i;
		}



		static void Put(byte[] Buffer, int O, int e, int Max, int v)
		{
			var aPut = BitConverter.GetBytes((float)v / (float)Max);
			Array.Copy(aPut, 0, Buffer, O + (e * sizeof(float)), aPut.Length);
		}



		public static void Put(Tone @Tone, ref byte[] Buffer)
		{
			if (Tone.IsValid() && Tone.Number < ToneLength())
			{
				int o = HeadLength() + (Tone.Number * PutLength());
				int O = o + NameLength();
				Put(Buffer, O, (int)ePut.AR0, 31, Tone.aOp[0].AR);
				Put(Buffer, O, (int)ePut.AR1, 31, Tone.aOp[1].AR);
				Put(Buffer, O, (int)ePut.AR2, 31, Tone.aOp[2].AR);
				Put(Buffer, O, (int)ePut.AR3, 31, Tone.aOp[3].AR);
				Put(Buffer, O, (int)ePut.DR0, 31, Tone.aOp[0].DR);
				Put(Buffer, O, (int)ePut.DR1, 31, Tone.aOp[1].DR);
				Put(Buffer, O, (int)ePut.DR2, 31, Tone.aOp[2].DR);
				Put(Buffer, O, (int)ePut.DR3, 31, Tone.aOp[3].DR);
				Put(Buffer, O, (int)ePut.SR0, 31, Tone.aOp[0].SR);
				Put(Buffer, O, (int)ePut.SR1, 31, Tone.aOp[1].SR);
				Put(Buffer, O, (int)ePut.SR2, 31, Tone.aOp[2].SR);
				Put(Buffer, O, (int)ePut.SR3, 31, Tone.aOp[3].SR);
				Put(Buffer, O, (int)ePut.RR0, 15, Tone.aOp[0].RR);
				Put(Buffer, O, (int)ePut.RR1, 15, Tone.aOp[1].RR);
				Put(Buffer, O, (int)ePut.RR2, 15, Tone.aOp[2].RR);
				Put(Buffer, O, (int)ePut.RR3, 15, Tone.aOp[3].RR);
				Put(Buffer, O, (int)ePut.SL0, 15, Tone.aOp[0].SL);
				Put(Buffer, O, (int)ePut.SL1, 15, Tone.aOp[1].SL);
				Put(Buffer, O, (int)ePut.SL2, 15, Tone.aOp[2].SL);
				Put(Buffer, O, (int)ePut.SL3, 15, Tone.aOp[3].SL);
				Put(Buffer, O, (int)ePut.TL0, 127, Tone.aOp[0].TL);
				Put(Buffer, O, (int)ePut.TL1, 127, Tone.aOp[1].TL);
				Put(Buffer, O, (int)ePut.TL2, 127, Tone.aOp[2].TL);
				Put(Buffer, O, (int)ePut.TL3, 127, Tone.aOp[3].TL);
				Put(Buffer, O, (int)ePut.KS0, 3, Tone.aOp[0].KS);
				Put(Buffer, O, (int)ePut.KS1, 3, Tone.aOp[1].KS);
				Put(Buffer, O, (int)ePut.KS2, 3, Tone.aOp[2].KS);
				Put(Buffer, O, (int)ePut.KS3, 3, Tone.aOp[3].KS);
				Put(Buffer, O, (int)ePut.ML0, 15, Tone.aOp[0].ML);
				Put(Buffer, O, (int)ePut.ML1, 15, Tone.aOp[1].ML);
				Put(Buffer, O, (int)ePut.ML2, 15, Tone.aOp[2].ML);
				Put(Buffer, O, (int)ePut.ML3, 15, Tone.aOp[3].ML);
				Put(Buffer, O, (int)ePut.DT1_0, 99, Tone.aOp[0].DT);
				Put(Buffer, O, (int)ePut.DT1_1, 99, Tone.aOp[1].DT);
				Put(Buffer, O, (int)ePut.DT1_2, 99, Tone.aOp[2].DT);
				Put(Buffer, O, (int)ePut.DT1_3, 99, Tone.aOp[3].DT);
				Put(Buffer, O, (int)ePut.DT2_0, 3, Tone.aOp[0].DT2);
				Put(Buffer, O, (int)ePut.DT2_1, 3, Tone.aOp[1].DT2);
				Put(Buffer, O, (int)ePut.DT2_2, 3, Tone.aOp[2].DT2);
				Put(Buffer, O, (int)ePut.DT2_3, 3, Tone.aOp[3].DT2);
				Put(Buffer, O, (int)ePut.AL, 7, Tone.AL);
				Put(Buffer, O, (int)ePut.FB, 7, Tone.FB);
				Put(Buffer, O, (int)ePut.MX, 7, 7);
				Put(Buffer, O, (int)ePut.OS, 1, 1);
				Put(Buffer, O, (int)ePut.PB, 127, 2);

				if (String.IsNullOrWhiteSpace(Tone.Name))
				{
					Tone.Name = Tone.Number.ToString();
				}
				Buffer[o + (int)eName.Name0] = (byte)((Tone.Name.Length > 0) ? Tone.Name[0] : 0);
				Buffer[o + (int)eName.Name1] = (byte)((Tone.Name.Length > 1) ? Tone.Name[1] : 0);
				Buffer[o + (int)eName.Name2] = (byte)((Tone.Name.Length > 2) ? Tone.Name[2] : 0);
				Buffer[o + (int)eName.Name3] = (byte)((Tone.Name.Length > 3) ? Tone.Name[3] : 0);
				Buffer[o + (int)eName.Name4] = (byte)((Tone.Name.Length > 4) ? Tone.Name[4] : 0);
				Buffer[o + (int)eName.Name5] = (byte)((Tone.Name.Length > 5) ? Tone.Name[5] : 0);
				Buffer[o + (int)eName.Name6] = (byte)((Tone.Name.Length > 6) ? Tone.Name[6] : 0);
				Buffer[o + (int)eName.Name7] = (byte)((Tone.Name.Length > 7) ? Tone.Name[7] : 0);
				Buffer[o + (int)eName.Name8] = (byte)((Tone.Name.Length > 8) ? Tone.Name[8] : 0);
				Buffer[o + (int)eName.Name9] = (byte)((Tone.Name.Length > 9) ? Tone.Name[9] : 0);
				Buffer[o + (int)eName.Name10] = (byte)((Tone.Name.Length > 10) ? Tone.Name[10] : 0);
				Buffer[o + (int)eName.Name11] = (byte)((Tone.Name.Length > 11) ? Tone.Name[11] : 0);
				Buffer[o + (int)eName.Name12] = (byte)((Tone.Name.Length > 12) ? Tone.Name[12] : 0);
				Buffer[o + (int)eName.Name13] = (byte)((Tone.Name.Length > 13) ? Tone.Name[13] : 0);
				Buffer[o + (int)eName.Name14] = (byte)((Tone.Name.Length > 14) ? Tone.Name[14] : 0);
				Buffer[o + (int)eName.Name15] = (byte)((Tone.Name.Length > 15) ? Tone.Name[15] : 0);
				Buffer[o + (int)eName.Name16] = (byte)((Tone.Name.Length > 16) ? Tone.Name[16] : 0);
				Buffer[o + (int)eName.Name17] = (byte)((Tone.Name.Length > 17) ? Tone.Name[17] : 0);
				Buffer[o + (int)eName.Name18] = (byte)((Tone.Name.Length > 18) ? Tone.Name[18] : 0);
				Buffer[o + (int)eName.Name19] = (byte)((Tone.Name.Length > 19) ? Tone.Name[19] : 0);
				Buffer[o + (int)eName.Name20] = (byte)((Tone.Name.Length > 20) ? Tone.Name[20] : 0);
			}
		}



		public static bool IsValid(byte[] Buffer)
		{
			return (Buffer[0x00] == (byte)'C'
				&&	Buffer[0x01] == (byte)'c'
				&&	Buffer[0x02] == (byte)'n'
				&&	Buffer[0x03] == (byte)'K'
				&&	Buffer[0x05] == 0x01
				&&	Buffer[0x06] == 0xdb
				&&	Buffer[0x07] == 0x18
				&&	Buffer[0x08] == (byte)'F'
				&&	Buffer[0x09] == (byte)'B'
				&&	Buffer[0x0a] == (byte)'C'
				&&	Buffer[0x0b] == (byte)'h'
				&&	Buffer[0x0f] == 0x01
				&&	Buffer[0x10] == (byte)'J'
				&&	Buffer[0x11] == (byte)'K'
				&&	Buffer[0x12] == (byte)'J'
				&&	Buffer[0x13] == (byte)'M'
				&&	Buffer[0x17] == 0x01
				&&	Buffer[0x1a] == 0x01
				&&	Buffer[0x1b] == 0x24
				&&	Buffer[0x9d] == 0x01
				&&	Buffer[0x9e] == 0xda
				&&	Buffer[0x9f] == 0x80
			);
		}



		public static void Reader(string Path, Option @Option)
		{
			var Buffer = ReadByte(Path);
			if (Buffer.Length == FxbLength() && IsValid(Buffer))
			{
				Tone vTone = new Tone();

				var BufferMuc = "";
				var BufferDat = Dat.New();
				var BufferFmp = "";
				var BufferPmd = "";
				var BufferVopm = Vopm.New();

				for (int i = 0; i < ToneLength(); ++i)
				{
					Get(ref vTone, Buffer, i);

					if (Option.bMuc) Muc.Put(vTone, ref BufferMuc);
					if (Option.bDat) Dat.Put(vTone, ref BufferDat);
					if (Option.bFmp) Fmp.Put(vTone, ref BufferFmp);
					if (Option.bPmd) Pmd.Put(vTone, ref BufferPmd);
					if (Option.bVopm) Vopm.Put(vTone, ref BufferVopm);
				}

				if (Option.bMuc) Muc.Writer(Path, BufferMuc);
				if (Option.bDat) Dat.Writer(Path, BufferDat);
				if (Option.bFmp) Fmp.Writer(Path, BufferFmp);
				if (Option.bPmd) Pmd.Writer(Path, BufferPmd);
				if (Option.bVopm) Vopm.Writer(Path, BufferVopm);
			}
		}



		public static void Reader(string[] aPath, Option @Option)
		{
			foreach (var Path in aPath)
			{
				if (!String.IsNullOrWhiteSpace(Path) && Extension(Path) == ".fxb") Reader(Path, Option);
			}
		}



		public static void Writer(string Path, byte[] Buffer)
		{
			Buffer[0x00] = (byte)'C';
			Buffer[0x01] = (byte)'c';
			Buffer[0x02] = (byte)'n';
			Buffer[0x03] = (byte)'K';
			Buffer[0x05] = 0x01;
			Buffer[0x06] = 0xdb;
			Buffer[0x07] = 0x18;
			Buffer[0x08] = (byte)'F';
			Buffer[0x09] = (byte)'B';
			Buffer[0x0a] = (byte)'C';
			Buffer[0x0b] = (byte)'h';
			Buffer[0x0f] = 0x01;
			Buffer[0x10] = (byte)'J';
			Buffer[0x11] = (byte)'K';
			Buffer[0x12] = (byte)'J';
			Buffer[0x13] = (byte)'M';
			Buffer[0x17] = 0x01;
			Buffer[0x1a] = 0x01;
			Buffer[0x1b] = 0x24;
			Buffer[0x9d] = 0x01;
			Buffer[0x9e] = 0xda;
			Buffer[0x9f] = 0x80;

			WriteByte(ChangeExtension(Path, ".fxb"), Buffer);
		}
	}
}
