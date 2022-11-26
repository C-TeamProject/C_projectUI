using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace C_TemaProgramming
{
    public partial class Form1 : Form
    {
        // 콤보박스 선택
        int year;
        int month;
        int day;
        
        DateTime today = DateTime.Today; // 현재날짜

        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
            // column을 추가합니다.
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("제목", typeof(string));
            table.Columns.Add("구분", typeof(string));
            table.Columns.Add("생성일", typeof(string));
            table.Columns.Add("수정일", typeof(string));

            // 각각의 행에 내용을 입력합니다.
            table.Rows.Add("ID 1", "제목 1번", "사용중", "2019/03/11", "2019/03/18");
            table.Rows.Add("ID 2", "제목 2번", "미사용", "2019/03/12", "2019/03/18");
            table.Rows.Add("ID 3", "제목 3번", "미사용", "2019/03/13", "2019/03/18");
            table.Rows.Add("ID 4", "제목 4번", "사용중", "2019/03/14", "2019/03/18");

            // 값들이 입력된 테이블을 DataGridView에 입력합니다.
            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void Date()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string yeart = comboBox1.SelectedItem.ToString();
            yeart = yeart.Replace("년", "");
            //MessageBox.Show(yeart);
            year = int.Parse(yeart);    // 년도 값
            
            comboBox2.Items.Clear();    // 초기화
            for (int i = 1; i <= 12; i++)
            {
                comboBox2.Items.Add(i.ToString() +"월");
            }
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string montht = comboBox2.SelectedItem.ToString();
            montht = montht.Replace("월", "");
            //MessageBox.Show(montht);
            month = int.Parse(montht);  // 월 선택 값

            comboBox3.Items.Clear();    // 초기화

            int count;  // 일 개수

            // 31일
            if (month == 1 & month == 3 & month == 5 & month == 7 & month == 8 & month == 10 & month == 12)
            {
                count = 31;
            }
            else if(month == 2)
            {
                // 윤년
                if(year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                {
                    count = 29;
                }

                else
                {
                    count = 28;
                }
            }
            // 30일
            else
            {
                count = 30;
            }

            for (int i = 1; i <= count; i++)
            {   
                comboBox3.Items.Add(i.ToString() + "일");
            }

            

            //comboBox3.SelectedIndex = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dayt = comboBox3.SelectedItem.ToString();
            dayt = dayt.Replace("일", "");
            day = int.Parse(dayt);  // 일 선택 값
            MessageBox.Show(day.ToString());
        }
    }
}
