using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocumentDBProject
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnAddUser_Click(object sender, EventArgs e)
        {
            UserTest NewUser = new UserTest()
            {
                Age = txtAge.Text,
                Name = txtName.Text,
                Sex = txtSex.Text,
                UserID = txtUserID.Text,
            };

            if (TransactionsDocumentDB<UserTest>.GetDocument(txtUserID.Text) == null)
            {
                await TransactionsDocumentDB<UserTest>.CreateItemAsync(NewUser);

                lblMessage.Text = "User created in DocumentDB";
                ClearControls();
            }
            else
            {
                lblMessage.Text = "ID existing try another!";
                ClearControls();
            }
          
        }

        private void ClearControls()
        {
            txtAge.Text = "";
            txtName.Text = "";
            txtSex.Text = "";
            txtUserID.Text = "";
        }

        protected async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (TransactionsDocumentDB<UserTest>.GetDocument(txtUserID.Text) != null)
            {
                UserTest UserExisting = new UserTest()
                {
                    Age = txtAge.Text,
                    Name = txtName.Text,
                    Sex = txtSex.Text,
                    UserID = txtUserID.Text,
                };

                await TransactionsDocumentDB<UserTest>.UpdateItemsAsync(txtUserID.Text, UserExisting);

                lblMessage.Text = "User updated in DocumentDB";
                ClearControls();
            }
            else
            {
                lblMessage.Text = "User inexisting!";
            }              
        }

        protected async void btnDelete_Click(object sender, EventArgs e)
        {
            if (TransactionsDocumentDB<UserTest>.GetDocument(txtUserID.Text) != null)
            {
                await TransactionsDocumentDB<UserTest>.DeleteItemsAsync(txtUserID.Text);

                lblMessage.Text = "User deleted in DocumentDB";
                ClearControls();
            }
            else
            {
                lblMessage.Text = "User inexisting!";
            }
                
        }

        protected void btnGetUser_Click(object sender, EventArgs e)
        {
            Document DocumentExisting = TransactionsDocumentDB<UserTest>.GetDocument(txtUserID.Text);

            if (DocumentExisting != null)
            {
                txtAge.Text = DocumentExisting.GetPropertyValue<int>("Age").ToString();
                txtUserID.Text = DocumentExisting.GetPropertyValue<string>("UserID");
                txtSex.Text = DocumentExisting.GetPropertyValue<string>("Sex");
                txtName.Text = DocumentExisting.GetPropertyValue<string>("Name");
                txtUserID.Text = DocumentExisting.GetPropertyValue<string>("id");
            }
            else
            {
                lblMessage.Text = "User inexisting!";
            }
        }

        protected void btnGetAllUsers_Click(object sender, EventArgs e)
        {
            var Users = 
            TransactionsDocumentDB<UserTest>.GetAllItems();//.Where(us => us.Sex == "m");

            gridUsers.DataSource = Users;
            gridUsers.DataBind();

            lblMessage.Text = "Users loaded from DocumentDB";
        }        
    }
}