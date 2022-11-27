using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_TemaProgramming
{
    public partial class Form2 : Form
    {
        DateTime today = DateTime.Today; // 현재날짜
        DataTable table = new DataTable();
        
        public Form2()
        {
            InitializeComponent();
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string [] s = new string[100];
            if (e.KeyCode == Keys.Enter) // 엔터키 이벤트
            {
                string search = textBox1.Text;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == search)
                    {
                        // 찾으면 여러 여러 내역중 초기화 후 찾은 데이터만 보여줌
                        //dataGridView2.Columns.Clear(); // 데이터 클리어
                        MessageBox.Show("찾음");

                    }
                    else if (i == dataGridView2.Rows.Count)
                    {
                        MessageBox.Show("못찾음");
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // column을 추가합니다.
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("제목", typeof(string));
            table.Columns.Add("구분", typeof(string));
            table.Columns.Add("생성일", typeof(string));
            table.Columns.Add("수정일", typeof(string));

            // 각각의 행에 내용을 입력합니다.
            table.Rows.Add(today, "아무개", "사용중", "2019/03/11", "2019/03/18");
            table.Rows.Add("ID 2", "아무개1", "미사용", "2019/03/12", "2019/03/18");
            table.Rows.Add("ID 3", "아무개2", "미사용", "2019/03/13", "2019/03/18");
            table.Rows.Add("ID 4", "아무개3", "사용중", "2019/03/14", "2019/03/18");

            // 값들이 입력된 테이블을 DataGridView에 입력합니다.
            dataGridView2.DataSource = table;
        }
    }
}
