using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlytrasua.DAO;
using quanlytrasua.DTO;
using System.Globalization;

namespace quanlytrasua
{
    public partial class fmenu : Form
    {
        private Account LoginAccount;

        public fmenu(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            loadlistview();
            loadcombobox();
            loadbuttondouong();


        }
        public Account LoginAccount1
        {
            get { return LoginAccount ; }
            set { LoginAccount = value; }
        }



        //hàm load ra các button trong flowlayerpenal có trong csdl
        void loadbuttondouong()
        {
            flpdouong.Controls.Clear();
            List<Food> lsfood = FoodDAO.Instance.GetListFood();
            foreach (Food item in lsfood)
            {
                Button button = new Button() { Width = 50, Height = 50 };             
                button.Text = item.Name;
                button.Tag = item.Price;
                button.Name = Convert.ToString(item.iD);
                button.Click += button_click;
                flpdouong.Controls.Add(button);

                button.BackColor = Color.Aqua;

               
            }
            nmsl.Value = 1;
        }

        //hàm load ra các button trong flowlayerpenal có trong csdl nhưng dựa vào mã loại đồ uống
        void loadbuttondouong1(int id)
        {

            flpdouong.Controls.Clear();

            List<Food> lsfood = FoodDAO.Instance.GetFoodByCategoryID(id);
            foreach (Food item in lsfood)
            {

                Button button = new Button() { Width = 50, Height = 50 };
                button.Text = item.Name;
                button.Tag = item.Price;
                button.Name = Convert.ToString(item.iD);               
                button.Click += button_click;          
                button.BackColor = Color.Aqua;                           
                flpdouong.Controls.Add(button);
                
               

            }
            nmsl.Value = 1;
        }





        //id
        //sl
        //action









        // sự kiện nhấn button
        private void button_click(object sender, EventArgs e)
        {          
            //nếu numberrichupdown bằng 1 thì thêm vào listview và cộng dồn tiếp
            if (nmsl.Value == 1)
            {
                int sl = 1;
                string ten = (sender as Button).Text;               
                for (int i = 0; i < lsvdouong.Items.Count; i++)
                {
                    if (lsvdouong.Items[i].SubItems[0].ToString().Contains(ten))
                    {

                        int sl1 = Convert.ToInt32(lsvdouong.Items[i].SubItems[2].Text);
                        lsvdouong.Items[i].SubItems[2].Text = (sl + sl1).ToString();




                        tongtien();



                        return;
                    }

                }
                float price = (float)(sender as Button).Tag;
                string id = (sender as Button).Name.ToString();
                ListViewItem item = new ListViewItem(ten);
                item.SubItems.Add(price.ToString());
                item.SubItems.Add(sl.ToString());
                item.SubItems.Add(id.ToString());
                lsvdouong.Items.Add(item);
            }
            //nếu numberrichupdown khác 1 thì thay đổi giá trị trong  listview 
            else
            {
              
                int sl = int.Parse(nmsl.Value.ToString());
                string ten = (sender as Button).Text;
                for (int i = 0; i < lsvdouong.Items.Count; i++)
                {
                    if (lsvdouong.Items[i].SubItems[0].ToString().Contains(ten))
                    {

                        int sl1 = Convert.ToInt32(lsvdouong.Items[i].SubItems[2].Text);
                        lsvdouong.Items[i].SubItems[2].Text = (sl).ToString();



                      

                        tongtien();
                        return;
                    }

                }
                float price = (float)(sender as Button).Tag;
                string id = (sender as Button).Name.ToString();
                ListViewItem item = new ListViewItem(ten);
                item.SubItems.Add(price.ToString());
                item.SubItems.Add(sl.ToString());
                item.SubItems.Add(id.ToString());
                lsvdouong.Items.Add(item);
              
            }
       //     loadbuttondouong();
            btnthanhtoan.Enabled = true;          
            nmsl.Value = 1;
            tongtien();

        }

        void tongtien()
        {
            int a = 0;
            for (int i = 0; i < lsvdouong.Items.Count; i++)
            {
                a += (int.Parse((lsvdouong.Items[i].SubItems[1].Text))) * int.Parse((lsvdouong.Items[i].SubItems[2].Text));
            }
            txttongtien.Text = a.ToString();
            if (a == 0)
            {
                btnthanhtoan.Enabled = false;
            }
        }
        //hàm load listview
        void loadlistview()
        {

            lsvdouong.View = View.Details;
            lsvdouong.GridLines = true;
            lsvdouong.FullRowSelect = true;
            lsvdouong.Columns.Add("Tên đồ uống", 150);
            lsvdouong.Columns.Add("Gía", 150);
            lsvdouong.Columns.Add("Số lượng", 100);
            lsvdouong.Columns.Add("Mã đồ uống", 50);



        }
        //hàm load combobox loại ddoood uống
        void loadcombobox()
        {
            cbloaidouong.DataSource = CategoryDAO.Instance.GetListCategory();
            cbloaidouong.DisplayMember = "name";
    
        }
       
        //button làm mới
        private void btnfres_Click(object sender, EventArgs e)
        {
            loadbuttondouong();
        }

        //sự kiện thay đổi loại đồ uống trong combobox sẽ load ra các  button theo loại đồ uống đó
        private void cbloaidouong_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            nmsl.Value = 1;
            int id = 0;

            ComboBox cb = sender as ComboBox;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            loadbuttondouong1(id);
        }
        //button làm mới
        private void btnfres_Click_1(object sender, EventArgs e)
        {
            loadbuttondouong();        
        }
        //button thanh toán(bao gồn cả việc thêm dữ liệu vào hóa đơn và chi tiết hóa đơn)
        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            float tong = float.Parse(txttongtien.Text);
            if (HoadonDAO.Instance.InsertBill(tong))
            {
                for (int i = 0; i < lsvdouong.Items.Count; i++)
                {
                    int iddouong = int.Parse(lsvdouong.Items[i].SubItems[3].Text);
                    int soluong = int.Parse(lsvdouong.Items[i].SubItems[2].Text);
                    ChitiethoadonDAO.Instance.InsertBillInfo(HoadonDAO.Instance.GetMaxIDBill(), iddouong, soluong);
                }              
            }
            lsvdouong.Items.Clear();
            txttongtien.Clear();
            loadbuttondouong();
            btnthanhtoan.Enabled = false;
            fThanhtoan ftt = new fThanhtoan(tong);
            ftt.Show();



         

        }

  
        //xóa các dữ liệu trong listview
        private void btndel_Click(object sender, EventArgs e)
       {
            for(int i =0;i<lsvdouong.Items.Count;i++)
            {
                if (lsvdouong.Items[i].Selected)
                {
                    lsvdouong.Items.RemoveAt(i);
                }
            }          
            tongtien();
            nmsl.Value = 1;
        }

     

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoginAccount.Type == 1)
            {
                fadmin f = new fadmin(LoginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập");
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongke f = new fThongke(LoginAccount);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void fmenu_Load(object sender, EventArgs e)
        {

        }

        private void thôngTinTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fthongtintaikhoan f = new fthongtintaikhoan(LoginAccount);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flogin f = new flogin();
            {
                //this.Close();
                this.Hide();
                f.ShowDialog();
                
            }
            

        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            string thu;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    thu = "Chủ nhật";
                    break;
                case DayOfWeek.Monday:
                    thu = "Thứ hai";
                    break;
                case DayOfWeek.Tuesday:
                    thu = "Thứ ba";
                    break;
                case DayOfWeek.Wednesday:
                    thu = "Thứ tư";
                    break;
                case DayOfWeek.Thursday:
                    thu = "Thứ năm";
                    break;
                case DayOfWeek.Friday:
                    thu = "Thứ sáu";
                    break;
                case DayOfWeek.Saturday:
                    thu = "Thứ bảy";
                    break;
                default:
                    thu = "";
                    break;
            }
            this.TG.Text = string.Format("Bây giờ là {1} - {2}, ngày {0}",DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss:tt"),thu);
        }

        private void thoátToolStripMenuItem_Click(object sender, FormClosingEventArgs e)
        {

        }

        // thoát khỏi ct
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                Application.ExitThread();
               
            }
            
            
        }
        // thoát khỏi ct
        private void fmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
            else Application.ExitThread();

            
                      
        }

        private void nmsl_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvdouong.Items.Count; i++)
            {
                if (lsvdouong.Items[i].Selected)
                {

                    lsvdouong.Items[i].SubItems[2].Text = nmsl.Value.ToString();

                }                          
            }
            tongtien();
        }
        
        private void lsvdouong_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
  
        }

        private void lsvdouong_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           
                var it = e.Item;                
                nmsl.Text = it.SubItems[2].Text;
             
                
                
        }
       

      
    }

}

