using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;


namespace Negocio
{

    public partial class About : Page
    {

        
        [WebMethod]
        public static List<object> GetChartData()
        {    
        
            string query = "SELECT ShipCity, COUNT(orderid) TotalOrders";
            query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
        {
            "ShipCity", "TotalOrders" 
        });
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                    {
                        sdr["ShipCity"], sdr["TotalOrders"] 
                    });
                        }
                    }
                    con.Close();
                    return chartData;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtfecha.Text = "10/10/2015";
        }
    }
}