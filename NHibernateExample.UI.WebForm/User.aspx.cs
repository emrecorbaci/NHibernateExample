using NHibernateExample.Models;
using NHibernateExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHibernateExample.UI.WebForm
{
    public partial class _User : Page
    {
        UserService userService = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersFilledToGrid();   
            }
        }

        public void UsersFilledToGrid()
        {
            grdUsers.DataSource = userService.GetAll();
            grdUsers.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User
                {
                    Id = !string.IsNullOrWhiteSpace(txbId.Text) ? int.Parse(txbId.Text) : 0,
                    FirstName = txbFirstName.Text,
                    LastName = txbLastName.Text,
                    Age = !string.IsNullOrWhiteSpace(txbAge.Text) ? int.Parse(txbAge.Text) : 0,
                    RegisterDate =DateTime.Now
                };
                Save(user);
                Clear();
                UsersFilledToGrid();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Save Error", "alert('" + ex.Message + "');", true);
            }
           
        }

        protected void grdUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var rw = grdUsers.Rows[e.NewEditIndex];           
            txbId.Text = rw.Cells[1].Text;
            txbFirstName.Text = rw.Cells[2].Text;
            txbLastName.Text = rw.Cells[3].Text;
            txbAge.Text = rw.Cells[4].Text;

            e.Cancel = true;
        }
        public void Save(User user)
        {
            if (user.Id != 0)
            {
                userService.Update(user); 
            }
            else
            {
                userService.Add(user);
            }
        }

        public void Clear()
        {
            txbId.Text = string.Empty;
            txbFirstName.Text = string.Empty;
            txbLastName.Text = string.Empty;
            txbAge.Text = string.Empty;
        }

        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var deletedRow = grdUsers.Rows[e.RowIndex];
            var id = int.Parse(deletedRow.Cells[1].Text);
            User user = new User{ Id = id ,FirstName = "", LastName = ""};
            userService.Delete(user);
            UsersFilledToGrid();

            e.Cancel = true;
        }
    }
}