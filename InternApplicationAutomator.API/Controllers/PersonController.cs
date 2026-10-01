using IAA.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Data;




namespace InternApplicationAutomator.API.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class PersonController:ControllerBase
    {
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Person.PersonDTO>> GetAllPeople()
        {

            List<Person.PersonDTO> StudentList = Person.GetAllPeople();
            if (StudentList.Count == 0)
            {
                return NotFound("No Data Available in the Table");
            }

            return Ok(StudentList);
        }

    }
}
