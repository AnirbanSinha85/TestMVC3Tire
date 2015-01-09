using PRLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC3Tire.Models;

namespace TestMVC3Tire.Controllers
{
    public class DBaccessController : Controller
    {
        //
        // GET: /DBaccess/

        public ActionResult Index()
        {
            return View();
        }

        private String ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MVCConnection"].ToString();
        }

        private SqlConnection SqlConnectionString()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConnectionString();
            return Con;
        }

        private Boolean ExecuteQuery(String SqlQuery)
        {
            SqlConnection connection = SqlConnectionString();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand(SqlQuery, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public string SaveContact(Contact objCon)
        {
            SqlConnection con = SqlConnectionString();

            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("ContactInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", 0); // i will pass zero to MobileID beacause its Primary .
                cmd.Parameters.AddWithValue("@FirstName", objCon.FirstName);
                cmd.Parameters.AddWithValue("@PhoneNo", objCon.PhoneNo);
                cmd.Parameters.AddWithValue("@AddressLine1", objCon.AddressLine1);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;

            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public List<Contact> GetContactList()
        {
            SqlConnection con = SqlConnectionString();
            List<Contact> LstContact = new List<Contact>();
            try
            {
                SqlCommand cmd = new SqlCommand("ContactInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", "GetContact");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contact obContact = new Contact();
                        obContact.ContactID = Convert.ToInt32(reader["ContactID"]);
                        obContact.FirstName = Convert.ToString(reader["FirstName"]);
                        obContact.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                        obContact.PhoneNo = Convert.ToString(reader["PhoneNo"]);
                        LstContact.Add(obContact);
                    }
                }
            }
            catch
            {
                return LstContact;
            }
            finally
            {
                con.Close();
            }
            return LstContact;
        }

        public Boolean UpdateContact(Contact objCon)
        {
            SqlConnection con = SqlConnectionString();

            Boolean result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("ContactInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", objCon.ContactID);
                cmd.Parameters.AddWithValue("@FirstName", objCon.FirstName);
                cmd.Parameters.AddWithValue("@PhoneNo", objCon.PhoneNo);
                cmd.Parameters.AddWithValue("@AddressLine1", objCon.AddressLine1);
                cmd.Parameters.AddWithValue("@Status", "UpdateContact");
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public List<Contact> GetContact(int id)
        {
            SqlConnection con = SqlConnectionString();
            List<Contact> LstContact = new List<Contact>();
            try
            {
                SqlCommand cmd = new SqlCommand("ContactInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", id);
                cmd.Parameters.AddWithValue("@Status", "GetContactById");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contact obContact = new Contact();
                        obContact.ContactID = Convert.ToInt32(reader["ContactID"]);
                        obContact.FirstName = Convert.ToString(reader["FirstName"]);
                        obContact.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                        obContact.PhoneNo = Convert.ToString(reader["PhoneNo"]);
                        LstContact.Add(obContact);
                    }
                }
            }
            catch
            {
                return LstContact;
            }
            finally
            {
                con.Close();
            }
            return LstContact;
        }

        #region Mandate

        public string SaveMandate(Mandate objMan)
        {
            SqlConnection con = SqlConnectionString();

            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("MandateInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MandateID", 0);
                cmd.Parameters.AddWithValue("@ContactID", objMan.ContactID);
                cmd.Parameters.AddWithValue("@SalutationID", objMan.SalutationID);
                cmd.Parameters.AddWithValue("@SalutationName", objMan.SalutationName);
                cmd.Parameters.AddWithValue("@MandateName", objMan.MandateName);
                cmd.Parameters.AddWithValue("@Status", objMan.Status);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;

            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public List<Mandate> GetMandateList()
        {
            SqlConnection con = SqlConnectionString();
            List<Mandate> LstMandate = new List<Mandate>();
            try
            {
                SqlCommand cmd = new SqlCommand("MandateInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", "GetMandate");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Mandate obMandate = new Mandate();
                        obMandate.MandateID = Convert.ToInt32(reader["MandateID"]);
                        obMandate.ContactID = Convert.ToInt32(reader["ContactID"]);
                        obMandate.MandateName = Convert.ToString(reader["MandateName"]);
                        obMandate.SalutationName = Convert.ToString(reader["SalutationName"]);
                        obMandate.ContactName = Convert.ToString(reader["FirstName"]);
                        LstMandate.Add(obMandate);
                    }
                }
            }
            catch
            {
                return LstMandate;
            }
            finally
            {
                con.Close();
            }
            return LstMandate;
        }

        public List<Mandate> GetMandate(int id)
        {
            SqlConnection con = SqlConnectionString();
            List<Mandate> LstMandate = new List<Mandate>();
            try
            {
                SqlCommand cmd = new SqlCommand("MandateInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MandateID", id);
                cmd.Parameters.AddWithValue("@Status", "GetMandateById");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Mandate obMandate = new Mandate();
                        obMandate.MandateID = Convert.ToInt32(reader["MandateID"]);
                        obMandate.ContactID = Convert.ToInt32(reader["ContactID"]);
                        obMandate.MandateName = Convert.ToString(reader["MandateName"]);
                        obMandate.SalutationName = Convert.ToString(reader["SalutationName"]);
                        obMandate.ContactName = Convert.ToString(reader["FirstName"]);
                        LstMandate.Add(obMandate);
                    }
                }
            }
            catch
            {
                return LstMandate;
            }
            finally
            {
                con.Close();
            }
            return LstMandate;
        }

        public Boolean UpdateMandate(Mandate objMan)
        {
            SqlConnection con = SqlConnectionString();

            Boolean result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("MandateInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", objMan.ContactID);
                cmd.Parameters.AddWithValue("@MandateID", objMan.MandateID);
                cmd.Parameters.AddWithValue("@SalutationID", objMan.SalutationID);
                cmd.Parameters.AddWithValue("@SalutationName", objMan.SalutationName);
                cmd.Parameters.AddWithValue("@MandateName", objMan.MandateName);
                cmd.Parameters.AddWithValue("@Status", "UpdateMandate");
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        #endregion


        #region CHECK LOG IN

        public LogIn CheckLogIn(LogIn objLogIn)
        {
            SqlConnection con = SqlConnectionString();
            LogIn obLogIn = new LogIn();
            try
            {
                SqlCommand cmd = new SqlCommand("CheckLogIn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objLogIn.UserName);
                cmd.Parameters.AddWithValue("@Password", objLogIn.Password);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        obLogIn.UserID = Convert.ToInt32(reader["UserID"]);
                        obLogIn.Password = Convert.ToString(reader["Password"]);
                        obLogIn.UserName = Convert.ToString(reader["UserName"]);
                    }
                }
            }
            catch
            {
                return obLogIn;
            }
            finally
            {
                con.Close();
            }
            return obLogIn;
        }

        #endregion


        public string SaveContact(PRContact objCon)
        {
            SqlConnection con = SqlConnectionString();

            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("ContactInsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", 0); // i will pass zero to MobileID beacause its Primary .
                cmd.Parameters.AddWithValue("@FirstName", objCon.FirstName);
                cmd.Parameters.AddWithValue("@PhoneNo", objCon.PhoneNo);
                cmd.Parameters.AddWithValue("@AddressLine1", objCon.AddressLine1);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;

            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
    }
}
