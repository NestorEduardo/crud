using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class PeopleDataAccessLayer
    {
        private readonly string connectionString =
            @"Integrated Security=True;Persist Security Info=False;Initial Catalog=CRUDTEST;Data Source=.\SQLEXPRESS";

        public IEnumerable<Person> GetPeople()
        {
            try
            {
                List<Person> people = new List<Person>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetPeoploe", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Person person = new Person();

                        person.ID = Convert.ToInt32(reader["ID"]);
                        person.Document = reader["Document"].ToString();
                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.CityID = Convert.ToInt32(reader["CityID"]);
                        person.City = reader["City"].ToString();
                        person.CountryID = Convert.ToInt32(reader["CountryID"]);
                        person.Country = reader["Country"].ToString();

                        people.Add(person);
                    }

                    connection.Close();
                }
                return people;
            }
            catch
            {
                throw;
            }
        }

        public int AddPerson(Person person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddPerson", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Document", person.Document);
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", person.LastName);
                    cmd.Parameters.AddWithValue("@CityID", person.CityID);
                    cmd.Parameters.AddWithValue("@CountryID", person.CountryID);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdatePerson(Person person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdatePerson", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", person.ID);
                    cmd.Parameters.AddWithValue("@Document", person.Document);
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", person.LastName);
                    cmd.Parameters.AddWithValue("@City", person.City);


                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Person GetPerson(int id)
        {
            try
            {
                Person person = new Person();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetPerson", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        person.Document = reader["Document"].ToString();
                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.CityID = Convert.ToInt32(reader["CityID"]);
                        person.CountryID = Convert.ToInt32(reader["CountryID"]);
                    }
                }

                return person;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        //To Delete the record on a particular employee
        public int DeletePerson(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeletePerson", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Country> GetCountries()
        {
            try
            {
                List<Country> countries = new List<Country>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCountries", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Country country = new Country();

                        country.ID = Convert.ToInt32(reader["ID"]);
                        country.Description = reader["Description"].ToString();

                        countries.Add(country);
                    }

                    connection.Close();
                }

                return countries;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<City> GetCities(int countryID)
        {
            try
            {
                List<City> cities = new List<City>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCities", connection);
                    cmd.Parameters.AddWithValue("@CountryID", countryID);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City city = new City();

                        city.ID = Convert.ToInt32(reader["ID"]);
                        city.Description = reader["Description"].ToString();

                        cities.Add(city);
                    }

                    connection.Close();
                }

                return cities;
            }
            catch
            {
                throw;
            }
        }
    }
}
