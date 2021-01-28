using IdentityServer.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using DAL.Entities;
using DAL.DataContext;
using System.Linq;
using System.Device.Location;

namespace IdentityServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(
                    ApplicationDbContext db,
                    UserManager<User> userManager,
                    IConfiguration configuration)
        {
            _db = db;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getUserInfo")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var roles = await _userManager.GetRolesAsync(user);

            GeoCoordinate location = new GeoCoordinate(53.9005961, 27.5589895);

            var pointOfSales = _db.PointOfSales
                .ToList()
                .Select(c => new { Id = c.Id, Location = location.GetDistanceTo(new GeoCoordinate(c.Latitude, c.Longitude)) })
                .OrderBy(p => p.Location);

            var allDiscount = _db.Discounts.Where(d => pointOfSales.Select(p => p.Id).Contains(d.Id)).Skip(0).Take(5).Select(d => d).ToList();

            return Ok(new { 
                roles = roles, 
                officeLatilude = _db.Offices.Find(user.OfficeId).Latitude, 
                officeLongitude = _db.Offices.Find(user.OfficeId).Longitude,
                distansy = pointOfSales.ToList(),
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(24),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserEmail = user.Email,
                    UserRole = userRoles,
                });
            }

            return Unauthorized();
        }
    }
}
