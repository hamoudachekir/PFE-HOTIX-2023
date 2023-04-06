using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.HOTIX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFamilyController : ControllerBase
    {

        private IConfiguration configuration;

        public SubFamilyController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        [Route("GetSubFamilys")]
        public ApiResponse GetSubFamily()
        {
            try
            {
                Entities.SubFamilys _Data = Repository.SubFamily.GetAll();
                if (_Data != null)
                {
                    return new ApiResponse
                    {
                        Success = true,
                        Error = -1,
                        Message = "Success",
                        Data = _Data
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Error = 2,
                        Message = "No Data Found!!!",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        [HttpPut]
        [Route("AddSubFamily")]
        public ApiResponse AddSubFamily(Entities.SubFamily subfamily)
        {
            try
            {
                bool _Success = Repository.SubFamily.Add(subfamily);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "SubFamily Add Failed!!!!!!",
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        [HttpPost]
        [Route("UpdateSubFamily")]
        public ApiResponse UpdateSubFamily(Entities.SubFamily subfamily)
        {
            try
            {
                bool _Success = Repository.SubFamily.Update(subfamily);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "SubFamily Update Failed!!!",
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        [HttpPost]
        [Route("RemoveUser")]
        public ApiResponse RemoveSubFamily(Entities.SubFamily subfamily)
        {
            try
            {
                bool _Success = Repository.SubFamily.Remove(subfamily);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "SubFamily Delete Failed!!!",
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
