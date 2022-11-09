using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;

namespace PresentationLayer
{


    public partial class Page1 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());


        BusinessLogicLayer.Employee objempbll = new BusinessLogicLayer.Employee();
        BusinessLogicLayer.Gender objgenbll = new BusinessLogicLayer.Gender();
        BusinessLogicLayer.Country objconbll = new BusinessLogicLayer.Country();
        BusinessLogicLayer.Hobby objhobbll = new BusinessLogicLayer.Hobby();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                FillData();
                FillCreateFromFields();
            }
        }
        protected void emptyform()
        {
            string content = "window.onload=function(){";
            content += "window.location='";
            content += Request.Url.AbsoluteUri;
            content += "';}";
            ClientScript.RegisterStartupScript(this.GetType(), "SucessMassage", content, true);
        }
        private void FillData()
        {
            DataSet ds = objempbll.GetEmp();

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        public void FillCreateFromFields()
        {
            DataSet ds = objgenbll.GetGender();

            rblGender.DataSource = ds;
            rblGender.DataTextField = "GenderName";
            rblGender.DataValueField = "GenderId";
            rblGender.DataBind();

            ds = objconbll.GetCountry();
            ddlCountry.DataSource = ds;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryId";
            ddlCountry.DataBind();

            ds = objhobbll.GetHobby();
            cblHobby.DataSource = ds;
            cblHobby.DataTextField = "HobbyName";
            cblHobby.DataValueField = "HobbyId";
            cblHobby.DataBind();

        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    BusinessObjects.Employee objempbo = new BusinessObjects.Employee();
        //    objempbo.EmployeeName = txtEmployeeName.Text;
        //    objempbo.MobileNumber = txtMobileNumber.Text;
        //    objempbo.Email = txtEmail.Text;
        //    objempbo.DateOfJoin = DateTime.Parse(TextBox9.Text);
        //    objempbo.GenderId = int.Parse(rblGender.Text);
        //    objempbo.CountryId = int.Parse(ddlCountry.Text);
        //    objempbo.HobbyId = int.Parse(cblHobby.Text);
        //    objempbo.DateCreated = DateTime.Now;
        //    objempbo.DatePublished = DateTime.Now;
        //    int i = objempbll.SaveEmp(objempbo);
        //    if (i == 1)
        //    {
        //        emptyform();
        //        FillData();
        //        FillCreateFromFields();

        //    }
        //    else
        //    {
        //        Response.Write("Failed");
        //    }
        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            BusinessObjects.Employee objboemp = new BusinessObjects.Employee();
            objboemp.EmployeeName = txtEmployeeName.Text;
            objboemp.MobileNumber = txtMobileNumber.Text;
            objboemp.Email = txtEmail.Text;
            objboemp.DateOfJoin = DateTime.Parse(TextBox9.Text);
            objboemp.GenderId = int.Parse(rblGender.Text);
            objboemp.CountryId = int.Parse(ddlCountry.Text);
            objboemp.HobbyId=int.Parse(cblHobby.Text);           
            if (btnSave.Text == "Save")
            {
                int i = objempbll.SaveEmp(objboemp);
                if (i == 1)
                {
                    //DataSet ds = objempbll.GetEmp();
                    emptyform();
                    FillData();
                    FillCreateFromFields();
                }
            }
            else if (btnSave.Text == "Update")
            {
                objboemp.EmployeeId = int.Parse(txtEmployeeId.Text);

                int i = objempbll.UpdateEmp(objboemp);
                if (i == 1)
                {
                    emptyform();
                    DataSet ds = objempbll.GetEmp();
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    btnSave.Text = "Save";
                }
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

            //  hide a cell in the column to hide column 1
            e.Row.Cells[1].Visible = false;
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BusinessObjects.Employee objempbo = new BusinessObjects.Employee();
            GridViewRow row = GridView1.Rows[e.RowIndex];
            Label l1 = (Label)row.FindControl("Label1");
            objempbo.EmployeeId = int.Parse(l1.Text);
            int i = objempbll.DeleteEmp(objempbo);
            if (i == 1)
            {
                FillData();
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillData();
            FillCreateFromFields();
            GridView gridView = (GridView)sender;
                            //gridView.Rows[0].RowIndex;
            int rowind = ((GridViewRow)(gridView.Rows[0])).RowIndex;

            //int rowind = ((GridViewRow)(sender as Control)).RowIndex;

            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            TextBox t1 = (TextBox)row.FindControl("TextBox1");
            TextBox t2 = (TextBox)row.FindControl("TextBox2");
            TextBox t3 = (TextBox)row.FindControl("TextBox3");
            TextBox t4 = (TextBox)row.FindControl("TextBox4");
            TextBox t5 = (TextBox)row.FindControl("TextBox5");

            RadioButtonList t6 = (RadioButtonList)rblGender.FindControl("rblGender");
            //DropDownList t7 = (DropDownList)ddlCountry.FindControl("ddlCountry");
            //CheckBoxList t8 = (CheckBoxList)cblHobby.FindControl("cblHobby");
            //RadioButtonList t6 = (RadioButtonList)row.FindControl("rblGender");
            //DropDownList t7 = (DropDownList)row.FindControl("ddlCountry");
            //CheckBoxList t8 = (CheckBoxList)row.FindControl("cblHobby");
            
            lblEmployeeId.Visible = true;
            txtEmployeeId.Visible = true;
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Text = t1.Text;
            txtEmployeeName.Text = t2.Text;
            txtMobileNumber.Text = t3.Text;
            txtEmail.Text = t4.Text;
            TextBox9.Text = t5.Text;
            string s = ((System.Web.UI.WebControls.TextBox)GridView1.Rows[e.NewEditIndex].FindControl("TextBox6")).Text;

            
            //DataSet ds = objgenbll.GetGender();

            //DataTable dt = ds.Tables[0];

            //foreach(DataRow dr in dt.Rows)
            //{
            //   if(s == dr.)

            //}



            //rblGender.DataSource = ds;
            //rblGender.DataTextField = "GenderName";
            //rblGender.DataValueField = "GenderId";
            //rblGender.SelectedValue = s;
            //rblGender.DataBind();

            //rblGender.SelectedValue = t6.SelectedValue;
            //ddlCountry.SelectedValue = t7.SelectedValue;
            //cblHobby.SelectedValue = t8.SelectedValue;
            btnSave.Text = "Update";
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillData();
        }
        protected void rblGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
            TimeSpan ts = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            dt = dt.Add(ts);
            TextBox9.Text = dt.ToString();
            Calendar1.Visible = false;
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)

        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox t1 = (TextBox)row.FindControl("TextBox1");
            TextBox t2 = (TextBox)row.FindControl("TextBox2");
            TextBox t3 = (TextBox)row.FindControl("TextBox3");
            TextBox t4 = (TextBox)row.FindControl("TextBox4");
            TextBox t5 = (TextBox)row.FindControl("TextBox5");
            TextBox t6 = (TextBox)row.FindControl("TextBox6");
            TextBox t7 = (TextBox)row.FindControl("TextBox7");
            TextBox t8 = (TextBox)row.FindControl("TextBox8");
            lblEmployeeId.Visible = true;
            txtEmployeeId.Visible = true;
            txtEmployeeId.Text = t1.Text;
            txtEmployeeName.Text = t2.Text;
            txtMobileNumber.Text = t3.Text;
            txtEmail.Text = t4.Text;
            TextBox9.Text = t5.Text;
            rblGender.SelectedValue = t6.Text;
            ddlCountry.SelectedValue = t7.Text;
            cblHobby.SelectedValue = t8.Text;
            btnSave.Text = "Update";



            //BusinessObjects.Employee objempbo = new BusinessObjects.Employee();
            //objempbo.EmployeeId = int.Parse(t1.Text);
            //objempbo.EmployeeName = t2.Text;
            //objempbo.MobileNumber = t3.Text;
            //objempbo.Email = t4.Text;
            //objempbo.DateOfJoin = DateTime.Parse(t5.Text);
            //objempbo.GenderId = int.Parse(t6.Text);
            //objempbo.CountryId = int.Parse(t7.Text);
            //objempbo.HobbyId = int.Parse(t8.Text);
            //int i = objempbll.UpdateEmp(objempbo);
            //if (i == 1)
            //{
            //    emptyform();
            //    GridView1.EditIndex = -1;
            //    //FillData();


            //}

            //}
            //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            //{
            //    //GridView1.EditIndex = -1;
            //    //FillData();
            //}
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            DataRowView dRowView = (DataRowView)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // editing:
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {


                    FillCreateFromFields();
                    // find the controls.
                    
                    RadioButtonList rblGender = (RadioButtonList)e.Row.FindControl("rblGender");
                    DropDownList ddlCountry = (DropDownList)e.Row.FindControl("ddlCountry");
                    CheckBoxList cblHobby = (CheckBoxList)e.Row.FindControl("cblHobby");
                    // set the values.
                    rblGender.SelectedValue = dRowView[5].ToString();
                    //ddlCountry.SelectedValue = dRowView[3].ToString();
                    //cblHobby.SelectedValue = dRowView[4].ToString();
                }
            }
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int index =
        //}
    }
}