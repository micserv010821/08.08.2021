using kantech2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kantech2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private static List<Message> messages = new List<Message>();

        private static int counter = 0;

        static MessagesController()
        {
            messages.AddRange(new List<Message>()
            {
                new Message
                {
                    Id = ++counter,
                    Sender = "Danny",
                    Body = "Hello from Danny"
                },
                new Message
                {
                    Id = ++counter,
                    Sender = "Galit",
                    Body = "How are you today?"
                },
                new Message
                {
                    Id = ++counter,
                    Sender = "Moshe",
                    Body = "I'm back from vacation"
                },                
                new Message
                {
                    Id = ++counter,
                    Sender = "Hadar",
                    Body = "I just woke up!"
                },
            });
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return messages;
        }

        [HttpGet("{id}")]
        public Message Get(int id)
        {
            return messages.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Message message)
        {
            message.Id = ++counter;
            messages.Add(message);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message message)
        {
            Message for_update = messages.FirstOrDefault(_ => _.Id == id);
            if (for_update != null)
            {
                for_update.Sender = message.Sender;
                for_update.Body = message.Body;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            messages = messages.Where(_ => _.Id != id).ToList();
        }
    }
}
