using System.Collections.Immutable;
using System.Net;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // GET  /api/users
    public class UsersController:ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
            
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u=>u.Id==id);
            if(user == null){
                
            }
            return user;

        }


       
        
        /*
         Concept of Asynchronous request 

        Real world example - waiters have taken one order from one customer , one order is preparing , 
        waiter does not wait, he will take another orders as well.

        If we make this asynchronous, sure, we make our requests to the database, but then that gets passed
        on to a different thread known as a delegate.
        And in the meantime, that thread can get on the business of handling other requests, maybe to get
        to the database and get other queries or whatever it needs to do because we have requests coming in
        to the web server.

        But it isn't blocked whilst it's waiting for the database to return.
        Now, once the database has fulfilled its part of the request, then it will notify the original thread
        that this request came in on.

        And then that request can go and pick up the response from the database server and return it to the
        requesting client.
        */
        

    }
}