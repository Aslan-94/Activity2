using Activity2_training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2_training.Services
{
    interface ITicketDataServices
    {
        List<TicketModel> GetAllTickets();

        List<TicketModel> SearchTickets(string searchTerm, string searchTerm2);

        TicketModel GetTicketById(int id);

        int Insert(TicketModel ticket);
        int Delete(TicketModel ticket);
        int Update(TicketModel ticket);

    }
}
