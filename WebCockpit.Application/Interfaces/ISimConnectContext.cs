using System;
using WebCockpit.Application.Enums;

namespace WebCockpit.Application.Interfaces
{
    public interface ISimConnectContext : IDisposable
    {
        void WriteEvent(SimEvents simEvent, uint data);
    }
}
