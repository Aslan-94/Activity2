using Activity2_training.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2_training.Services
{
    public class HardCodedDataSampleRepository : ITicketDataServices
    {

        static List<TicketModel> ticketList = new List<TicketModel>();


        public int Delete(TicketModel ticket)
        {
            throw new NotImplementedException();
        }

        public List<TicketModel> GetAllTickets()
        {
            if(ticketList.Count == 0)
            {
                for (int i = 0; i < 100; i++) 
                {
                    ticketList.Add(new Faker<TicketModel>()
                        .RuleFor(t => t.Id, i)
                        .RuleFor(t => t.PassengerName, f => f.Person.FullName)
                        .RuleFor(t => t.DestinationCountry, f => f.Address.Country())
                        .RuleFor(t => t.TicketPrice, f => f.Random.Decimal(500))
                        .RuleFor(t => t.FlightDate, f => f.Date.Future(100)));

          
                }
            }

            return ticketList;

        }

        public TicketModel GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(TicketModel ticket)
        {
            throw new NotImplementedException();
        }

        public List<TicketModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public List<TicketModel> SearchTickets(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public List<TicketModel> SearchTickets(string searchTerm, string searchTerm2)
        {
            throw new NotImplementedException();
        }

        public int Update(TicketModel ticket)
        {
            throw new NotImplementedException();
        }
    }
}
