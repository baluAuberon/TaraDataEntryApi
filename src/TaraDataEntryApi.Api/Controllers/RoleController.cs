using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace TARA.DATAENTRY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("RoleName cannot be null or empty.");
            }



            var concurrencyStamp =Guid.NewGuid().ToString();
           
            var result = await roleManager.CreateAsync(new IdentityRole
            {

                ConcurrencyStamp = concurrencyStamp,
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            });

            if (result.Succeeded)
            {
                return Created($"api/Role/CreateRole/{roleName}", "Role created successfully");
            }
            return BadRequest("Role creation failed");
        }
        [HttpGet]
        [Route("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = roleManager.Roles.Select(r => new { r.Id, r.Name }).ToList();
            return Ok(roles);
        }

        [HttpGet]
        [Route("GetRoleById")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound();
            }

            var roleDto = new { role.Id, role.Name };
            return Ok(roleDto);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdateRole(string roleId, string newName)
        {
            if (string.IsNullOrWhiteSpace(roleId) || string.IsNullOrWhiteSpace(newName))
            {
                return BadRequest("RoleId and NewName cannot be null or empty.");
            }

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound();
            }

            role.Name = newName;
            role.NormalizedName = newName.ToUpper();

            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest("Role update failed");
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound();
            }

            var result = await roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest("Role deletion failed");
        }
    }
}
