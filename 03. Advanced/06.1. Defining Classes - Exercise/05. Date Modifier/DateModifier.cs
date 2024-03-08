namespace DefiningClasses
{
    public static class DateModifier
    {
		public static int GetDifference(string start, string end)
		{
			var startDate = DateTime.Parse(start);
			var endDate = DateTime.Parse(end);
			var difference = endDate.Subtract(startDate);
			var result = Math.Abs(difference.Days);
			return result;
		}
    }
}
