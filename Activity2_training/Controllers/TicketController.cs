using Activity2_training.Models;
using Activity2_training.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2_training.Controllers
{
    public class TicketController : Controller
    {

        public IActionResult Index()
        {

            TicketsDAO tickets = new TicketsDAO();

            return View(tickets.GetAllTickets());
        }


        public IActionResult searchResult(string searchTerm, string searchTerm2)
        {
            TicketsDAO tickets = new TicketsDAO();
            List<TicketModel> ticketList = tickets.SearchTickets(searchTerm, searchTerm2);
            return View("Index", ticketList);
        }


        public IActionResult SearchForm()
        {
            return View();
        }



        public IActionResult ShowDetails(int id)
        {
            TicketsDAO tickets = new TicketsDAO();
            TicketModel foundTicket = tickets.GetTicketById(id);

            return View(foundTicket);
        }


        public IActionResult Edit(int id)
        {
            TicketsDAO tickets = new TicketsDAO();
            TicketModel foundTicket = tickets.GetTicketById(id);

            return View("ShowEdit", foundTicket);
        }


        public IActionResult ProcessEdit(TicketModel ticket)
        {
            TicketsDAO tickets = new TicketsDAO();
            tickets.Update(ticket);
            return View("Index", tickets.GetAllTickets());
        }


        public IActionResult Delete(TicketModel ticket)
        {
            TicketsDAO tickets = new TicketsDAO();
            tickets.Delete(ticket);

            return View("Index", tickets.GetAllTickets());
        }

        public IActionResult Create(TicketModel ticket)
        {
            TicketsDAO tickets = new TicketsDAO();
            tickets.Insert(ticket);
            return View("Index", tickets.GetAllTickets());
        }


        public IActionResult CreateForm()
        {
            return View();
        }
    }
}
