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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
         
        }
        SqlConnection conn = new SqlConnection(@"server = .\sqlexpress;database = booking_system;integrated security = true; ");
        private void btnCloseRegistration_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
             
                this.Close();
               registration_log login_Form = new registration_log();
                login_Form.Show();
               
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            int charId = txtId.Text.Length;
            txtId.MaxLength = 13;
            if (charId == 13)
            {
                lblidValidate.Text = "Good";
            }
            if (charId <13)
            {
                lblidValidate.Text = "13 Digits only";
            }
             
       
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            int charPassword = txtPassword.Text.Length;
            txtPassword.MaxLength = 5;
            txtPassword.PasswordChar = '*';
            txtPassword .CharacterCasing = CharacterCasing .Lower ;
            if (charPassword == 5)
            {
                lblPasswordValid.Text = "Password Is Strong";
            }
            else
            {
                lblPasswordValid.Text = "Password Is weak";
            }
            if (charPassword < 1)
            {
                lblPasswordValid.Text = " Enter 5 charecters ";
            }
        }

        private void registration_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }

        private void BtnRegistration_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSurname.Text) || String.IsNullOrEmpty(txtConformPasswordR.Text)
                        || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtInitials.Text) ||
                 String.IsNullOrEmpty(txtHStreetAddr.Text) || String.IsNullOrEmpty(txtHSuburb.Text) || String.IsNullOrEmpty(txtHPostalCode.Text)||
                String.IsNullOrEmpty(txtContactNo.Text) || String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtInitials.Text))
            {
                MessageBox.Show("Fill In all Fields");
            }

            else
            {
                if (txtPassword.Text != txtConformPasswordR.Text)
                {
                    MessageBox.Show("Password do not Match");
                }
                else
                {
                    string registering = "INSERT INTO dbo.GUEST(idNo ,SURNAME ,INITIALS ,PASS_WORD ,HSTREETADDR ,HSURBURB ,HTOWN ,HPOSTALCODE, ContactNo)" +
                     "VALUES ( " + txtId.Text.ToUpper () + ",'" + txtSurname.Text.ToUpper () + "','" + txtInitials.Text.ToUpper ()+ "','" + txtPassword.Text.ToUpper () + "','" + txtHStreetAddr.Text.ToUpper () + "','" +
                     txtHSuburb.Text.ToUpper () + "','" + txtHtown.Text.ToUpper () + "','" + txtHPostalCode.Text.ToUpper () + "', '" + txtContactNo.Text.ToUpper () + "')";

                    SqlCommand cmd = new SqlCommand(registering, conn);
                    try
                    {
                        conn.Open();
                        int charId = txtId.Text.Length;
                        if (charId < 13)
                        {
                            MessageBox.Show("Id Must be 13 digits");
                        }


                        cmd.ExecuteNonQuery();




                        MessageBox.Show("Registration for " + txtInitials.Text + " " + txtSurname.Text + " was successfully, You can now log In and Do your bookings");
                        Booking bookAccommodation = new Booking();
                        this.Hide();
                        registration_log login_Form = new registration_log();
                        login_Form.Show();

                    }


                    catch (SqlException ex)
                    {
                        MessageBox.Show("error " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            txtContactNo.MaxLength = 10;
            int charContacts = txtContactNo.Text.Length;
            if ((charContacts < 10)||(charContacts >10))
            {
                lblContact.Text = " Numbers must be 10 digits";
            }
            else
            {
                lblContact.Text = "OK";
            }
            if (charContacts < 1)
            {
                lblContact.Text = " ";
            }
        }

        private void txtConformPasswordR_TextChanged(object sender, EventArgs e)
        {
            int charPassword = txtConformPasswordR.Text.Length;
            txtConformPasswordR.MaxLength = 5;
            txtConformPasswordR.PasswordChar = '*';
            txtConformPasswordR.CharacterCasing = CharacterCasing.Lower;
            if (txtConformPasswordR.Text  == txtPassword.Text  )
            {
                lblConf.Text = "Password Matches";
            }

            else
            {
                lblConf.Text = "Not Matching";
            }
            if (charPassword < 1)
            {
                lblConf.Text = " Enter 5 charecters ";
            }

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
