using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile.Models
{
    public enum RequestStatus
    {
        Pending,
        Accepted,
        Rejected,
        Completed
    }
    public class ExchangeRequest
    {
        public int Id { get; set; }
        public int RequestingUserId { get; set; }
        public int RequestedUserId { get; set; }
        public int BookOfferedId { get; set; }
        public int BookRequestedId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime DateRequested { get; set; }
    }
}
