using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpOverload
{
	public struct Angle
	{
		public int Degrees;
		public int Minutes;
		public int Seconds;

		public Angle(int degrees, int minutes, int seconds)
		{
			Degrees = degrees;
			Minutes = minutes;
			Seconds = seconds;
		}

		public Angle(Angle rhs)
		{
			Degrees = rhs.Degrees;
			Minutes = rhs.Minutes;
			Seconds = rhs.Seconds;
		}

		public static Angle operator +(Angle lhs, Angle rhs)
		{
			var seconds = (lhs.Seconds + rhs.Seconds);
			var minutes = (lhs.Minutes + rhs.Minutes + seconds / 60);
			var degrees = (lhs.Degrees + rhs.Degrees + minutes / 60);

			lhs.Seconds = seconds % 60;
			lhs.Minutes = minutes % 60;
			lhs.Degrees = degrees % 360;

			return lhs;
		}
		public override string ToString() => $"{Degrees} {Minutes} {Seconds}";

	}
}
