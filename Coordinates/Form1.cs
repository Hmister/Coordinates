using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coordinates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string checkedRBName = string.Empty;
            //取得选中单选按钮的名称  
            if (radioButton1.Checked)
            {
                checkedRBName = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                checkedRBName = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                checkedRBName = radioButton3.Text;
            }
            string v = textBox8.Text;
            if (!string.IsNullOrEmpty(v))
            {
                var jw = v.Split(',');
                double lat = double.Parse(jw[1]);
                double lng = double.Parse(jw[0]);
                switch (checkedRBName)
                {
                    case "WGS84":
                        //GPS转高德
                        var info = GPSChange.WGS84_to_GCJ02(lat, lng);
                        var _info = GPSChange.WGS84_to_BD09(lat, lng);

                        textBox5.Text = v;
                        textBox6.Text = info.GetLng().ToString() + "," + info.GetLat().ToString();
                        textBox1.Text = _info.GetLng().ToString() + "," + _info.GetLat().ToString();
                        break;
                    case "GCJ02":
                        var data = GPSChange.GCJ02_to_WGS84(lat, lng);
                        var _data = GPSChange.GCJ02_to_BD09(lat, lng);

                        textBox5.Text = data.GetLng().ToString() + "," + data.GetLat().ToString();
                        textBox6.Text = v;
                        textBox1.Text = _data.GetLng().ToString() + "," + _data.GetLat().ToString();
                        break;
                    case "BD09":
                        var BD09 = GPSChange.BD09_to_WGS84(lat, lng);
                        var _BD09 = GPSChange.BD09_to_GCJ02(lat, lng);

                        textBox5.Text = BD09.GetLng().ToString() + "," + BD09.GetLat().ToString();
                        textBox6.Text = _BD09.GetLng().ToString() + "," + _BD09.GetLat().ToString();
                        textBox1.Text = v;
                        break;
                    default:

                        break;
                }
            }

            Console.WriteLine(checkedRBName);
        }
    }
}
