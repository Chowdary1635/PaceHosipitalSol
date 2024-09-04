using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaceHosipital.DataAccess.IRepository;
using PaceHosipital.Models;
using System.Threading.Tasks;
using System;

namespace PaceHosipital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTypeController : ControllerBase
    {
        public IAdminTypeRepository AdmRef;
        public AdminTypeController(IAdminTypeRepository _AdmRef)
        {
            AdmRef = _AdmRef;
        }
        [HttpPost]
        [Route("InsertAdminType")]
        public async Task<IActionResult> InsertAdminType(AdminType Admin)
        {
            try
            {
                var count = await AdmRef.InsertAdminType(Admin);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Inserted...!");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + e.Message + "\n we will solve this issue soon");
            }

        }
        [HttpGet]
        [Route("AllAdminTypes")]
        public async Task<IActionResult> AllAdminTypes()
        {
            try
            {
                var AdmList = await AdmRef.AllAdminTypes();
                if (AdmList.Count > 0)
                {
                    return Ok(AdmList);
                }
                else
                {
                    return NotFound("Record are Not available in the database...!");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + e.Message + "\n we will solve this issue soon");
            }

        }
        [HttpGet]
        [Route("GetAdminTypeById")]
        public async Task<IActionResult> GetAdminTypeById(int AdminTypeId)
        {
            try
            {
                var Adm = await AdmRef.GetAdminTypeById(AdminTypeId);
                if (Adm != null)
                {
                    return Ok(Adm);
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
        [Route("GetAdminTypeByName")]
        public async Task<IActionResult> GetAdminTypeByName(string AdminTypeName)
        {
            try
            {
                var AdmList = await AdmRef.GetAdminTypeByName(AdminTypeName);
                if (AdmList.Count > 0)
                {
                    return Ok(AdmList);
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
        [HttpPut]
        [Route("UpdateAdminType")]
        public async Task<IActionResult> UpdateAdminType(AdminType Adminty)
        {
            try
            {
                var Count = await AdmRef.UpdateAdminType(Adminty);
                if (Count > 0)
                {
                    return Ok(Count);
                }
                else
                {
                    return NotFound("Record is Not Updated...!");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + e.Message + "\n we will solve this issue soon");
            }

        }
        [HttpDelete]
        [Route("DeleteAdminType")]
        public async Task<IActionResult> DeleteAdminType(int AdminTypeId)
        {
            try
            {
                var Count = await AdmRef.DeleteAdminType(AdminTypeId);
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
