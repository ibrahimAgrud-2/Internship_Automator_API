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


        [HttpGet("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person.PersonDTO> GetPersonByID(int ID)
        {
            if (ID < 1)
            {
                return BadRequest($"Not Accepted ID {ID}");
            }
            Person.PersonDTO p = Person.Find(ID);
            if(p==null)
            {
                return NotFound($"No Person With ID {ID}");
            }
            return Ok(p);
         
        }

    }
}
