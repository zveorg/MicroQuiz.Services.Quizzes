using System;

namespace MicroQuiz.Services.Quizzes.Api.Consul
{
    public class ConsulConfig
    {
        public Uri DiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public string PingEndpoint { get; set; }
        public int PingIntervalSec { get; set; }
        public int RemoveAfterIntervalSec { get; set; }
    }
}
