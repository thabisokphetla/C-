using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question4
{
    public partial class Form1 : Form
    {
        DateTime shifStart;
        DateTime shiftEnd;
        DateTime shifCounter;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartShift_Click(object sender, EventArgs e)
        {
            /* Q 4.1 (5)
             * 
             * Makhulu ULU transport services makes deliveries to all major towns and cities in South Africa. 
             * 
             * They have asked you to develop an application that will ensure their drivers are not over worked. 
             * 
             * To ensure driver safety they need to ensure that a driver does not drive more then 36 hours in one shift.
             * 
             * When btnStartShift is clicked write the code that will:
             * 
             * Set the class variable named shifStart equal to the current date and time.
             * 
             * Set the class variable shiftEnd equal to shifStart with 36 hours added.
             * 
             * clear the list box named lstShiftPlan 
             * 
             * Add both the shiftStart and shiftEnd values to the list box named lstShiftPlan in the following format:
             * 
             *     New shift started at {{shifStart}} shift will end at  {{shifEnd}}.
             * 
             * You must use the standard date time format string "g" (General date/time pattern) as the format when displaying the shiftStart and shiftEnd
             * 
             */

            btnAddTrip.Enabled = true; //Provided

            shifStart = DateTime.Now; //1
            //shifStart = System.DateTime;
          shiftEnd = shifStart.AddHours(36); //1
           // shiftEnd = DateTime.Parse(shifStart + 36);
            lstShiftPlan.Items.Clear(); //1

            lstShiftPlan.Items.Add(String.Format("New shift started at {0} shift will end at  {1}.", shifStart.ToString("dd/MM/yyyy hh:mm:ss's'"), shiftEnd.ToString("dd/MM/yyyy hh:mm:ss's'"))); //2 - Correctly adding start and stop time

        }

        private void btnAddTrip_Click(object sender, EventArgs e)
        {
            /*Q 4.2 (15)
             * 
             * The Listbox named lstLocations contains a number of town where deliveries is made to. The data for each town is in the following format:
             * 
             * Each line of the list box  represents one delivery location in the following format:
             * 
             * TOWN,DISTANCE,TIME
             * 
             * Example:
             * 
             * Capetown:1200:12
             * 
             * Fields:
             *  TOWN: The name of the town or city
             *  DISTANCE: The distance to the city and back again.
             *  TIME: The time it takes in hours to drive to the city and back again.
             * 
             * When btnAddTrip is clicked write the code that will:
             * 
             * Add the selected line from lstLocations to lstShiftPlan in the following format:
             * 
             *  New trip added for driver to {{TOWN}} trip will take  {{TIME}} hours.
             * 
             * Example:
             * 
             *  New trip added for driver to Capetown trip will take 12 hours.
             *  
             * The application should also indicate how the trip will affect the time allocated for the drivers shift. 
             * 
             * This can be accomplished by adding the amount of time the trip will take to the shift start time as every new trip is added. You can use class variable shifCounter for this purpose.
             * 
             * Make sure that the shifCounter is set equal to the  shifStart time when only the first trip is added. As more trips is added the shifCounter should be incremented with the time it takes to make the selected trip. 
             * 
             * The following line should be added to lstShiftPlan 
             * 
             * Selected trip will end at {{shifCounter}} shift must end at {{SHIFT END TIME}} driver can work {{HOURS}} more hours.
             * 
             * This should be repeated for every new trip added to the shift. As new trips are added the shift time calculation above should be updated accordingly.
             * 
             * If at any time the drivers shift exceeds 36 hours the following line should be added to the list box named lstShiftPlan:
             * 
             * Above trip is not possible as it exceeds the 36 hours allocated time please remove the trip. 
             * 
             * You must use the standard date time format string "g" (General date/time pattern) as the format when displaying any date time variables.
             * 
             */

            //2 - Shift counter should on = shifStart if the first trip is added 
            if(shifCounter == DateTime.MinValue)
            {
                shifCounter = shifStart;
            }

            // 3 - Extract the duration and the location for selected trip (Must be correct for 3 marks)
            string line = (string)lstLocations.Items[lstLocations.SelectedIndex];
           
            string location = line.Split(':')[0];
            int time = Convert.ToInt32(line.Split(':')[2]);

            //1 - Add the trip to lstShiftPlan
            //lstShiftPlan.Items.Add(String.Format("New trip added for driver to {0} trip will take  {1} hours.", location,time));
            lstShiftPlan.Items.AddRange(new string[] { "New trip added for driver to " + location + " trip will take  " +  time.ToString() + " hours."});

            //2 - Calculate the {{SHIFT START TIME or SHIFT START TIME WITH PREVIOS TRIPS ADDED  + TRIM DURATION TIME(TIME)}}
            shifCounter = shifCounter.AddHours(time);

            //2 Calculate how many hours the driver can still work (any method acceptable)
            TimeSpan hoursRem = shiftEnd.Subtract(shifCounter);

            //2 - Show information(notice Total hours)
            lstShiftPlan.Items.Add(String.Format("Selected trip will end at {0} shift must end at {1} driver can work {2} more hours.", shifCounter.ToString("g"), shiftEnd.ToString("g"), hoursRem.TotalHours.ToString() ));

            //3 - Check if time is exceeded
            if(hoursRem.TotalHours < 0)
            {
                lstShiftPlan.Items.Add("Above trip is not possible as it exceeds the 36 hours allocated time please remove the trip.");
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
