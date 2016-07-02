using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class REMINDER : Form
    {
        System.IO.Stream music;

        public bool flag,restart=false;
        public static int uYr, uMn, uDa, uHr, uMin;
        public static long left;
        public static long hour,chour;
        public static long minute,cminute;
        public static long valid,valid1,wrt,temp;
        public static string day;
        public static string month;
        public static string year;
        public static string work;
        public static string tempu;
        public static long prew;
        static int noti = 1;
        public static int nothour = 60,notnow=-9;  //nothour means how many minute gap
        public static string notistring = "";

        //for warning global
        public static string kaj, ddayy, mmonthy, yyearr, hhourr, mminutee, ssecc;
        static Thread warn;

        public REMINDER()
        {
            
           

            


            

            InitializeComponent();


            /////
          
            /////
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;
            checkBox2.BackColor = Color.Transparent;
            //textBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            dateTimePicker1.Text = "";
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Visible = false;
            textBox1.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            button3.Enabled=false;
            //File.Create("settings.txt");

            if (noti == 1)

            {
                notifyIcon1.Text = "Reminder";
               
                notifyIcon1.ShowBalloonTip(100, "REMINDER", "Reminder has started. ", ToolTipIcon.Info);
                //notifyIcon1.Icon = new System.Drawing.Icon();
                
            }
            else

            {
                notifyIcon1.ShowBalloonTip(1000, "REMINDER", "Reminder has stopped. ", ToolTipIcon.Info); noti = 1;


                System.Threading.Thread.Sleep(2000);
                notifyIcon1.Icon = null;
            }

            flag = false;
           /////////////////////////////////////////////////////---------------
            //
            
            initial inc = new initial();
            valid = inc.opening();


            RESTART:

            if (valid < 1000)
            {

                
                    MessageBox.Show("There is an ERROR in file system!!");
                 
                
                    //restart = true;

                

            }
            else 
            {


                wrt = valid % 1000;
                valid /= 1000;
                minute = valid % 100; valid /= 100;
                hour = valid % 100; valid /= 100;

                temp = valid % 100; valid /= 100;
                day = temp.ToString();
                temp = valid % 100; valid /= 100;
                month = temp.ToString();
                //temp = valid % 1;
                year = valid.ToString();

                count cnt = new count();
                int a = Convert.ToInt32(year), b = Convert.ToInt32(month), c = Convert.ToInt32(day);
                left = cnt.counter(a, b, c, Convert.ToInt32(hour), Convert.ToInt32(minute));
                textBox2.Text = year;
                //MessageBox.Show("Closest work to do at "+year+"\\"+month+"\\"+day+" at "+hour+" : "+minute);
                int lefsec = Convert.ToInt32(left);
               // progressBar1.Maximum = 100;
                //progressBar1.Step = 1;


            }
        }

        ///
        ///
        /// notifyicon click
        ///



        private void losep()
        {

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            music =
                thisExe.GetManifestResourceStream("Reminder.forRem.wav");
            System.Media.SoundPlayer playerb = new System.Media.SoundPlayer(music);
            playerb.Play();
        }

        public void warning()
        {
            MessageBox.Show("Time Up.\n"+ kaj.ToUpper() + "AT " + DateTime.Now.ToString());
            notistring = "  ";
            notistring += kaj.ToUpper() + "AT "+DateTime.Now.ToString();
            notifyIcon1.ShowBalloonTip(100000, "REMINDER", notistring, ToolTipIcon.Warning);

            warn.Abort();
        }

        /// <summary>
        /// New Entry Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void button1_Click(object sender, EventArgs e)
        {
            //REMINDER re = new REMINDER();
            //re.Size = new System.Drawing.Size(700, 700);
            //Form.ActiveForm.Height -= 100;
            //textBox2.Enabled = true;
            dateTimePicker1.Visible = true;
            dateTimePicker1.Enabled = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            textBox3.Visible = true;
            textBox3.Enabled = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox4.Visible = true;
            textBox4.Enabled = true;
            
            button3.Visible = true;
            
           
            button3.Enabled=true;
            //hour = ;
            //minute = 99999;99999
            work = "";
            //for (int i = 0; i < 10; i++)
            flag = true;
            

        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 2;
            try
            {
                chour = int.Parse(textBox1.Text);
                //textBox2.Text = hour.ToString() + ":" + minute.ToString();
            }
            catch
            {
                //MessageBox.Show("enter hour");
            }
           }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 2;
            try
            {
                cminute = int.Parse(textBox3.Text);

                
                //MessageBox.Show(newmin.ToString());
                //textBox2.Text = hour.ToString() + ":" + minute.ToString();
        
              /*  int y = 9;
                while (y!=0)
                    textBox2.Text = y.ToString(); y--;
               
                if (textBox3.Text.Length == 2)
                {
                    
                    countdown cn = new countdown();
                    int newmin = minute, newh = hour;

                    while (newh != 0 && newmin != 0)
                    {
                        newmin = cn.show(Form1.minute);
                        if (newmin == 0)
                            newh--;
                        textBox2.Text = newh.ToString() + ":" + newmin.ToString();
                        //MessageBox.Show(newmin.ToString());
                        
                    
                    }

                }
                */

            }
            catch
            {
               // MessageBox.Show("use mouse pointer to change in hour");
            
            
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            //System.Threading.Thread.Sleep(100);
            
            timer1.Interval = 1000;
            timer1.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
           // MessageBox.Show("All entries are saved. Safe to close.");
            Application.Exit();
        }
     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///  WORK STATION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            textBox5.Text = DateTime.Now.ToString();

            /////////////////////////////////
            int progleft=0;
            count cnt = new count();
            int a = Convert.ToInt32(year), b = Convert.ToInt32(month), c = Convert.ToInt32(day);
            left = cnt.counter(a, b, c, Convert.ToInt32(hour), Convert.ToInt32(minute));



            int lef, usec;
            lef = Convert.ToInt32(left);

            
                
            //progressBar1.Maximum = 100 ;
            //progressBar1.Step = 1;//Convert.ToInt32(lef/100);
            //while(progressBar1.Step !=lef)
            //progressBar1.PerformStep();

            
            uYr = lef / (365 * 24 * 60);
            uMn = (lef % (365 * 24 * 60)) / (30 * 24 * 60);
            uDa = ((lef % (365 * 24 * 60)) % (30 * 24 * 60)) / (24 * 60);
            uHr = (((lef % (365 * 24 * 60)) % (30 * 24 * 60)) % (24 * 60)) / 60;
            uMin = (((lef % (365 * 24 * 60)) % (30 * 24 * 60)) % (24 * 60)) % 60;

            usec = 60 - DateTime.Now.Second;
            if (usec != 0)
            {
                uMin--;
                if (uMin < 0)
                { uHr--; uMin = 59; }
                if (uHr < 0)
                {
                    uDa--; uHr = 23;
                }
                if (uDa < 0)
                {
                    uMn--; uDa = 29;
                }
                if (uMn < 0)
                { uYr--; uMn = 11; }
                if (uYr < 0)
                {
                    uYr = 0;
                
                }
            
            
            }
            progleft = lef;
            if (usec == 60)
                usec = 0;
           /* {
                uMin--;
                if (uMin < 0)
                { uMin = 59; uHr--; }
                if (uHr < 0)
                { uHr = 23; uDa--; }
                if (uDa < 0)
                { uMn--; uDa = 29; }
                if (uMn < 0)
                { uMn = 11; uYr--; }



            }
            */
           // progressBar1.PerformStep();


            //////////////

            
            string job = initial.st;

            ///
            int din1 = Convert.ToInt32(day);
            int mont1 = Convert.ToInt32(month);
            int ye1 = Convert.ToInt32(year);
            string hh, minu, mont, din, ye; hh = hour.ToString("00"); minu = minute.ToString("00"); din = din1.ToString("00"); mont = mont1.ToString("00"); ye = ye1.ToString("0000");
            
            ///

            if (Convert.ToInt32(year) < 9000)
            {

                


                textBox2.Text = uYr + " : " + uMn + " : " + uDa + "  " + uHr + " : " + uMin + " : " + usec + " left";
                if(hour>=0 && hour <12)
                textBox6.Text = job + " at " + din + "/" + mont + "/" + ye + "   " + hh + ":" + minu +" AM";
                else
                    textBox6.Text = job + " at " + din + "/" + mont + "/" + ye + "   " + hh + ":" + minu + " PM";

                //MessageBox.Show(progleft.ToString() + checkBox1.Checked);

                if (progleft <= 30)
                    nothour = 30;
                else
                    nothour = 60;
                if (progleft <= 15)
                    nothour = 15;

                if (notnow == -9)
                    nothour = 1;


                if (progleft % nothour == 0 && checkBox1.Checked==true && progleft<=1440 && notnow!=progleft)
                {
                    noti = 2;
                    notnow =progleft;
                    notistring = " ";
                    try
                    {
                        
                        if (hour >= 0 && hour < 12)
                            notistring += "You had "+job.ToUpper() + " to do at " + din + "/" + mont + "/" + ye + "   " + hh + ":" + minu + " AM";
                        else
                            notistring += "You had " + job.ToUpper() + " to do at " + din + "/" + mont + "/" + ye + "   " + hh + ":" + minu + " PM";
                      
                        //notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(1000, "REMINDER", notistring, ToolTipIcon.Warning);
                        //notifyIcon1.ShowBalloonTip(1,"","",tool
                        if(nothour==15)
                            System.Media.SystemSounds.Asterisk.Play();

                        
                        //notifyIcon1.Visible = false;
                    }
                    catch
                    { 
                    
                    }
                
                }
            }
            else
            {
                textBox2.Text = "";
                textBox6.Text = "No Scheduled Task Has Been Found Yet!";
            }
            int th, tm, td, tmon, ty,dt,y,mm, notflag;
            dt = Convert.ToInt32(day);
            mm =Convert.ToInt32(month);
            y = Convert.ToInt32(year);
            th = DateTime.Now.Hour;
            tm = DateTime.Now.Minute;
            td = DateTime.Now.Day;
            tmon = DateTime.Now.Month;
            ty = DateTime.Now.Year;


            

            //chour = hour;
            //cminute = minute;
            //if (tm == minute && th == hour && td==dt && tmon==mm && ty==y)// (tmon == Convert.ToInt32(month))) && (ty = Convert.ToInt32(year)) && (td == Convert.ToInt32(day))) ;
            if(!validityChecker.timecheck() && !flag)
            {
                
                timer1.Enabled = false;
                int aud = 1;
                
                try
                {
                    if (checkBox2.Checked == true)
                        losep();
                
                }
                catch 
                {
                    aud = 0;
                    
                }

                delete dtt = new delete();
                int done = dtt.del();
                

                try
                {
                    if (aud == 0)
                    {

                       
                        for (int u = 0; u < 10; u++)
                        {
                            System.Media.SystemSounds.Asterisk.Play();

                            System.Threading.Thread.Sleep(500);
                        }

                        MessageBox.Show("Audio file not set. Corrupted File.");
                    }
                    initial ince = new initial();
                    valid = ince.opening();

                   /* MessageBox.Show("Time Up.\n You had " + job.ToUpper() + " to do.");*/
                    notistring = "  ";
                    notistring += "You had " + job.ToUpper() + " to do";
                    notifyIcon1.ShowBalloonTip(100000, "REMINDER", notistring, ToolTipIcon.Warning);
                    

                    kaj += notistring;

                    warn = new Thread(warning);

                    warn.Start();

                    Thread.Sleep(2000);

                    notnow = -9;
                }
                catch 
                {
 
                }
                /////////////////////////////////////////////////////**************************
                ////*********************///
                initial inc = new initial();
                valid = inc.opening();

                if (valid == 0)
                {
                    Application.Exit();
                    MessageBox.Show("There is an ERROR in file system!!");

                }
                else
                {

                    wrt = valid % 1000;
                    valid /= 1000;
                    minute = valid % 100; valid /= 100;
                    hour = valid % 100; valid /= 100;

                    temp = valid % 100; valid /= 100;
                    day = temp.ToString();
                    temp = valid % 100; valid /= 100;
                    month = temp.ToString();
                    //temp = valid % 1;
                    year = valid.ToString();

                    count cntt = new count();
                    int aa = Convert.ToInt32(year), bb = Convert.ToInt32(month), cc = Convert.ToInt32(day);
                    left = cntt.counter(aa, bb, cc, Convert.ToInt32(hour), Convert.ToInt32(minute));



                    //MessageBox.Show("Closest work to do at " + year + "\\" + month + "\\" + day + " at " + hour + " : " + minute + " left" + left);
                    //progressBar1.Maximum = Convert.ToInt32(left);
                    //progressBar1.Step = 1;


                }
                ////*********************///
                ////////////////////////////////////////////////////***************************NEW TASK INITIATION


                if (done == 1)
                {
                    

                    textBox2.Text = "Initiating new task....";
                    textBox5.Text = "";
                    textBox1.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    //year = day = month = "";
                    

                    string pathe = @"C:new.txt";

                    

                   // newEntry nw = new newEntry();
                    //int res = nw.entry(hour.ToString(), minute.ToString(), day, month, year, work); //calling to entry :)

                }
                    else
                        MessageBox.Show("failed to initiate new task.");




                }





            }
        /// <summary>
        /// ENTRY AREA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

      


        private void button3_Click(object sender, EventArgs e)
        {

            if (File.Exists(@"E:\\forRem.mp3"))
            {
                //MessageBox.Show("yes");

            }
            else
            {

                MessageBox.Show("SET an audio file with path E:\\forRem.mp3");


            }
            
            string yy,moo,dyy;
            yy=year;moo=month;dyy=day;
            year = day = month = "";
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            for (int i = 0; i < 4; i++)
                year += theDate[i];
            for (int i = 5; i < 7; i++)
                month += theDate[i];
            for (int i = 8; i < 10; i++)
                day += theDate[i];
            long hrr, minn;
            hrr = hour;
            minn = minute;
            hour = chour;
            minute = cminute;
           

            ///message box area to ask before save
            ///
            int din1 = Convert.ToInt32(day);
            int mont1 = Convert.ToInt32(month);
            int ye1 = Convert.ToInt32(year);
            string hh, minu, mont, din, ye; hh = hour.ToString("00"); minu = minute.ToString("00"); din = din1.ToString("00"); mont = mont1.ToString("00"); ye = ye1.ToString("0000");
            
            DialogResult result1 = MessageBox.Show( din + "/" + mont + "/" + ye + " at " + hh + " : " + minu+ " to do "+work," Do You Want To Save This Task??",MessageBoxButtons.YesNo);

            int dushtami = 0;

            if (hour > 23 || hour < 0 || minute > 59 || minute < 0)
                dushtami = 1;

            


            if (work.Length > 0 && dateTimePicker1.Checked && validityChecker.timecheck() && (result1 == DialogResult.Yes) && dushtami ==0)
            {
                flag = false;
                textBox2.Text = "starting";
                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                dateTimePicker1.Text = "";
                dateTimePicker1.Enabled = false;


                string pathe = @"E:\task.txt";

                if (File.Exists(pathe))
                {
                    //MessageBox.Show("yes");
                }
                else
                    MessageBox.Show("No");

                newEntry nw = new newEntry();
                int res = nw.entry(hour.ToString(), minute.ToString(), day, month, year,work); //calling to entry :)

                if (res == 1)
                {
                    textBox2.Text="Saved Successfully!";
                    //for(int i=0;i<100000000;i++)
                    {int aa=3;int bb=5;}

                    //MessageBox.Show("Saved Successfully!");
                    button3.Enabled=false;
                    int many=0;
                    string faltu;
                    using (System.IO.StreamReader file = new System.IO.StreamReader(@"E:\tasknumber.txt"))
                    {
                        faltu = file.ReadLine();
                    }

                    many = Convert.ToInt32(faltu)+1;

                    StreamWriter sw1 = new StreamWriter(@"E:\tasknumber.txt");
                    sw1.WriteLine(many);
                    sw1.Dispose();
                    //textBox1.Text = "";
                    //textBox3.Text = "";
                    //textBox4.Text = "";
                }
            
                else
                    MessageBox.Show("Failed to save!");

                ////////////
                /*
                string path = @"C:new.txt";

                if (File.Exists(path))
                {
                    MessageBox.Show("yes");
                }
                else
                    MessageBox.Show("No");

                */
                /////////////////

                ////*********************///
                initial inc = new initial();
                valid = inc.opening();

                if (valid == 0)
                {
                    Application.Exit();
                    MessageBox.Show("There is an ERROR in file system!!");

                }
                else
                {

                    wrt = valid % 1000;
                    valid /= 1000;
                    minute = valid % 100; valid /= 100;
                    hour = valid % 100; valid /= 100;

                    temp = valid % 100; valid /= 100;
                    day = temp.ToString();
                    temp = valid % 100; valid /= 100;
                    month = temp.ToString();
                    //temp = valid % 1;
                    year = valid.ToString();

                    count cnt = new count();
                    int a=Convert.ToInt32(year), b= Convert.ToInt32(month), c=Convert.ToInt32(day);
                    left=cnt.counter(a,b, c,Convert.ToInt32(hour) ,Convert.ToInt32(minute) );

                    string job = initial.st;

                    //MessageBox.Show("Closest work to do at " + year + "\\" + month + "\\" + day + " at " + hour + " : " + minute+" left"+left);
                   
                    // progressBar1.Maximum =Convert.ToInt32(left);
                    //progressBar1.Step = 1;
                
                
                }                
                ////*********************///






                //MessageBox.Show(year + ":" + month + ":" + day+ "   "+hour+" : "+minute);
            }
            else
            {
                hour = hrr;
                minute = minn;
                year = yy;
                month = moo;
                day = dyy;
                if (result1 == DialogResult.Yes)
                MessageBox.Show("INVALID Schedule!!");
               
                    


           // year = "99999";
            flag = false;
            
            }

            
            
            button3.Enabled = false;
            textBox1.Text = "--";
            textBox3.Text = "--";
            textBox4.Text = "work to do";

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker1.Text = "";
            dateTimePicker1.Enabled = false;
            button3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void REMINDER_Load(object sender, EventArgs e)
        {
            if (restart==true)
            {

                Application.Exit();
            
            
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 14;
            work = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Child Form Activator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //button4.Enabled = false;
            Form2 frm = new Form2();
            frm.ShowDialog(); //waits for response then activates parent form :)
           
            //frm.Show();

            //button4.Enabled = true; 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            About frm3 = new About();
            frm3.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

      
       

          
    }
}
