using Humanizer;

namespace Assignment.Pagination
{
	public class PageRequest
	{
		public int PageSize { get; set; } = 5;

		public int Page { get; set; } = 1;

		public DateOnly? From { get; set; }

		public DateOnly? To { get; set; }

		public void InitializeIntervalFilters()
		{
				if(!From.HasValue)
					From = To.HasValue ? To.Value.AddDays(-30) : DateOnly.FromDateTime(DateTime.Now.AddDays(-30));
				if(!To.HasValue)
					To = From.HasValue ? From.Value.AddDays(30) : DateOnly.FromDateTime(DateTime.Now);
		}
	}
}
