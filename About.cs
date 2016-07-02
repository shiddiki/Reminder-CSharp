using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            richTextBox1.Text =
                "|******************************************************************************\n" +
                "|**********************************REMINDER************************************\n" +
                "|******************************************************************************\n" +
                "|======================                                ========================\n" +
                "|======================   Owner: Nur-A-Alam Shiddiki   ========================\n" +
                "|======================   CSE'12, CUET                 ========================\n" +
                "|======================   Project-2                    ========================\n"+
                "|======================                                ========================\n" +
                "|======================   Initiated At                 ========================\n" +
                "|======================‎   June ‎29, ‎2015, ‏‎3:35:08 AM    ========================\n" +
                "|======================   Completed At                 ========================\n" +
                "|======================   July ‎03, ‎2015, ‏‎6:12:43 AM    ========================\n" +
                "|======================                                ========================\n" +
                "|******************************************************************************\n" +
                "|\n|\n|**Features\n|-----------\n|- Stores Schedules in HardDrive.\n" +
                "|- Tasks Are Safe even while Power is OFF.\n" +
                "|- When a New entry is made, Checks whether it is the closest Task or not.\n" +
                "|- Waits for response before starting a new countdown, when Time's Up. \n" +
                "|- Time range, within Task Entry time to next 136+ Years.\n"+
                "|- Upto 199 Schedules can be saved.\n"+
                "|- Automatically Deletes previous Tasks.\n"+
                "|- Alerts about the Schedules that were in the period when REMINDER wasn't\n"+
                "|- running.\n"+
                "|- if Notification Enabled...\n"+
                "|- Notifies about the upcoming work (within 24 hours) at every hour. \n"+
                "|- Notifies about the upcoming work (within 1 hour) at 30 minutes before the \n" +
                "|- Schedule.\n"+
                "|- Almost all exceptions are handled.\n" +
                "|- Almost bug free.\n" +
                "|------------\n|--TIPS--\n" +
                "|- to automatically start REMINDER at startup, paste a shortcut file of this \n"+
                "|- .exe file in startup folder. (at Start Menu)\n" +
                "|\n" +
                "|\n" +
                "|- ** tasknumber.txt saves the number of tasks. If there is an Error\n" +
                "|- make sure this is OK. alarm .mp3 must have the name 'forRem'\n" +
                "|******************************************************************************";
            //richTextBox1.Enabled = false;
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
