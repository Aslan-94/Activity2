using Activity2_training.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2_training.Services
{
    

    public class TicketsDAO : ITicketDataServices
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(TicketModel ticket)
        {

            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.Tickets WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", ticket.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return newIdNumber;

        }



        public List<TicketModel> GetAllTickets()
        {

            List<TicketModel> foundTickets = new List<TicketModel>();

            string sqlStatement = "SELECT * FROM dbo.Tickets";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundTickets.Add(new TicketModel { Id = (int)reader[0], PassengerName = (string)reader[1], DestinationCountry = (string)reader[2], TicketPrice = (decimal)reader[3], FlightDate = (DateTime)reader[4] });
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            return foundTickets;
        }




        public TicketModel GetTicketById(int id)
        {
            TicketModel foundTicket = null;

            string sqlStatement = "SELECT * from dbo.Tickets WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundTicket = new TicketModel { Id = (int)reader[0], PassengerName = (string)reader[1], DestinationCountry = (string)reader[2], TicketPrice = (decimal)reader[3], FlightDate = (DateTime)reader[4], };
                    }

                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return foundTicket;
        }




        public int Insert(TicketModel ticket)
        {
            int newIdNumber = -1;

            string sqlStatement = "INSERT INTO dbo.Tickets VALUES(@PassengerName, @DestinationCountry, @TicketPrice, @FlightDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@PassengerName", ticket.PassengerName);
                command.Parameters.AddWithValue("@DestinationCountry", ticket.DestinationCountry);
                command.Parameters.AddWithValue("@TicketPrice", ticket.TicketPrice);
                command.Parameters.AddWithValue("@FlightDate", ticket.FlightDate);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return newIdNumber;

        }




        public List<TicketModel> SearchTickets(string searchTerm, string searchTerm2)
        {

            List<TicketModel> foundTickets = new List<TicketModel>();

            string sqlStatement = "SELECT * FROM dbo.Tickets WHERE PassengerName LIKE @PassengerName AND DestinationCountry LIKE @DestinationCountry";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@PassengerName", '%' + searchTerm + '%');
                command.Parameters.AddWithValue("@DestinationCountry", '%' + searchTerm2 + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundTickets.Add(new TicketModel { Id = (int)reader[0], PassengerName = (string)reader[1], DestinationCountry = (string)reader[2], TicketPrice = (decimal)reader[3], FlightDate = (DateTime)reader[4] });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            return foundTickets;
        }




        public int Update(TicketModel ticket)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE dbo.Tickets SET PassengerName = @PassengerName, DestinationCountry = @DestinationCountry, TicketPrice = @TicketPrice, FlightDate = @FlightDate WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@PassengerName", ticket.PassengerName);
                command.Parameters.AddWithValue("@DestinationCountry", ticket.DestinationCountry);
                command.Parameters.AddWithValue("@TicketPrice", ticket.TicketPrice);
                command.Parameters.AddWithValue("@FlightDate", ticket.FlightDate);
                command.Parameters.AddWithValue("@Id", ticket.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());

                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return newIdNumber;
        }
    }
}
