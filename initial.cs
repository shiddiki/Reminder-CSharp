using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication2
{
    class initial
    {
        string CurrentLine;
         public static string st;
        //int LastLineNumber,remy,remm,remd,remin,remh=0;
       long temp,maxx;
        public initial()
        { 
        
        
        }

        public long opening()
        {

            if (File.Exists(@"E:\task.txt"))
            {
                //MessageBox.Show("yes");

            }
            else
            {

                File.Create(@"E:\task.txt");
                TextWriter tw = new StreamWriter(@"E:\task.txt");
               // tw.WriteLine("The very first line!");
                tw.Close();
            
            
            }
               

                if (File.Exists(@"E:\tasknumber.txt"))
                {
                    //MessageBox.Show("yes");
                }
                else
                {
                    File.Create(@"E:\tasknumber.txt");
                    TextWriter tw = new StreamWriter(@"E:\tasknumber.txt");
                    tw.WriteLine("0");
                    tw.Close();
                
                
                }


            ////////
             int many=0;
                    string faltu;
                    using (System.IO.StreamReader file1 = new System.IO.StreamReader(@"E:\tasknumber.txt"))
                    {
                        faltu = file1.ReadLine();
                    }

                    many = Convert.ToInt32(faltu);
           
            ///////
            
            CurrentLine = "";
            maxx = 99999999999999;
            temp = 0;
            int LastLineNumber=0,remy=0,remm=0,remd=0,remin=0,remh=0,todo=0,min=999;
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"E:\task.txt"))
            {
                // Skip lines
                string s;
                while (todo<=6*many)
                {
                   
                 
                   CurrentLine = file.ReadLine();
                   if (LastLineNumber <5)
                   {
                       if (LastLineNumber == 0)
                       {
                           try
                           {
                               remy = Convert.ToInt32(CurrentLine);
                           }
                           catch
                           {
                                   return todo;
                               
                           }
                            }  
                   
                   
                       else if (LastLineNumber == 1)
                   { try
                           {
                               remm = Convert.ToInt32(CurrentLine);
                           }
                           catch
                           {
                                   return todo;
                               
                           }}
                       else if (LastLineNumber == 2)
                   {try
                           {
                               remd = Convert.ToInt32(CurrentLine);
                           }
                           catch
                           {
                                   return todo;
                               
                           }}
                       else if (LastLineNumber == 3)
                   {try
                           {
                               remh = Convert.ToInt32(CurrentLine);
                           }
                           catch
                           {
                                   return todo;
                               
                           }}
                       else if (LastLineNumber == 4)
                   {try
                           {
                               remin = Convert.ToInt32(CurrentLine);
                           }
                           catch
                           {
                                   return todo;
                               
                           }}
                       LastLineNumber++;
                       
                   }
                   else if (LastLineNumber == 5)
                   {
                       temp = remy * 100 + remm;
                       temp = temp * 100 + remd;
                       temp = temp * 100 + remh;
                       temp = temp * 100 + remin;
                       if (temp < maxx)
                       { maxx = temp;
                       min = todo;
                       st = CurrentLine;
                           
                           
                       }
                       
                       LastLineNumber = 0;
                   }

                   
                   todo++;
                }
                
            }



            return maxx*1000+min;

        }

      
        
        
        
        
        


    }
}
