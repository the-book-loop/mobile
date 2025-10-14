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
        public Guid Id { get; set; }
        public Guid RequestingUserId { get; set; }
        public Guid RequestedUserId { get; set; }
        public Guid BookOfferedId { get; set; }
        public Guid BookRequestedId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime DateRequested { get; set; }
    }
}
