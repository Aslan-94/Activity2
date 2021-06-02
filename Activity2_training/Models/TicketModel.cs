using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2_training.Models
{
    public class TicketModel
    {

        [DisplayName("Id number")]
        public int Id { get; set; }

        [DisplayName("Passenger's Name")]
        public string PassengerName { get; set; }


        [DisplayName("Country of Destination")]
        public string DestinationCountry { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Ticket Price")]
        public decimal TicketPrice { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Flight Date")]
        public DateTime FlightDate { get; set; }


    }
}
