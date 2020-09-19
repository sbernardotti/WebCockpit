using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Runtime.InteropServices;
using WebCockpit.Application.Enums;
using WebCockpit.Application.Interfaces;

namespace WebCockpit.Infrastructure
{
    public class SimConnectContext : ISimConnectContext, IDisposable
    {
        private SimConnect _simConnect;

        public SimConnectContext(IntPtr hwnd)
        {
            try
            {
                _simConnect = new SimConnect("WebCockpit", hwnd, 0x402, null, 0);
                MapClientEvents();
            }
            catch (COMException ex)
            {
                throw ex;
            }
        }

        private string ParseEventString(SimEvents simEvent)
        {
            return simEvent.ToString().Replace("KEY_", "");
        }

        private void MapClientEvents()
        {
            foreach (SimEvents simEvent in Enum.GetValues(typeof(SimEvents)))
            {
                var simEventString = ParseEventString(simEvent);
                _simConnect.MapClientEventToSimEvent(simEvent, simEventString);
            }
        }

        public void WriteEvent(SimEvents simEvent, uint data)
        {
            _simConnect.TransmitClientEvent(0U, simEvent, data, (Enum)NotificationGroups.GROUP0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        public void Dispose()
        {
            if (_simConnect != null)
            {
                _simConnect.Dispose();
                _simConnect = null;
            }
        }
    }
}
