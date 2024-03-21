using AutoPlusCrm.Data.Models;
using AutoPlusCrm.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AutoPlusCrm.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
        public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}
    }
}
