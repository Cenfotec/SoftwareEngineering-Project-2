using Core;
using Entities_POJO;
using System;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Bitacoras;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Advertisement API methods
    /// </summary>
    public class AdvertisementController : ApiController
    {
        private ApiResponse apiResponse = new ApiResponse();

        /// <summary>
        /// GET api/<controller>
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {
                var advertisementManager = new AdvertisementManagement();
                apiResponse = new ApiResponse();
                var advertisements = advertisementManager.RetrieveAll();
                apiResponse.Data = advertisements;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// GET api/<controller>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                var advertisementManager = new AdvertisementManagement();
                var advertisement = new Advertisement() { Id = id };
                advertisement = advertisementManager.RetrieveById(advertisement);
                apiResponse = new ApiResponse
                {
                    Data = advertisement
                };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// POST api/Advertisement<controller>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Registered]
        public IHttpActionResult Post(Advertisement advertisement)
        {
            try
            {
                var advertisementManager = new AdvertisementManagement();
                advertisementManager.Create(advertisement);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// PUT api/<controller>/5
        /// </summary>
        /// <returns></returns>
        [Modified]
        public IHttpActionResult Put(Advertisement advertisement)
        {
            try
            {
                var advertisementManager = new AdvertisementManagement();
                advertisementManager.Update(advertisement);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// DELETE api/<controller>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Deleted]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var advertisementManager = new AdvertisementManagement();
                advertisementManager.Delete(new Advertisement { Id = id });
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}