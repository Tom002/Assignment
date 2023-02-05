
using Assignment.Exceptions;
using Hellang.Middleware.ProblemDetails;
using MvcProblemDetailsFactory = Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory;

namespace Assignment.Extensions
{
	public static class ErrorHandlingExtensions
	{
		public static IServiceCollection AddAssignmentProblemDetails(this IServiceCollection services)
		{
			services.AddProblemDetails(options =>
			{
				options.Map<EntityNotFoundException>((ctx, ex) =>
					ctx.GetFactory().CreateProblemDetails(
						ctx, StatusCodes.Status404NotFound, "Entity not found!", detail: ex.Message));


				// Every other
				options.Map<Exception>((ctx, _) =>
					ctx.GetFactory().CreateProblemDetails(ctx, StatusCodes.Status500InternalServerError, "Unexpected error"));
			});

			return services;
		}

		private static MvcProblemDetailsFactory GetFactory(this HttpContext ctx)
		{
			return ctx.RequestServices.GetRequiredService<MvcProblemDetailsFactory>();
		}
	}
}
