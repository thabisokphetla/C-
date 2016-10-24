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

    public partial class Booking : Form
    {
        public Booking() 
        {
            InitializeComponent();
         
            
        }
       
        SqlConnection conn = new SqlConnection(@"server = .\sqlexpress;database = booking_system;integrated security = true; ");
        private void btnExitBooking_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to close the application", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
                registration_log login_Form = new registration_log();
                login_Form.Show();
                
            }
        }
        
        private void Booking_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            string systemDate = "SELECT Convert(varchar(11),getdate(),106)";
            string roomNumber = "SELECT count(room_no) from rooms";
          
            SqlCommand roomNcmd = new SqlCommand(roomNumber, conn);
            SqlCommand dateCmd = new SqlCommand(systemDate, conn);
           
            conn.Open();
           
            lstSelectedRooms.Items.Add("==========================================================================================================");
            lblNumRooms.Text = " " + roomNcmd.ExecuteScalar().ToString();
            lblSystemDate.Text = " " + dateCmd.ExecuteScalar().ToString();
            lblDateRoomTy.Text = " "  +dateCmd.ExecuteScalar().ToString();
           
            string SS = "SELECT COUNT (*)FROM rooms WHERE R_TYPE_CODE ='SS'";
            string SD = "SELECT COUNT (*)FROM rooms WHERE R_TYPE_CODE ='SD'";
            string LS = "SELECT COUNT (*) FROM rooms WHERE R_TYPE_CODE ='LS'";
            string LD = "SELECT COUNT (*) FROM rooms WHERE R_TYPE_CODE ='LD'";
            string HD = "SELECT COUNT (*) FROM rooms WHERE R_TYPE_CODE ='HD'";

            SqlCommand hdcmd = new SqlCommand(HD, conn);
            SqlCommand ldcmd = new SqlCommand(LD, conn);
            SqlCommand lscmd = new SqlCommand(LS, conn);
            SqlCommand sscmd = new SqlCommand(SS, conn);
            SqlCommand sdcmd = new SqlCommand(SD, conn);
         

           lstRoomTypeAv.Items.Add("HONEY MOON " + hdcmd.ExecuteScalar().ToString() + " ROOMS AVAILABLE R1500 P/N");
           lstRoomTypeAv.Items.Add("LUXURY DOUBLE " + ldcmd.ExecuteScalar().ToString() + " ROOMS AVAILABLE R1350 P/N");
           lstRoomTypeAv.Items.Add("LUXURY SINGLE " +lscmd.ExecuteScalar().ToString ()+" ROOMS AVAILABLE R1100 P/N");
           lstRoomTypeAv.Items.Add("STANDARD DOUBLE "+sdcmd.ExecuteScalar().ToString ()+" ROOMS AVAILABLE R1200 P/N");
           lstRoomTypeAv.Items.Add("STANDARD SINGLE "+sscmd.ExecuteScalar().ToString ()+" ROOMS AVAILABLE R950 P/N");

         

            conn.Close(); 
            
        }

        private void grpAcDs_Enter(object sender, EventArgs e)
        {
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void btnSelectedRoom_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
               
                string receipt = "SELECT BOOKING .INVOICE_NO FROM dbo.BOOKING WHERE BOOKING.IDNO = " + txtBookingId.Text + " AND date_booked = '" + BookFrom.Value.Date + "')";

                string IDcompore = "SELECT GUEST.idNo FROM dbo.GUEST WHERE GUEST.idNo = " + txtBookingId.Text;

                SqlCommand idcoCmd = new SqlCommand(IDcompore, conn);

                object sqlIdno = idcoCmd.ExecuteScalar();
                object idnumBkd = txtBookingId.Text;

               


                if (String.IsNullOrEmpty(txtBookingId.Text) || String.IsNullOrEmpty(cmbRoomToBook.Text) || String.IsNullOrEmpty(txtNumberGuest.Text) || String.IsNullOrEmpty(txtNumBkdRooms .Text ))
                    {
                        MessageBox.Show("Please Fill in all the blocks");
                    }
                    else
                    {
                        if (sqlIdno == null)
                        {
                            MessageBox.Show("ID Not registered");
                        }
                        else
                        {
                            // string BookIngdate = "Update dbo.BOOKING SET DATE_BOOKED = " + BookFrom.Value.Date + "WHERE idno = " + txtBookingId.Text;

                            SqlCommand receiptcmd = new SqlCommand(receipt, conn);


                            string bookingId = "Insert Into booking (idno,DATE_BOOKED) values (" + txtBookingId.Text + " ,'"  + BookFrom.Value.Date + "')";
                            SqlCommand Savecmd = new SqlCommand(bookingId, conn);
                            //  SqlCommand updateDate = new SqlCommand(BookIngdate, conn);
                            try
                            {

                                //   conn.Open();
                                //  updateDate.ExecuteNonQuery();

                                Savecmd.ExecuteNonQuery();
                                if (cmbRoomToBook.SelectedItem == null)
                                {
                                    MessageBox.Show("Please Select Rooms");
                                }
                                else
                                {
                 if ((chkBreakfast.Checked == true) && (String.IsNullOrEmpty(txtNumDaysForBreakFast.Text )))
                {
                    MessageBox.Show("Please enter number of days where break fast is prefered");
                                   
                }
                                        
                                     else
                                     {
                                         string toBreakFast = " " ;
                                        if(chkBreakfast .Checked == true )
                                        {
                                             toBreakFast = "Yes";
                                        }
                                        else 
                                        {
                                            toBreakFast = "No";
                                        }

                                        string insertInBooking = "INSERT INTO  ROOMS_BOOKED(IDNO, DATE_BOOKED ,GUESTS,BREAKFAST) " +
                                                                     " VALUES (" + txtBookingId.Text + ", ' " + BookFrom.Value.Date + "' ," + txtNumberGuest.Text + ",'" + toBreakFast + "')";
                                        SqlCommand insertInBook = new SqlCommand(insertInBooking, conn);
                                        try
                                        {



                                            insertInBook.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                        finally
                                        {

                                        }
                                        int breakfastP;
                                        int brfast, bkdays;
                                        if (chkBreakfast .Checked == false)
                                        {
                                            
                                            txtNumDaysForBreakFast.Text  = "0";
                                            breakfastP = 0;
                                        }
                                        else
                                        {
                                            breakfastP = 50;


                                        }
                                        brfast = Convert.ToInt16(txtNumDaysForBreakFast.Text);
                                        bkdays = Convert.ToInt16(txtDaysBooking.Text);
                                        if (brfast > bkdays)
                                        {
                                            MessageBox.Show("Breakfast numbers must not going beyond the days you booked");
                                        }
                                        else
                                        {
                                            lstSelectedRooms.Items.Add("ROOM BOOKING  \t              " + cmbRoomToBook.SelectedItem.ToString());
                                            lstSelectedRooms.Items.Add("NUMBER OF BOOKED ROOMS \t    " + txtNumBkdRooms.Text);
                                            lstSelectedRooms.Items.Add("DAYS BOOKED  \t               " + txtDaysBooking.Text);
                                            lstSelectedRooms.Items.Add("BREAKFAST \t                 " + toBreakFast);
                                            lstSelectedRooms.Items.Add("GUEST QUANTITY \t             " + txtNumberGuest.Text);
                                            lstSelectedRooms.Items.Add("DATE BOOKED \t                " + BookFrom.Text);
                                            decimal discount = 1;
                                            if (chkCash.Checked == true)
                                            {
                                                discount = 0.9M;

                                            }
                                            int guestNumber;
                                            guestNumber = Convert.ToInt16(txtNumberGuest.Text);
                                            decimal additionalMber= 1;
 
                                            if (guestNumber > 1)
                                            {
                                                additionalMber = 0.25M;    
                                            }
                                            if (guestNumber == 1)
                                            {
                                                guestNumber = guestNumber - 1;
                                            }
                                                                                
                                            //SqlCommand cmd = new SqlCommand("SELECT (((r_fee* "+txtNumBkdRooms .Text +") +( r_fee * " +guestNumber+" * "+additionalMber +"))*"+txtDaysBooking .Text + " )+("+breakfastP  + " * " +txtNumberGuest .Text +") FROM ROOM_TYPES where RT_DESC = @txtTotCost", conn); 




                                                SqlCommand cmd = new SqlCommand("SELECT (((((R_FEE * "+additionalMber+   ")*"+txtDaysBooking .Text +")*" + txtNumBkdRooms.Text +")+(" + breakfastP + "*" + txtNumberGuest.Text +
                                                                                   ")) * " + discount +") FROM ROOM_TYPES where RT_DESC = @txtTotCost", conn);
                                                cmd.Parameters.AddWithValue
                                               ("@txtTotCost", cmbRoomToBook.SelectedItem.ToString());
                                                string selectInvoice = "SELECT INVOICE_NO FROM dbo.BOOKING WHERE IDNO =" + txtBookingId.Text + "AND DATE_BOOKED = '" + BookFrom.Value.Date + "'";
                                                SqlCommand invoiceselect = new SqlCommand(selectInvoice, conn);
                                             
                                          
                                              
                                                lstPaymentInfor.Items.Add("Invoice Number " + invoiceselect.ExecuteScalar().ToString());
                                                SqlDataReader dr = cmd.ExecuteReader();
                                                if (dr.Read())
                                                {

                                                    string b = dr[0].ToString();
                                                    // int price;
                                                    //price = (int)dr[0];
                                                    //int tot = b * num;
                                             
                                                    lstPaymentInfor.Items.Add("You are expected to pay R " + dr[0].ToString());

                                                    lstPaymentInfor.Items.Add(" Please do your transaction below ");
                                                    //txtTotCost.Text = b;

                                                }



                                                MessageBox.Show("Your Room Has been reserved. Please Pay the ovarall cost for the booking to be completed");
                                                cmbRoomToBook.SelectedItem.ToString();
                                                txtNumBkdRooms.Text = " ";
                                               
                                                cmbRoomToBook.SelectedItem = " ";
                                                txtNumberGuest.Text = " ";
                                                txtDaysBooking.Text = " ";
                                                grpBooking.Enabled = false;
                                            
                                        }
                                         
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
                    
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
       
        private void lstSelectedRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void grpBooking_Enter(object sender, EventArgs e)
        {
            conn.Open();
         
             cmbRoomToBook.Items.AddRange(new string []{"HONEY MOON","LUXURY DOUBLE","LUXURY SINGLE",
             "STANDARD DOUBLE","STANDARD SINGLE"});
           
            conn .Close ();
        }

        private void chkBreakfast_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBreakfast.Checked == true)
            {
                lblBreakfast.Enabled = true;
                txtNumDaysForBreakFast.Enabled = true;
                lblPricing.Enabled = true;
            }
            else
            {
                lblBreakfast.Enabled = false;
                txtNumDaysForBreakFast.Enabled = false;
            }
        }

        private void txtBookingId_TextChanged(object sender, EventArgs e)
        {
           
           

            int charUsername = txtBookingId.Text.Length;
            txtBookingId.MaxLength = 13;
            if (charUsername == 13)
            {
                lblbkidval.Text = "Good";
            }
            else
            {
                lblbkidval.Text = "Username not registered";
            }
            if (charUsername < 1)
            {
                lblbkidval.Text = " ";
            }
         
        }

        private void cmbRoomToBook_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lstRoomTypeAv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            lstRoomsAvalSpDate.Items.Clear();
            string selectBooked = "SELECT GUEST .INITIALS , GUEST .SURNAME ,ROOMS_BOOKED .ROOM_NO " +
                               " FROM dbo.GUEST ,dbo.ROOMS_BOOKED " +
                             "   WHERE GUEST .idNo = ROOMS_BOOKED .IDNO "+
                                "  AND ROOMS_BOOKED .DATE_BOOKED = '" + dateAvailableRooms.Value.Date +"'";
            conn.Open();
            SqlCommand selectCmd = new SqlCommand(selectBooked, conn);
            object Selected = selectCmd.ExecuteNonQuery ();
            
            SqlDataReader rdr = selectCmd.ExecuteReader();

           
            
                try
                {
                    while (rdr.Read())
                    {
                        if (rdr == null)
                        {
                            MessageBox.Show("No Rooms booked for that day");
                        }
                        else
                        {
                        lstRoomsAvalSpDate.Items.Add(rdr[0].ToString() + " " + rdr[1].ToString() + " ROOM NUMBER IS " + rdr[2].ToString());
                        }
                    }
                }

                catch (SqlException ex)
                {

                }
                finally
                {
                    conn.Close();
                }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstBookING.Items.Clear();
            string selectBooked = "SELECT GUEST.INITIALS , GUEST.SURNAME ,CONCAT(datepart(YYYY,DATE_BOOKED),'/',datepart(mm,DATE_BOOKED),'/',datepart(DD,DATE_BOOKED)) ,ROOMS_BOOKED .ROOM_NO " +
                                           " FROM dbo.GUEST ,dbo.ROOMS_BOOKED " +
                                         "   WHERE GUEST .idNo = ROOMS_BOOKED .IDNO " +
                                            "  AND ROOMS_BOOKED .IDNO= " + txtIDNumber.Text;
           // conn.Open();
            lstBookING.Items.Clear();
            SqlCommand selectCmd = new SqlCommand(selectBooked, conn);
            //object Selected = selectCmd.ExecuteNonQuery();
            
             string IDcompare = "SELECT GUEST.idNo FROM dbo.GUEST WHERE GUEST.idNo = " + txtIDNumber .Text ;
            SqlCommand selectIDcompare = new SqlCommand (IDcompare ,conn );
            int chareCount = txtIDNumber.Text.Length;
            if (String.IsNullOrEmpty(txtIDNumber.Text) || chareCount < 13)
            {
                MessageBox.Show("PLease Input Id Number");
            }
            else
            {
                conn.Open();
                object ids = selectIDcompare.ExecuteScalar();

                try
                {

                    if (ids == null)
                    {
                        MessageBox.Show("ID NUMBER NOT REGISTERED");
                    }
                    else
                    {
                        SqlDataReader rdr2 = selectCmd.ExecuteReader();
                       
                        while (rdr2.Read())
                        {
                            lstBookING.Items.Add(rdr2[0].ToString() + " " + rdr2[1].ToString() + " " + rdr2[2].ToString() + " ROOM NUMBER  " + rdr2[3].ToString() );
                        }
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void txtIDNumber_TextChanged(object sender, EventArgs e)
        {
            int charUsername = txtIDNumber.Text.Length;
            txtIDNumber.MaxLength = 13;
            
        }

        private void chkBookagain_CheckedChanged(object sender, EventArgs e)
        {

            if (chkBookagain.Checked == true)
            {
                grpBooking.Enabled = true;
                lstPaymentInfor.Items.Clear();
                lstSelectedRooms.Items.Clear();
            }
            else
            {
              grpBooking.Enabled = false;
            }
        }

        private void rdbCash_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBookingId.Text))
            {
                MessageBox.Show(" Please Book first before making a payment");
                
            }
            else
            {
                if (chkCash.Checked == true)
                {
                    conn.Open();
                    //string payed = " Select amount_paid FROM dbo.RECEIPT WHERE RECEIPT_NO = " + txtInvoiceNumber .Text ;
                    string invoiceSelect = " select invoice_no FROM dbo.BOOKING Where IDNO = " + txtBookingId.Text;
                    SqlCommand selectInvoi = new SqlCommand(invoiceSelect, conn);

                    txtInvoiceNumber.Text = selectInvoi.ExecuteScalar().ToString();
                   /* string payed = " Select amount_paid FROM dbo.RECEIPT WHERE RECEIPT_NO = " + txtInvoiceNumber.Text;
                    SqlCommand paycmd = new SqlCommand(payed, conn);
                    txtPaidAmount.Text = paycmd.ExecuteScalar().ToString ();*/
                    MessageBox.Show("You get 10% for using cash");
                    txtPaidAmount.Enabled = true;
                    txtInvoiceNumber.Enabled = true;
                    txtCardNumber.Enabled = true;
                    chkCredit.Enabled = false;
                    chkEFT.Enabled = false;
                    btnBOOkIn.Enabled = true;
                }
                else
                {
                    txtPaidAmount.Enabled = false;
                    txtInvoiceNumber.Enabled = false;
                    txtCardNumber.Enabled = false;
                    chkCredit.Enabled = true;
                    chkEFT.Enabled = true;
                    btnBOOkIn.Enabled = false;
                }

                conn.Close();
            }

        }
        private void chkEFT_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            if (String.IsNullOrEmpty(txtBookingId.Text))
            {
                MessageBox.Show(" Please Book first before making a payment");

            }
            else
            {
                if (chkEFT.Checked == true)
                {
                    string invoiceSelect = " select invoice_no FROM dbo.BOOKING Where IDNO = " + txtBookingId.Text;
                    SqlCommand selectInvoi = new SqlCommand(invoiceSelect, conn);


                    txtInvoiceNumber.Text = selectInvoi.ExecuteScalar().ToString();
                   /* string payed = " Select amount_paid FROM dbo.RECEIPT WHERE RECEIPT_NO = " + txtInvoiceNumber.Text;
                    SqlCommand paycmd = new SqlCommand(payed, conn);
                    txtPaidAmount.Text = paycmd.ExecuteScalar().ToString();*/
                    txtPaidAmount.Enabled = true;
                    txtInvoiceNumber.Enabled = true;
                    txtCardNumber.Enabled = true;
                    chkCredit.Enabled = false;
                    chkCash.Enabled = false;
                    btnBOOkIn.Enabled = true;

                }
                else
                {
                    txtPaidAmount.Enabled = false;
                    txtInvoiceNumber.Enabled = false;
                    txtCardNumber.Enabled = false;
                    chkCredit.Enabled = true;
                    chkCash.Enabled = true;
                    btnBOOkIn.Enabled = false;
                }
            }
            conn.Close();
        }

        private void chkCredit_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            if (String.IsNullOrEmpty(txtBookingId.Text))
            {
                MessageBox.Show(" Please Book first before making a payment");

            }
            else
            {
                if (chkCredit.Checked == true)
                {
                    string invoiceSelect = " select invoice_no FROM dbo.BOOKING Where IDNO = " + txtBookingId.Text;
                    SqlCommand selectInvoi = new SqlCommand(invoiceSelect, conn);

                    txtInvoiceNumber.Text = selectInvoi.ExecuteScalar().ToString();

                    /*string payed = " Select amount_paid FROM dbo.RECEIPT WHERE RECEIPT_NO = " + txtInvoiceNumber.Text;
                    SqlCommand paycmd = new SqlCommand(payed, conn);
                    txtPaidAmount.Text = paycmd.ExecuteScalar().ToString();*/
                    txtPaidAmount.Enabled = true;
                    txtInvoiceNumber.Enabled = true;
                    txtCardNumber.Enabled = true;
                    chkEFT.Enabled = false;
                    chkCash.Enabled = false;
                    btnBOOkIn.Enabled = true;
                }
                else
                {
                    txtPaidAmount.Enabled = false;
                    txtInvoiceNumber.Enabled = false;
                    txtCardNumber.Enabled = false;
                    chkEFT.Enabled = true;
                    chkCash.Enabled = true;
                    btnBOOkIn.Enabled = false;
                }
            }
            conn.Close();
        }

        private void lstRoomsAvalSpDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBOOkIn_Click(object sender, EventArgs e)
        {

            string payType = " ";
            decimal disc = 0;
            if (chkEFT.Checked == true)
            {
                MessageBox.Show("Thank You for using cash you will get 10% off from your Total cost");
                payType = "EFT";
                disc = 0.9m;
            }
            else if (chkCash.Checked == true)
            {
                payType = "CSH";
            }
            else if (chkCredit.Checked == true)
            {
                payType = "CRD";
            }
            else
            {
                MessageBox.Show("Select payment type");
            }
            if (String.IsNullOrEmpty(txtInvoiceNumber.Text) || String.IsNullOrEmpty(txtCardNumber.Text) || String.IsNullOrEmpty(txtPaidAmount.Text))
            {
                MessageBox.Show("Please fill in all the fields");
            }
            else
            {
                string cardNom = "insert Into creditcard(card_no) values (" + txtCardNumber.Text + " )";
                string insertTranssction = "iNSERT INTO RECEIPT(RECEIPT_NO,R_DATE,AMOUNT_PAID,PAY_TYPE,DISCOUNT,CARD_NO) VALUES (" + txtInvoiceNumber.Text + ",'" + BookFrom.Value.Date + "'," + txtPaidAmount.Text + ",'" + payType +
                                    "'," + disc + ", " + txtCardNumber.Text + ")";

                string roomNum = "select room_no from  ROOMS_BOOKED WHERE ROOMS_BOOKED.idno = " + txtBookingId.Text;
                SqlCommand cmdRmNum = new SqlCommand(roomNum, conn);
                SqlCommand carno = new SqlCommand(cardNom, conn);
                SqlCommand inserTran = new SqlCommand(insertTranssction, conn);
                try
                {
                    conn.Open();
                    inserTran.ExecuteNonQuery();
                    carno.ExecuteNonQuery();


                    MessageBox.Show("Your Booking is complete use your ID number " + txtIDNumber.Text + " AND Your receipt Number  " + txtInvoiceNumber.Text + " at the help desk to access your booked room. Your Room Number is " + cmdRmNum.ExecuteScalar().ToString());
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }
        private void lstPaymentInfor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBkdOut_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtcancelcard.Text) || String.IsNullOrEmpty(txtidBookingOut.Text) || String.IsNullOrEmpty(txtBookingOutreciept.Text))
            {
                MessageBox.Show("Please fill in all boxes");
            }
            else
            {
               
                string deleteBooking = "delete from BOOKING WHERE INVOICE_NO = " + txtBookingOutreciept.Text + " AND BOOKING.IDNO = " + txtidBookingOut.Text;
                string deleteRomm = "DELETE FROM ROOMS_BOOKED where ROOMS_BOOKED.idno =" + txtidBookingOut.Text;
                string deleteCard1 = "DELETE FROM RECEIPT WHERE CARD_NO = " + txtcancelcard.Text;
                string deleteCard = "DELETE FROM CREDITCARD WHERE CARD_NO = " + txtcancelcard.Text;
                SqlCommand deletRocmd = new SqlCommand(deleteRomm, conn);
                SqlCommand decmd = new SqlCommand(deleteCard1, conn);
                SqlCommand cardcmd = new SqlCommand(deleteCard, conn);
               
                try
                {
                    conn.Open();
                   
                    SqlCommand deleteCmd = new SqlCommand(deleteBooking, conn);
                    decmd.ExecuteNonQuery();
                    cardcmd.ExecuteNonQuery();
                    deletRocmd.ExecuteNonQuery();
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("Your Booking was successfully cancelled.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtidBookingOut_TextChanged(object sender, EventArgs e)
        {
            int charUsername = txtidBookingOut.Text.Length;
            txtidBookingOut.MaxLength = 13;
        }
    }

}
