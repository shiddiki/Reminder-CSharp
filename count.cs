using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    class count
    {



        public count()
        { 
        
        }

        public long counter(int remy,int remm, int remd,int remh,int remmin)
        {
            int y = remy, mon = remm, d = remd, h = remh, minn = remmin;
            long countDownT = 0;
            int strmin = DateTime.Now.Minute;
            int strh = DateTime.Now.Hour;
            int strd = DateTime.Now.Day;
            int strmon = DateTime.Now.Month;
            int stry = DateTime.Now.Year;

            if (minn < strmin)
            {
                minn += 60;
                h--;
                countDownT += minn - strmin;
            }
            else
                countDownT += minn - strmin;
            if (h < strh)
            {
                d--;
                h += 24;
                countDownT += (h - strh) * 60;
            }
            else
                countDownT += (h - strh) * 60;
            if (d < strd)
            {
                mon--;
                d += 30;
                countDownT += ((d - strd) * 24) * 60;
            }
            else
                countDownT += ((d - strd) * 24) * 60;
            if (mon < strmon)
            {
                mon += 12;
                y--;
                countDownT += ((mon - strmon) * 30) * 24 * 60;
            }
            else
                countDownT += ((mon - strmon) * 30) * 24 * 60;
            countDownT += (y - stry) * 365 * 24 * 60;


            return countDownT;
        
        }



        
    }
}
