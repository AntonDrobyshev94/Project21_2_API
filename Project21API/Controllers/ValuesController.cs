using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project21API.Data;
using Project21API.Models;

namespace Project21API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Repository repositoryData;

        public ValuesController(Repository repositoryData)
        {
            this.repositoryData = repositoryData;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<IContact> Get()
        {
            return repositoryData.GetContacts();
        }

        // GET api/values/5
        [Route("Details/{id}")]
        public async Task<Contact> ContactDetails(int id)
        {
            return await repositoryData.Details(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Contact value)
        {
            repositoryData.AddContacts(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositoryData.DeleteContact(id);
        }

        [HttpPost]
        [Route("ChangeContactById/{id}")]
        public void ChangeContactById(int id, Contact contact)
        {
            repositoryData.ChangeContact(id, contact);
        }

    }
}
