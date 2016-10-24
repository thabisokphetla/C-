using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUEST_HOUSE
{

    
    public partial class registration_log : Form
    {        
        public registration_log()
        {
            InitializeComponent();
            
          }
      
//===========================button LOG IN==========================================
        SqlConnection conn = new SqlConnection(@"server = .\sqlexpress;database = booking_system;integrated security = true; ");
      public  void btnLogIn_Click(object sender, EventArgs e)
        {
          
          try
            {
                conn.Open();
                registration_log login_Form = new registration_log();
                int charUsername = txtUserName.Text.Length;
                if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Text) ||(charUsername < 13) || (charUsername > 13))
                {
                    MessageBox.Show("Please Enter both username and password");                   
               }
                else
                {
                    string userVerification = "SELECT GUEST .idNo  FROM dbo.GUEST WHERE GUEST.PASS_WORD = '" + txtPassword.Text + "'";
                    string passVerification = "SELECT GUEST .PASS_WORD" +
                                                        " FROM dbo.GUEST " +
                                                            " WHERE GUEST .idNo  = '" + txtUserName.Text + "'";
                    SqlCommand cmd = new SqlCommand(userVerification, conn);
                    SqlCommand pscmd = new SqlCommand(passVerification, conn); 
                    try
                    {
                        object id = cmd.ExecuteScalar();
                        object pass = txtPassword.Text;
                        object username = txtUserName.Text;
                        object password = pscmd.ExecuteScalar();
                        if ((id == null) || (password== null))
                        {
                            MessageBox.Show("User is not found or not registered ,\nPlease register");
                        }
                        else
                        {
                            if ((username.ToString() != id.ToString()) && (pass.ToString() != password.ToString()))
                            {
                                MessageBox.Show("User not registered");
                            }
                            else
                            {
                                this.Hide();
                                Booking bookAccommodation = new Booking();
                                bookAccommodation.Show();
                          }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                      
                    }   
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
         }
 //===========================button Register=======================================
       public void btnRegister_Click(object sender, EventArgs e)
        {
            registration_log login_Form = new registration_log();
            this.Hide();          
            registration registerNewClient = new registration();
            registerNewClient.Show();           
        }
//==registration Form code under Here===============================================
      public void registration_log_Load(object sender, EventArgs e)
       {
          

            ControlBox = false;
        }

        public  void chkLogIn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLogIn.Checked == true)
            {
                chkRegister.Enabled = false;
            }
            else
            {
                chkRegister.Enabled = true;
            }
         
            this.ActiveControl = txtUserName; 
            if (chkLogIn .Checked == true )
            {
                grpLogIn.Enabled = true;
                if (this.txtUserName .Visible  && this.txtUserName .Enabled )
                {
                    this.txtUserName.Focus();
                }
            }
            else
            {
                grpLogIn.Enabled = false;
            }
        }
      public  void chkRegister_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegister.Checked == true)
            {
                chkLogIn.Enabled = false;
            }
            else
            {
                chkLogIn.Enabled = true;
            }
            if (chkLogIn.Checked == true)
            {
                chkRegister.Enabled = false;
            }
            if (chkRegister.Checked  ==  true)
            {
                grpRegister.Enabled = true;
            }
            else 
            {
                grpRegister.Enabled = false;
            }
        }
       public  void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
              
            }    
    }
 public  void txtUserName_TextChanged(object sender, EventArgs e)
        {
           
                 int charUsername = txtUserName.Text.Length;
                 txtUserName.MaxLength = 13;
                 if (charUsername == 13)
                 {
                     lbluserval.Text = "Good";
                 }
                 else
                 {
                     lbluserval.Text = "Username not registered";
                 }
        if (charUsername < 1)
        {
            lbluserval.Text = " ";
        }
          
        }
     public void txtPassword_TextChanged(object sender, EventArgs e)
        {
            int charUserPassword = txtPassword.Text.Length;
            txtPassword.MaxLength = 5;
            txtPassword.PasswordChar = '*';
            txtPassword.CharacterCasing = CharacterCasing.Lower;
            if (charUserPassword == 5)
            {
                lblPasValidate.Text = " good ";
            }
            else
            {
               lblPasValidate .Text = "Password is weak";
            }
            if (charUserPassword < 1)
            {
                lblPasValidate.Text = " ";
            }          
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void grpLogIn_Enter(object sender, EventArgs e)
        {
          

        }
    }
}
