using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoManXM.Weather;
using System.ServiceModel;
using System.Runtime.InteropServices;
using HoManXM.cn.com.webxml.www;
using System.Windows.Forms;

namespace HoManXM
{
    class WeatherHelper
    {
        public static string[] Weather(string city)
        {
            //---返回23长度的字符串
            WeatherWebService webc = null;
            string[] s = new string[23];
            try
            {
                webc = new WeatherWebService();
                s = webc.getWeatherbyCityName(city.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return s;

        }
    }
}

  //for (int i = 0; i< 23; i++)
  //          {
  //              if (i == 1 || i == 5 || i == 6 || i == 7)
  //              {
  //                  textBox2.Text += s[i] + "\r\n";
  //              }

  //          }