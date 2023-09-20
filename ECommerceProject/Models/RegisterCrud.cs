using System.Data.SqlClient;

namespace ECommerceProject.Models
{
    public class RegisterCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public RegisterCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Register> GetAllUser()
        {
            List<Register> list = new List<Register>();
            string qry = "select * from Registration";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Register register = new Register();
                    register.Uid = Convert.ToInt32(dr["uid"]);
                    register.FirstName = dr["firstName"].ToString();
                    register.LastName = dr["lastName"].ToString();
                    register.Email = dr["email"].ToString();
                    register.City = dr["city"].ToString();
                    register.State = dr["state"].ToString();



                    list.Add(register);
                }
            }
            con.Close();
            return list;
        }
        public int AddUser(Register user)
        {
            int result = 0;
            string str = "insert into Registration(firstName,lastName,userName,password,confirmpwd,email,city,state)values(@firstName,@lastName,@userName,@password,@confirmpwd,@email,@city,@state)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@firstName", user.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.LastName);
            cmd.Parameters.AddWithValue("@userName", user.UserName);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@confirmpwd", user.Confirmpwd);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@city", user.City);
            cmd.Parameters.AddWithValue("@state", user.State);



            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public Register Login(string username, string password)
        {
            Register u = new Register();
            string qry = "select * from Registration where username=@userName and password=@password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    u.Uid= Convert.ToInt32(dr["uid"]);
                    u.FirstName = dr["firstName"].ToString();
                    u.LastName = dr["lastName"].ToString();
                    u.UserName = dr["userName"].ToString();
                    //u.Password = dr["password"].ToString();
                    //u.Confirmpwd = dr["confirmpwd"].ToString();
                    u.RoleId = Convert.ToInt32(dr["RoleId"]);

                }
            }
            con.Close();
            return u;
        }
    }
}
