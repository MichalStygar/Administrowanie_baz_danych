using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uwierzytelnianie
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CzyDobryLoginHaslo(txtLogin.Text, txtHaslo.Text))
            {
                lKomunikat.Text = "Witaj!";
            }
            else
            {
                lKomunikat.Text = "Spadaj!";
            }

        }

        private bool CzyDobryLoginHaslo(string sLogin, string sHaslo)
        {
            bool bOk = false;

            try
            {
                SqlConnection cnUsers = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlParameter parLogin = new SqlParameter("@log", sLogin);
                SqlParameter parHaslo = new SqlParameter("@pass", sHaslo);


                SqlCommand cmd = new SqlCommand("SprawdzHaslo", cnUsers);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(parLogin);
                cmd.Parameters.Add(parHaslo);

                cmd.Parameters.Add("@ile", SqlDbType.Int);

                cmd.Parameters["@ile"].Direction = ParameterDirection.Output;

                cnUsers.Open();
                cmd.ExecuteNonQuery();
                cnUsers.Close();

                bOk = (int.Parse(cmd.Parameters["@ile"].Value.ToString()) > 0);

                return bOk;
            }
            catch
            {
                return false;
            }

        }
    }
}