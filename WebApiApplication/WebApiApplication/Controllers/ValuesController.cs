using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApiApplication.Infrastructure.ApiControllers;

namespace WebApiApplication.Controllers
{
    /// <summary>
    /// Values controller
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : ApiBaseController
    {
        /// <summary>
        /// Creates a new instance with the given value.
        /// </summary>
        /// <param name="logger">ILogger</param>
        public ValuesController(ILogger<ValuesController> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Get all values
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        /// 
        ///     GET api/values
        ///     
        /// </remarks>
        /// <returns>All values</returns>
        /// <response code="201">Returns the get values</response>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get value by id
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        /// 
        ///     GET api/values/{id}
        ///     
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Value by id</returns>
        /// <response code="201">Returns the value</response>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates values.
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        /// 
        ///     POST api/values
        ///     {
        ///         "values": [ "string", "string" ]
        ///     }
        /// 
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>New Created Value</returns>
        /// <response code="201">Returns the newly created value</response>
        /// <response code="400">If the body is null</response>
        [HttpPost]
        // [ProducesResponseType(typeof(string), 201)]
        // [ProducesResponseType(typeof(string), 400)]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Update value.
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        /// 
        ///     PUT api/values/{id}
        ///     {
        ///         "value": "new string"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>Update value</returns>
        /// <response code="201">Returns the updated value</response>
        /// <response code="400">If the body is null</response>
        [HttpPut("{id}")]
        // [ProducesResponseType(typeof(string), 201)]
        // [ProducesResponseType(typeof(string), 400)]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete value by id.
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        /// 
        ///     DELETE api/values/{id}
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Delete value</returns>
        /// <response code="201">Returns the deleted value</response>
        /// <response code="400">If the body is null</response>
        [HttpDelete("{id}")]
        // [ProducesResponseType(typeof(string), 201)]
        // [ProducesResponseType(typeof(string), 400)]
        public void Delete(int id)
        {
        }
    }
}
