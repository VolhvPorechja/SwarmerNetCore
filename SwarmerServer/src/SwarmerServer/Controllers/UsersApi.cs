/*
 * Swarmer API
 *
 * Internal Swarmer API
 *
 * OpenAPI spec version: 1.0.0-SNAPSHOT
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using Swarmer.Common;
using SwarmerServer.Repositories;
using Swashbuckle.SwaggerGen.Annotations;
using Swarmer.Contracts.Domain;

namespace SwarmerServer.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersApiController : Controller
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        private UsersRepository mRepository;

        public UsersApiController(UsersRepository repository)
        {
            mRepository = repository;
        }

        /// <summary>
        /// Get registered user by id
        /// </summary>
        /// <remarks>This method returns user, that already should be registered. </remarks>
        /// <param name="userId">Id of user</param>
        /// <response code="200">Full info about user</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/users/{userId}")]
        [SwaggerOperation("GetUserById")]
        [SwaggerResponse(200, type: typeof(User))]
        public virtual IActionResult GetUserById([FromRoute]int? userId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<User>(exampleJson)
            : default(User);
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <remarks>Create new user. Id will be generated by service. </remarks>
        /// <param name="creatingUser">User that will be created</param>
        /// <response code="201">User was created</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/users")]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(200, type: typeof(UserInfo))]
        public virtual IActionResult CreateUser([FromBody]User creatingUser)
        {
            Logger.Info(new LogMessage
            {
                Initiator = "SomeUser",
                Data = JObject.FromObject(creatingUser),
                Message = "User Created",
                Code = "AM/U00001",
                ReferenceId = Guid.NewGuid().ToString(),
                System = "AM"
            }.ToJString());

            string exampleJson = null;

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UserInfo>(exampleJson)
            : default(UserInfo);
            return new ObjectResult(example);
        }


        /// <summary>
        /// Get user teams
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <response code="200">Teams in which user has parts</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/users/{userId}/teams")]
        [SwaggerOperation("GetUserTeamsMembership")]
        [SwaggerResponse(200, type: typeof(List<TeamMembership>))]
        public virtual IActionResult GetUserTeamsMembership([FromRoute]int? userId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<TeamMembership>>(exampleJson)
            : default(List<TeamMembership>);
            return new ObjectResult(example);
        }


        /// <summary>
        /// Add user participation in team
        /// </summary>
        
        /// <param name="userId">Id of user</param>
        /// <param name="teamId">Id of team</param>
        /// <response code="201">User participation in team created</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/users/{userId}/teams/{teamId}")]
        [SwaggerOperation("GiveUserTeamMembership")]
        public virtual void GiveUserTeamMembership([FromRoute]int? userId, [FromRoute]int? teamId)
        { 
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get registered in system users
        /// </summary>
        /// <remarks>Get registered users by filter </remarks>
        /// <param name="filter">Json representation of query</param>
        /// <param name="page">Number of page in pagination</param>
        /// <param name="pageSize">Size of single page</param>
        /// <response code="200">An array of users</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/users")]
        [SwaggerOperation("ListUsers")]
        [SwaggerResponse(200, type: typeof(List<UserInfo>))]
        public virtual IActionResult ListUsers([FromQuery]string filter, [FromQuery]int? page, [FromQuery]int? pageSize)
        { 
            return new ObjectResult(mRepository.GetAll());
        }


        /// <summary>
        /// Remove user participation in team
        /// </summary>
        
        /// <param name="userId">Id of user</param>
        /// <param name="teamId">Id of team</param>
        /// <response code="200">User participation in team removed</response>
        /// <response code="0">Unexpected error</response>
        [HttpDelete]
        [Route("/users/{userId}/teams/{teamId}")]
        [SwaggerOperation("RemoveUserTeamMembership")]
        public virtual void RemoveUserTeamMembership([FromRoute]int? userId, [FromRoute]int? teamId)
        { 
            throw new NotImplementedException();
        }


        /// <summary>
        /// Update user data or create user with given id.
        /// </summary>
        /// <remarks>Update user by given id </remarks>
        /// <param name="userId">Id of user</param>
        /// <param name="updatingUser">User data</param>
        /// <response code="200">User data was successfully update.</response>
        /// <response code="201">User was created</response>
        /// <response code="0">Unexpected error</response>
        [HttpPut]
        [Route("/users/{userId}")]
        [SwaggerOperation("UpdateOrCreateUserData")]
        [SwaggerResponse(200, type: typeof(UserInfo))]
        public virtual IActionResult UpdateOrCreateUserData([FromRoute]int? userId, [FromBody]User updatingUser)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UserInfo>(exampleJson)
            : default(UserInfo);
            return new ObjectResult(example);
        }
    }
}
