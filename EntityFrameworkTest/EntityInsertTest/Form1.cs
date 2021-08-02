using EntityInsertTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityInsertTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // 주문 1 : 삼겹살 2인분 + 목살 2인분 + 콜라 1캔 
        private void btnOrderCommit1_Click(object sender, EventArgs e)
        {
            using (EATSEntities db = new EATSEntities())
            {
                // 가장 최근 오더 번호 
                var lastOrder = db.Ordertbl.OrderByDescending(u => u.OrderCode).Take(1).ToList()[0].OrderCode; // 20210802005 
                
                // 최신 오더 뒤 3자리 추출하고 정수로 변환하여 + 1
                int num = int.Parse(lastOrder.Substring(8)) + 1; //  "20210802003" -> 4
                
                // 오더 번호 생성
                var orderCode = DateTime.Today.ToString("yyyyMMdd") + num.ToString("D3"); 


                // Order 1 line (OrderCode, OrderTime, CustomerNum, TblNum, OrderPrice, OrderRemark)
                // 키오스크로부터 인원수, 테이블 번호, 결제 금액을 받아와서 입력 
                var order = new Ordertbl()
                {
                    OrderCode = orderCode,
                    OrderTime = DateTime.Now,
                    CustomerNum = "4",
                    TblNum = 4,
                    OrderPrice = 20000,
                    OrderRemark = null
                };

                db.Ordertbl.Add(order);

                // OrderDetail 3 line (OrderCode, MenuCode, Amount)

                // 키오스크로부터 메뉴와 수량 받아와서 처리 (임시 입력) 
                int menuCount = 3; // 3종류
                string[] menu = { "M001", "M002", "B001" }; // 메뉴 종류 
                int[] amount = { 2, 2, 1 }; // 각 메뉴 수량 

                for (int i = 0; i < menuCount; i++)
                {
                    var orderDetail = new OrderDetailtbl()
                    {
                        OrderCode = orderCode,
                        MenuCode = menu[i],
                        Amount = amount[i]
                    };
                    db.OrderDetailtbl.Add(orderDetail);
                }

                db.SaveChanges();
            }
        }

        // 
        private void btnOrderCommit2_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderCommit3_Click(object sender, EventArgs e)
        {

        }
    }
}
