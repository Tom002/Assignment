using Assignment.Dto;
using FluentValidation;
using System.Runtime.CompilerServices;

namespace Assignment.Pagination
{
	public class PageRequestValidator : AbstractValidator<PageRequest>
	{
		public PageRequestValidator()
		{
			RuleFor(d => d.Page).GreaterThanOrEqualTo(1);
			RuleFor(d => d.PageSize).InclusiveBetween(1, 10);

			When(d => d.From.HasValue && d.To.HasValue, () =>
			{
				RuleFor(d => d.From)
					.Must((pageRequest, _) => pageRequest.To.Value.DayNumber - pageRequest.From.Value.DayNumber <= 30);

				RuleFor(d => d.To)
					.Must((pageRequest, _) => pageRequest.To.Value.DayNumber - pageRequest.From.Value.DayNumber <= 30);
			});	
		}
	}
}
