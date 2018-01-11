﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiApplication.Infrastructure.ApiControllers
{
    /// <summary>
    /// Base controller for api
    /// </summary>
    [Produces("application/json")]
    public class ApiBaseController : Controller
    {
        /// <summary>
        /// Property used to perform logging.
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>
        /// Creates a new instance with the given value.
        /// </summary>
        /// <param name="logger">ILogger</param>
        public ApiBaseController(ILogger logger)
        {
            Logger = logger;
        }
    }
}
