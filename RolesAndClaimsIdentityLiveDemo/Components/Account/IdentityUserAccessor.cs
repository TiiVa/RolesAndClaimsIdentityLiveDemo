using Microsoft.AspNetCore.Identity;
using RolesAndClaimsIdentityLiveDemo.Data;

namespace RolesAndClaimsIdentityLiveDemo.Components.Account
{
	internal sealed class IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager)
	{
		public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
		{
			var user = await userManager.GetUserAsync(context.User);

			if (user is null)
			{
				redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
			}

			return user;
		}

		public async Task<IEnumerable<ApplicationUser>> GetUsersAsync(HttpContext httpContext)
		{
			//TODO: Implementera metoden f�r att h�mta alla anv�ndare som inte �r "Emperor"
			throw new NotImplementedException();
		}
	}
}
