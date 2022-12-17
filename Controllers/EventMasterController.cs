using ems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventMasterController : ControllerBase
    {
        private readonly emsContext _context;
        public EventMasterController(emsContext context)
        {
            _context = context;
        }
        // GET: api/<EventMasterController>
        [HttpGet]
        public Response<List<EventMaster>> GetAll()
        {
            try {
                return new Response<List<EventMaster>>
                {
                    Status = true,
                    Message = "All Event Get",
                    Data = _context.EventMaster.ToList()
                };
            }
            catch (Exception e) {
                return new Response<List<EventMaster>>
                {
                    Status = false,
                    Message = "Data Not Get",
                    Data = null
                };
            }
           
        }

        // GET api/<EventMasterController>/5
        [HttpGet("{id}")]
        public async Task<Response<EventMaster>> GetEvent(int id)
        {
            try
            {
                EventMaster data = await _context.EventMaster.Include(x => x.Category).SingleOrDefaultAsync(x => x.EventId == id);
                //data.Category = await _context.EventCategory.SingleOrDefaultAsync(x=>x.CategoryId == data.CategoryId);
                return new Response<EventMaster>
                {
                    Status = true,
                    Message = "Event Get",
                    Data = data
                };
            }
            catch (Exception e)
            {
                return new Response<EventMaster>
                {
                    Status = false,
                    Message = "Data Not Get",
                    Data = null
                };
            }

        } 

        [HttpPost]
        public Response<EventMaster> AddEvent(EventMaster em)
        {
            try
            {
                _context.EventMaster.Add(em);
                _context.SaveChanges();
                return new Response<EventMaster>
                {
                    Status = true,
                    Message = "Data Addedd",
                    Data = em
                };
            }
            catch (Exception e)
            {
                return new Response<EventMaster>
                {
                    Status = false,
                    Message = "Not Added",
                };
            }
        }

        [HttpPut("{id}")]
        public Response<EventMaster> EditEvent(int id,EventMaster data)
        {
            try {
                EventMaster updateData = _context.EventMaster.Where(x => x.EventId == id).SingleOrDefault();
                updateData.EventTitle = data.EventTitle;
                updateData.CategoryId = data.CategoryId;
                updateData.EventDescription = data.EventDescription;
                updateData.EventStartDate = data.EventStartDate;
                updateData.EventEndDate = data.EventEndDate;
                updateData.EventStartTime = data.EventStartTime;
                updateData.EventEndTime = data.EventEndTime;
                updateData.EventVenue = data.EventVenue;
                updateData.City = data.City;
                updateData.State = data.State;
                updateData.Country = data.Country;
                updateData.ThumbnailImage = data.ThumbnailImage;
                updateData.GalleryImage = data.GalleryImage;
                updateData.CreatedAt = data.CreatedAt;
                updateData.UpdatedAt = data.UpdatedAt;
                updateData.CustomerEmail = data.CustomerEmail;
                _context.SaveChanges();
                return new Response<EventMaster>
                {
                    Status = true,
                    Message="Updated Succesfully",
                    Data=updateData
                };
            }
            catch (Exception e) {
                return new Response<EventMaster>
                {
                   Status=false,
                   Message=e.Message,
                   Data=null
                };
            }  
        }

        // DELETE api/<EventMasterController>/5
        [HttpDelete("{id}")]
        public Response<EventMaster> Delete(int id)
        {
            try
            {
               EventMaster removedata= _context.EventMaster.Where(x => x.EventId == id).SingleOrDefault();
                _context.EventMaster.Remove(removedata);
                _context.SaveChanges();
                return new Response<EventMaster>
                {
                    Status = true,
                    Message = "Deleted",
                    Data = removedata
                };
            }
            catch (Exception e)
            {
                return new Response<EventMaster>
                {
                    Status=false,
                    Message=e.Message,
                    Data=null
                }; 
            }
        }

        [HttpPost("Search")]
        //[Route("Search")]
        public List<EventMaster> Search(Search searchVal)
        {
            List<EventMaster> searchResult = _context.EventMaster.Include(c => c.Category).Where(x => x.CategoryId == searchVal.CatId).ToList();

            return searchResult.ToList();
        }

        [HttpGet("MyEvents")]
        public List<EventMaster> MyEvents(string email)
        {
            List<EventMaster> events = _context.EventMaster.Include(x=>x.Category).Where(e => e.CustomerEmail == email).ToList();
            return events;
        }
    }
}
