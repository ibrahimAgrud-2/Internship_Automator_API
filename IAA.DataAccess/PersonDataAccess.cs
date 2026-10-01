
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Diagnostics;


namespace IAA.DataAccess
{
    public class PersonDataAccess
    {

        public class PersonEntity
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string phone { get; set; }
            public string Address { get; set; }
            public string ImagePath { get; set; }
            public PersonEntity(int id, string firstName, string lastName, string email,
                    string phone, string address, string imagePath)
            {
                ID = id;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                this.phone = phone;
                Address = address;
                ImagePath = imagePath;
            }

        }


        public static string _ConnectionString = "Data Source=IBRAHIM;Initial Catalog=IAA;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";


        public static List<PersonEntity> getAllPeople()
        {


            List<PersonEntity> People = new List<PersonEntity>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string sqlQuery = @"select PersonID, FirstName, LastName, Email, Phone, Address, ImagePath from People";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {


                    try
                    {
                        connection.Open();
                        using (SqlDataReader read = cmd.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                People.Add
                                    (new PersonEntity(
                                       read.GetInt32(read.GetOrdinal("PersonID")),
                                       read.GetString(read.GetOrdinal("FirstName")),
                                       read.GetString(read.GetOrdinal("LastName")),
                                       read.GetString(read.GetOrdinal("Email")),
                                       read.GetString(read.GetOrdinal("Phone")),
                                       read.GetString(read.GetOrdinal("Address")),
                                       read.GetString(read.GetOrdinal("ImagePath"))
                                    ));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error Occurred");
                    }
                }
            }
            return People;
        }

        public static PersonEntity Find(int PersonID)
        {
            using (var connection = new SqlConnection(_ConnectionString))
               
            using (var command = new SqlCommand("Select * from people where personID = @PersonID", connection))
            {

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    using (var read = command.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            return new PersonEntity
                            (
                              read.GetInt32(read.GetOrdinal("PersonID")),
                              read.GetString(read.GetOrdinal("FirstName")),
                              read.GetString(read.GetOrdinal("LastName")),
                              read.GetString(read.GetOrdinal("Email")),
                              read.GetString(read.GetOrdinal("Phone")),
                              read.GetString(read.GetOrdinal("Address")),
                              read.GetString(read.GetOrdinal("ImagePath"))

                            );
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("An error Occurred");
                    return null;
                }
            }
        }



    }
}
