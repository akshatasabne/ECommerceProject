using System.Data.SqlClient;

namespace ECommerceProject.Models
{
    public class CartCrud
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CartCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }




             public int AddTOCart(Cart cart)
             {
                int result = 0;

                string qry = "insert into Cart values (@id,@uid,@quantity)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", cart.Id);
                cmd.Parameters.AddWithValue("@uid", cart.Uid);
                cmd.Parameters.AddWithValue("@quantity", cart.Quantity);

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;

             }
            public List<Product> ViewCart(int uid)
            {
                List<Product> products = new List<Product>();
                string qry = "select p.*, c.quantity,c.caid from Product p join Cart c on c.id=p.id where c.uid=@uid";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@uid", uid);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(dr["id"]);
                        p.Name = dr["name"].ToString();
                        p.Price = Convert.ToDouble(dr["price"]);
                        p.Imageurl = dr["imageUrl"].ToString();
                        p.Id = Convert.ToInt32(dr["id"]);
                        p.Quantity = Convert.ToInt32(dr["quantity"]);
                        p.CartId = Convert.ToInt32(dr["caid"]);
                        products.Add(p);
                    }
                }
                return products;
            }
            public int DeleteCart(int CartId)
            {
                int result = 0;

                string qry = " delete from Cart where caid=@caid";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@caid", CartId);

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;

            }

        
    }
}
    
