using Contact_Manager.Models;
using System.Data.SqlClient;
using System.Data;

namespace Contact_Manager.Data
{
    public class ContactsData
    {
        // Get the Data from the data base
        public List<ContactsModel> GetAllContacs()
        {

            var oGetContacts = new List<ContactsModel>();

            var conexionInstance = new SQLConexion();

            using (var conexion = new SqlConnection(conexionInstance.getConexionSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("GET_ALL_CONTACTS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oGetContacts.Add(new ContactsModel()
                        {
                            ContactID = Convert.ToInt32(dr["CONTACTID"]),
                            ContactName = dr["CONTACT_NAME"].ToString(),
                            Telephone = dr["TELEPHONE"].ToString(),
                            Email = dr["EMAIL"].ToString(),
                            DateAdded = dr["DATEADDED"].ToString()
                        });
                    }

                }
            }
            return oGetContacts;
        }

        // Get the data from the data base but passing an ID
        public ContactsModel GetContacByID(int ContactID)
        {

            var oGetContactsByID = new ContactsModel();

            var conexionInstance = new SQLConexion();

            using (var conexion = new SqlConnection(conexionInstance.getConexionSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("FIND_CONTACT_ID", conexion);
                cmd.Parameters.AddWithValue("CONTACTID", ContactID);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oGetContactsByID.ContactID = Convert.ToInt32(dr["CONTACTID"]);
                        oGetContactsByID.ContactName = (dr["CONTACT_NAME"]).ToString();
                        oGetContactsByID.Telephone = (dr["TELEPHONE"]).ToString();
                        oGetContactsByID.Email = (dr["EMAIL"]).ToString();
                        oGetContactsByID.DateAdded = (dr["DATEADDED"]).ToString();
                    }

                }
            }
            return oGetContactsByID;
        }

        // Save a contact in the data base
        
        public bool SaveContact(ContactsModel oContact)
        {

            bool rpta; 

            try
            {
                var conexionInstance = new SQLConexion();

                using (var conexion = new SqlConnection(conexionInstance.getConexionSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SAVE_CONTACT", conexion);
                    cmd.Parameters.AddWithValue("CONTACT_NAME", oContact.ContactName);
                    cmd.Parameters.AddWithValue("TELEPHONE", oContact.Telephone);
                    cmd.Parameters.AddWithValue("EMAIL", oContact.Email);
                    cmd.Parameters.AddWithValue("DATEADDED", oContact.DateAdded);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        // Edit a contact in the data base
        public bool EditContact(ContactsModel oContact)
        {

            bool rpta;

            try
            {
                var conexionInstance = new SQLConexion();

                using (var conexion = new SqlConnection(conexionInstance.getConexionSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EDIT_CONTACT", conexion);
                    cmd.Parameters.AddWithValue("CONTACTID", oContact.ContactID);
                    cmd.Parameters.AddWithValue("CONTACT_NAME", oContact.ContactName);
                    cmd.Parameters.AddWithValue("TELEPHONE", oContact.Telephone);
                    cmd.Parameters.AddWithValue("EMAIL", oContact.Email);
                    cmd.Parameters.AddWithValue("DATEADDED", oContact.DateAdded);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        // Delete a contact from the data base passing an ID
        public bool DeleteContact(int ContactID)
        {

            bool rpta;

            try
            {
                var conexionInstance = new SQLConexion();

                using (var conexion = new SqlConnection(conexionInstance.getConexionSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("DELETE_CONTACT", conexion);
                    cmd.Parameters.AddWithValue("CONTACTID", ContactID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
