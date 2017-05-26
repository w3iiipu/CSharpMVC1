using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class PeopleBusinessLayer
    {
        public IEnumerable<People> Peoples
        {
            get
            {

                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                List<People> people = new List<People>();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllPeople", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        People person = new People();
                        person.ID = Convert.ToInt32(rdr["ID"]);
                        person.Name = rdr["Name"].ToString();
                        person.Email = rdr["Email"].ToString();
                        person.Phone = rdr["Phone"].ToString();
                        if (!(rdr["Birthday"] is DBNull))
                        {
                            person.Birthday = Convert.ToDateTime(rdr["Birthday"]);
                        }
                        //person object add to list
                        people.Add(person);
                    }

                }
                //return the list
                return people;
            }

        }

        public void addPeople(People people)
        {
            string cs =
           ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddPeople", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = people.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Email";
                paramGender.Value = people.Email;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@Phone";
                paramCity.Value = people.Phone;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@Birthday";
                paramDateOfBirth.Value = people.Birthday;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void savePeople(People people)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSavePeople", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = people.ID;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = people.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = people.Email;
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramPhone = new SqlParameter();
                paramPhone.ParameterName = "@Phone";
                paramPhone.Value = people.Phone;
                cmd.Parameters.Add(paramPhone);

                SqlParameter paramBirthday = new SqlParameter();
                paramBirthday.ParameterName = "@Birthday";
                paramBirthday.Value = people.Birthday;
                cmd.Parameters.Add(paramBirthday);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void deletePeople (int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePeople", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
