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

		public static Angle operator +(Angle lhs, int rhs)
		{
			var seconds = (lhs.Seconds + rhs);
			var minutes = (lhs.Minutes + seconds / 60);
			var degrees = (lhs.Degrees + minutes / 60);

			lhs.Seconds = seconds % 60;
			lhs.Minutes = minutes % 60;
			lhs.Degrees = degrees % 360;

			return lhs;
		}

		public static Angle operator +(int lhs, Angle rhs)
		{
			var seconds = (rhs.Seconds + lhs);
			var minutes = (rhs.Minutes + seconds / 60);
			var degrees = (rhs.Degrees + minutes / 60);

			rhs.Seconds = seconds % 60;
			rhs.Minutes = minutes % 60;
			rhs.Degrees = degrees % 360;

			return rhs;
		}


		public static bool operator ==(Angle lhs, Angle rhs) =>
			lhs.Degrees == rhs.Degrees &&
			lhs.Minutes == rhs.Minutes &&
			lhs.Seconds == rhs.Seconds;

		public static bool operator !=(Angle lhs, Angle rhs) =>
			lhs.Degrees != rhs.Degrees ||
			lhs.Minutes != rhs.Minutes ||
			lhs.Seconds != rhs.Seconds;



		public override string ToString() => $"{Degrees} {Minutes} {Seconds}";
		public override bool Equals(object obj) => (Angle)obj == this;
		public override int GetHashCode() => Seconds + Minutes * 60 + Degrees * 3600;

	}
}
