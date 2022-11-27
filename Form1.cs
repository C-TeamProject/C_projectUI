using MySql.Data.MySqlClient; // sql 데이터 연동
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
        // 가져올 DB 연결
        string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "127.0.0.1", "testdb", "root", "cosmu1011");
        // 접속 테스트
        public bool ConnectionTest()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectString))
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //데이터조회
        public void SelectDB()
        {
            string sql = "select * from user";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
            }
        }
        //INSERT처리
        public void InsertDB()
        {
            string sql = "Insert Into user  (id,name) values ('1','홍길동')";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //UPDATE처리
        public void UpdateDB()
        {
            string sql = "Update user Set name ='홍길동2' where id = 1";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //DELETE처리
        public void DeleteDB()
        {
            string sql = "Delete From user where id = '1'";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        // 콤보박스 선택
        int year;
        int month;
        int day;
        
        DateTime today = DateTime.Today; // 현재날짜

        //데이터조회
        public DataSet GetUser()
        {
            string sql = "select * from user";
            DataSet ds = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
            }
            return ds;
        }

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
            table.Rows.Add("ID 1", "아무개", "사용중", "2019/03/11", "2019/03/18");
            table.Rows.Add("ID 2", "아무개1", "미사용", "2019/03/12", "2019/03/18");
            table.Rows.Add("ID 3", "아무개2", "미사용", "2019/03/13", "2019/03/18");
            table.Rows.Add("ID 4", "아무개3", "사용중", "2019/03/14", "2019/03/18");

            // 값들이 입력된 테이블을 DataGridView에 입력합니다.
            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 dbLib = new Form1();
            DataSet ds;
            ds = dbLib.GetUser();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e) // 실적추가 버튼
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 선택한 행 가져오기.
                Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        sb.Append("Row: ");
                        sb.Append(dataGridView1.SelectedRows[i].Index.ToString());
                        sb.Append(Environment.NewLine);
                    }

                    sb.Append("Total: " + selectedRowCount.ToString());
                    MessageBox.Show(sb.ToString(), "Selected Rows");
                }
            }      
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

