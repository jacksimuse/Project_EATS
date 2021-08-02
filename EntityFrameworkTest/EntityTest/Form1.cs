using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EntityInsertTest.Model;

namespace EntityTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DatagridRefresh()
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            DatagridLoad();
        }


        public void DatagridLoad()
        {
            EATSEntities entities = new EATSEntities();

            // 1. 메뉴 리스트 불러와서 바인딩 
            var menus = from p in entities.Menutbl
                        select new
                        {
                            menuCode = p.MenuCode,
                            menuName = p.MenuName,
                            price = p.Price,
                            activation = p.Activation
                        };
            dataGridView1.DataSource = menus.ToList();


            // 2. 주문내역 리스트 불러와서 바인딩 
            var orderList = (from o in entities.OrderDetailtbl
                             select new
                             {
                                 OrderCode = o.OrderCode,
                                 MenuCode = o.MenuCode,
                                 Amount = o.Amount
                             }).ToList();
            dataGridView2.DataSource = orderList;



            // 3. 
            // MQTT로 메시지 전송받음 
            // 주문코드, 테이블 번호 
            // 전달 받은 코드와 테이블번호를 매개변수로 하는 메소드 
            string inputCode = "20210802005";
            // int tableNum = 3;

            using (EATSEntities db = new EATSEntities())
            {
                var orders = (from d in db.OrderDetailtbl
                              join m in db.Menutbl
                              on d.MenuCode equals m.MenuCode
                              // 해당 코드의 주문 중 서빙이 안된 주문만 (추가 주문 가능성) 
                              where (d.OrderCode == inputCode && d.OrderComplete == false)
                              select new
                              {
                                  OrderCode = d.OrderCode,
                                  MenuName = m.MenuName,
                                  Amount = d.Amount
                              }).ToList();

                foreach (var order in orders)
                {
                    dataGridView3.DataSource = orders;
                    dataGridView3.Columns["OrderCode"].HeaderText = "주문코드";
                    dataGridView3.Columns["MenuName"].HeaderText = "메뉴";
                    dataGridView3.Columns["Amount"].HeaderText = "수량";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatagridLoad();
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("서빙하시겠습니까?", "서빙", MessageBoxButtons.YesNo);
            var orderCode = "20210802005";

            if (result == DialogResult.Yes)
            {
                using (EATSEntities db = new EATSEntities())
                {
                    var results = db.OrderDetailtbl.Where(o => o.OrderCode == orderCode).ToList();
                    foreach (var item in results)
                    {
                        if (item != null)
                        {
                            item.OrderComplete = true;
                        }
                    }

                    if (db.SaveChanges() != 0)
                    {
                        MessageBox.Show("서빙 완료");
                        DatagridRefresh();
                        return;
                    }
                    else MessageBox.Show("데이터 입력 실패(주문 없음)");



                }

            }
          
        }
    }
}
