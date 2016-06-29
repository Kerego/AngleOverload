namespace SharpOverload
{
	public struct Angle
	{
		public int Degrees;
		public int Minutes;
		public int Seconds;
		public int TotalSeconds => Degrees * 3600 + Minutes * 60 + Seconds;
		private const int Limit = 359 * 3600 + 59 * 60 + 60;

		public Angle(int degrees, int minutes, int seconds)
		{
			var m = (minutes + seconds / 60);
			var d = (degrees + m / 60);

			Seconds = seconds % 60;
			Minutes = m % 60;
			Degrees = d % 360;
		}

		#region operators

		#region arithmetic

		private static void FromSeconds(ref Angle angle, int sum)
		{
			if (sum < 0)
				sum = Limit + sum;
			else if (sum > Limit)
				sum = sum - Limit;

			angle.Degrees = sum / 3600;
			angle.Minutes = (sum - angle.Degrees * 3600) / 60;
			angle.Seconds = sum - angle.Degrees * 3600 - angle.Minutes * 60;
		}


		public static Angle operator +(Angle lhs, Angle rhs)
		{
			FromSeconds(ref lhs, lhs.TotalSeconds + rhs.TotalSeconds);
			return lhs;
		}

		public static Angle operator +(Angle lhs, int rhs)
		{
			FromSeconds(ref lhs, lhs.TotalSeconds + rhs);
			return lhs;
		}

		public static Angle operator +(int lhs, Angle rhs)
		{
			FromSeconds(ref rhs, rhs.TotalSeconds + lhs);
			return rhs;
		}


		public static Angle operator -(Angle lhs, Angle rhs)
		{
			FromSeconds(ref lhs, lhs.TotalSeconds - rhs.TotalSeconds);
			return lhs;
		}

		public static Angle operator -(Angle lhs, int rhs)
		{
			FromSeconds(ref lhs, lhs.TotalSeconds - rhs);
			return lhs;
		}

		//not sure if needed
		public static Angle operator -(int lhs, Angle rhs)
		{
			FromSeconds(ref rhs, lhs - rhs.TotalSeconds);
			return rhs;
		}
		#endregion
	
		#region logical
		public static bool operator ==(Angle lhs, Angle rhs) =>
			lhs.Degrees == rhs.Degrees &&
			lhs.Minutes == rhs.Minutes &&
			lhs.Seconds == rhs.Seconds;

		public static bool operator !=(Angle lhs, Angle rhs) =>
			lhs.Degrees != rhs.Degrees ||
			lhs.Minutes != rhs.Minutes ||
			lhs.Seconds != rhs.Seconds;

		public static bool operator >(Angle lhs, Angle rhs)
		{
			if (lhs.Degrees == rhs.Degrees)
				if (lhs.Minutes == rhs.Minutes)
					return lhs.Seconds > rhs.Seconds;
				else return lhs.Minutes > rhs.Minutes;
			else return lhs.Degrees > rhs.Degrees;
		}


		public static bool operator <(Angle lhs, Angle rhs)
		{
			if (lhs.Degrees == rhs.Degrees)
				if (lhs.Minutes == rhs.Minutes)
					return lhs.Seconds < rhs.Seconds;
				else return lhs.Minutes < rhs.Minutes;
			else return lhs.Degrees < rhs.Degrees;
		}

		#endregion

		#endregion

		public override string ToString() => 
			$"{Degrees, 3}d {Minutes, 2}m {Seconds, 2}s";
		public override bool Equals(object obj) => (Angle)obj == this;
		public override int GetHashCode() => TotalSeconds;

	}
}
