using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concessionaria
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();
                    string query = "SELECT IDAuto,Modello FROM Concessionaria ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = reader["Modello"].ToString();
                        item.Value = reader["IDAuto"].ToString();

                        ddlExample.Items.Add(item);
                        string ID = ddlExample.SelectedValue;
                    }
                }
                catch (Exception ex) { Response.Write(ex.Message); }
                finally { conn.Close(); }
            }
        }


        protected void Compra_Click(object sender, EventArgs e)
        {
            garanzia.Attributes.Remove("class");
            string carSelected = ddlExample.SelectedValue;
            string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = $"SELECT * FROM Concessionaria WHERE IDAuto = '{carSelected}' ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    carImage.Src = reader["Immagine"].ToString();
                    NameModel.InnerText = "Modello: " + reader["Modello"].ToString();
                    Price.InnerText = "Prezzo di partenza: " + reader["PrezzoBase"].ToString();
                }

            }
            catch (Exception ex) { Response.Write(ex.Message); }
            finally { conn.Close(); }
        }

        protected void CalcolaPreventivo_Click(object sender, EventArgs e)
        {

            string carSelected = ddlExample.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = $"SELECT * FROM Concessionaria WHERE IDAuto = {carSelected}";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    double totale = 0;
                    double prezzoBase = Convert.ToDouble(reader["PrezzoBase"]);

                    if (CerchionInLega.Checked)
                    {
                        totale += reader["CerchiInLega"] != DBNull.Value ? Convert.ToDouble(reader["CerchiInLega"]) : 0;
                    }
                    if (climatizzatore.Checked)
                    {
                        totale += reader["Climatizzatore"] != DBNull.Value ? Convert.ToDouble(reader["Climatizzatore"]) : 0;
                    }
                    if (VerniceCromata.Checked)
                    {
                        totale += reader["VerniceCromata"] != DBNull.Value ? Convert.ToDouble(reader["VerniceCromata"]) : 0;
                    }
                    if (DoppioAirbag.Checked)
                    {
                        totale += reader["DoppioAirbag"] != DBNull.Value ? Convert.ToDouble(reader["DoppioAirbag"]) : 0;
                    }
                    if (ABS.Checked)
                    {
                        totale += reader["ABS"] != DBNull.Value ? Convert.ToDouble(reader["ABS"]) : 0;
                    }

                    int anniGaranzia = Convert.ToInt32(DropDownList2.SelectedValue);

                    if (anniGaranzia > 1 && anniGaranzia < 6)
                    {
                        totale += anniGaranzia * (reader["PrezzoGaranzia"] != DBNull.Value ? Convert.ToDouble(reader["PrezzoGaranzia"]) : 0);
                    }


                    PrezzoBase.InnerText = reader["PrezzoBase"].ToString() + " €";
                    CerchiInLega.InnerText = reader["CerchiInLega"].ToString() + " €";
                    VerniceCromatal.InnerText = reader["VerniceCromata"].ToString() + " €";
                    Climatizzatorel.InnerText = reader["Climatizzatore"].ToString() + " €";
                    DoppioAirbagl.InnerText = reader["DoppioAirbag"].ToString() + " €";
                    ABSl.InnerText = reader["ABS"].ToString() + " €";
                    PrezzoGaranzia.InnerText = reader["PrezzoGaranzia"].ToString() + " €";
                    PrezzoTotale.InnerText = totale + prezzoBase + " €";



                }

            }
            catch (Exception ex) { Response.Write(ex.Message); }
            finally { conn.Close(); }
        }
    }
}