using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\ASP\\Unit 3\\detail view\\App_Data\\Database.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fdisplay();
        }
    }
    public void fdisplay()
    {
        /*   cmd = new SqlCommand("select * from student", con);
           con.Open();
           dr=cmd.ExecuteReader();
           DetailsView1.DataSource = dr;
           DetailsView1.DataBind();
           con.Close(); */

        DetailsView1.DataSource = SqlDataSource1;
        SqlDataSource1.DataBind();
        DetailsView1.DataBind();
        
    }
   
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        DetailsView1.ChangeMode(e.NewMode);
        fdisplay();
    }
    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        TextBox id = DetailsView1.FindControl("TextBox4") as TextBox;
        TextBox name = DetailsView1.FindControl("TextBox5") as TextBox;
        TextBox city = DetailsView1.FindControl("TextBox6") as TextBox;
        TextBox pin = DetailsView1.FindControl("TextBox7") as TextBox;

        cmd = new SqlCommand("insert into student values(" + id.Text + ",'" + name.Text + "','" + city.Text + "'," + pin.Text + ")", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        fdisplay();
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        Label id = DetailsView1.FindControl("Label5") as Label;
        TextBox name = DetailsView1.FindControl("TextBox1") as TextBox;
        TextBox city = DetailsView1.FindControl("TextBox2") as TextBox;
        TextBox pin = DetailsView1.FindControl("TextBox3") as TextBox;

        cmd = new SqlCommand("update student set name='" + name.Text + "',city='" + city.Text + "',pin=" + pin.Text + " where id=" + id.Text + "", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        fdisplay();
    }
    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        Label id = DetailsView1.FindControl("Label1") as Label;
        cmd = new SqlCommand("delete from student where id=" + id.Text + "", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        fdisplay();
    }
    protected void DetailsView1_PageIndexChanging1(object sender, DetailsViewPageEventArgs e)
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        fdisplay();
    }
}
