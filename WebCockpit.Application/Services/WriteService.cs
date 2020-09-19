using System;
using WebCockpit.Application.Enums;
using WebCockpit.Application.Interfaces;

namespace WebCockpit.Application.Services
{
    public class WriteService : IWriteService
    {
        private readonly ISimConnectContext _context;

        public WriteService(ISimConnectContext context)
        {
            _context = context;
        }

        private SimEvents ParseSimEvent(string eventName)
        {
            return (SimEvents)Enum.Parse(typeof(SimEvents), eventName);
        }

        public void Write(string eventName, uint data)
        {
            var simEvent = ParseSimEvent(eventName);

            _context.WriteEvent(simEvent, data);
        }
    }
}
