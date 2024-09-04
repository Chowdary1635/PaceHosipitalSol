using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaceHosipital.DataAccess.IRepository;
using PaceHosipital.DataAccess.Repository;
using PaceHosipital.Models;
using System.Threading.Tasks;
using System;

namespace PaceHosipital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminRepository AdmRef;
        public AdminController(IAdminRepository admRef)
        {
            AdmRef = admRef;
        }
        [HttpPost]
        [Route("AdminRegistration")]
        public async Task<IActionResult> AdminRegistration(Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var count = await AdmRef.AdminRegistration(admin);
                    if (count > 0)
                    {
                        return Ok(count);
                    }
                    else
                    {
                        return BadRequest("Records not Registered");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }
        }
        [HttpGet]
        [Route("AllOperationalAdmins")]
        public async Task<IActionResult> AllOperationalAdmins()
        {
            try
            {
                var AdmList = await AdmRef.AllOperationalAdmins();
                if (AdmList.Count > 0)
                {
                    return Ok(AdmList);
                }
                else
                {
                    return NotFound("Record is Not available in the database...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }

        }
        [HttpGet]
        [Route("AdminByAdminEmail")]
        public async Task<IActionResult> AdminByAdminEmail(string Email)
        {
            try
            {
                var Em = await AdmRef.AdminByAdminEmail(Email);
                if (Em != null)
                {
                    return Ok(Em);
                }
                else
                {
                    return NotFound("Record is Not available in the database...!");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + e.Message + "\n we will solve this issue soon");
            }

        }


        [HttpGet]
        [Route("CheckLogin")]
        public async Task<IActionResult> CheckLogin(string Email, string Password)
        {
            try
            {
                var Em = await AdmRef.CheckLogin(Email, Password);

                return Ok(Em);
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + e.Message + "\n we will solve this issue soon");
            }

        }




        [HttpPut]
        [Route("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin(Admin admin)
        {
            try
            {
                var Count = await AdmRef.UpdateAdmin(admin);
                if (Count > 0)
                {
                    return Ok(Count);
                }
                else
                {
                    return NotFound("Record was not Update...!");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + e.Message + "\n we will solve this issue soon");
            }

        }
        [HttpDelete]
        [Route("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int AdminId)
        {
            try
            {
                var Count = await AdmRef.DeleteAdmin(AdminId);
                if (Count > 0)
                {
                    return Ok(Count);
                }
                else
                {
                    return NotFound("Record is Not Deleted...!");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + e.Message + "\n we will solve this issue soon");
            }

        }
    }
}
