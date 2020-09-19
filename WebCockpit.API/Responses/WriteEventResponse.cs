namespace WebCockpit.API.Responses
{
    public class WriteEventResponse
    {
        public string SimEvent { get; set; }
        public uint Data { get; set; }

        public WriteEventResponse(string simEvent, uint data)
        {
            SimEvent = simEvent;
            Data = data;
        }
    }
}
