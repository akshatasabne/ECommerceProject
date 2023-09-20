using System.Data.SqlClient;

namespace ECommerceProject.Models
{
    public class LogInCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        //DataTable dt;
        IConfiguration configuration;

        public LogInCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public Register GetLogin(string username, string password)
        {

            Register reg = new Register();
            string qry = "select * from register where username=@username and password=@password";
            cmd = new SqlCommand(qry, con);
            //cmd.Parameters.AddWithValue("@userid",reg.UserId);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            //cmd.Parameters.AddWithValue("@status_id", reg.status_id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    reg.Uid = Convert.ToInt32(dr["uid"]);
                    reg.UserName = dr["username"].ToString();
                    reg.FirstName = dr["first_name"].ToString();
                    reg.LastName = dr["last_name"].ToString();

                    
                }
            }
            con.Close();
            return reg;
        }
    }
}
