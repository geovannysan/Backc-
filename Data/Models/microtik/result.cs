using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models.microtik
{
    public class result
    {
        public string? status { get; set; }
        public string? onu_signal { get; set; }
        public string? onu_signal_value { get; set; }
        public string? onu_signal_1310 { get; set; }
        public string? onu_signal_1490 { get; set; }
        public string? onu_status { get; set; }
        public string? error {get;set;}
        public List<Response>? response {get;set;}
    }
    public class Response {
          public string?board{ get; set; } 
            public string?pon_port{ get; set; } 
            public string?pon_type{ get; set; } 
            public string?admin_status{ get; set; }
            public string?operational_status{ get; set; }
            public string?description{ get; set; } 
            public string?min_range{ get; set; }
            public string?max_range{ get; set; } 
            public string?tx_power{ get; set; } 
            public string?onus_count{ get; set; }
            public string?online_onus_count{ get; set; }
            public string?average_signal{ get; set; }
    }
}
