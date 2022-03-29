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

namespace quanlytrasua
{
    public partial class fadmin : Form
    {
        private Account LoginAccount;
        public fadmin(Account acc)
        {
            //load dữ liệu từ các bảng tài khoản, đồ uống, loại đò uống
            InitializeComponent();
            this.LoginAccount = acc;
            loadAccount();
            loadlistfood();
            loadlistcategory();
        }
    public Account LoginAccount1
    {
        get { return LoginAccount; }
        set { LoginAccount = value; }
    }

    private void fadmin_Load(object sender, EventArgs e)
        {
            //dgvfood.Rows.Clear();
        }
        //button load dữ liệu từ bảng tài khoản
        private void btnXem_Click(object sender, EventArgs e)
        {
            loadAccount();    
        }
        //hàm load dữ liệu từ bảng tài khoản
        void loadAccount()
        {
            dgvtk.DataSource = AccountDAO.Instance.Getlistaccount();
            AddAccountBiding();
        }
        //hàm binding tài khoản
        void AddAccountBiding()
        {
            txttendangnhap.DataBindings.Clear();
            txttendangnhap.DataBindings.Add(new Binding("Text", dgvtk.DataSource, "userName",true,DataSourceUpdateMode.Never));
            txttenhienthi.DataBindings.Clear();
            txttenhienthi.DataBindings.Add(new Binding("Text", dgvtk.DataSource, "displayName", true, DataSourceUpdateMode.Never));
            txtmatkhau.DataBindings.Clear();
            txtmatkhau.DataBindings.Add(new Binding("Text", dgvtk.DataSource, "passWord",true,DataSourceUpdateMode.Never));
            txtloaitk.DataBindings.Clear();
            txtloaitk.DataBindings.Add(new Binding("Text", dgvtk.DataSource, "type",true,DataSourceUpdateMode.Never));

        }
        //button xóa tài khoản
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tentk = txttendangnhap.Text;
            string tenhienthi = txttenhienthi.Text;
            string matkhau = txtmatkhau.Text;
            int loaitk = int.Parse(txtloaitk.Text);
            if (AccountDAO.Instance.DeleteTK(tentk))
            {
                MessageBox.Show("Xóa tài khoản thành công");
                loadAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa");
            }
           
        }
        //button sữa tài khoản
        private void btnSua_Click(object sender, EventArgs e)
        {
            string tentk = txttendangnhap.Text;
            string tenhienthi = txttenhienthi.Text;
            string matkhau = txtmatkhau.Text;
            int loaitk = int.Parse(txtloaitk.Text);
            if (AccountDAO.Instance.updateTK(tentk,tenhienthi, matkhau,loaitk))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
                loadAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật vào");
            }
        }
        //khai báo loại tài khoản
        public int loaitk { get; set; }
        //button thêm tài khoản
        
        //hàm load danh sách đồ uống
        void loadlistfood()
        {
            dgvfood.DataSource = FoodDAO.Instance.GetListFood();
            Loadcategoryintocombobox(cbcategory);
             AddFoodBiding();
        }
        //hàm load danh sách loại đồ uống
        void loadlistcategory()
        {
            dgvcategory.DataSource = CategoryDAO.Instance.GetListCategory();
            AddCategoryBiding();
        }
        //hàm biding đồ uống
        void AddFoodBiding()
        {
            txtid.DataBindings.Clear();
            txtid.DataBindings.Add(new Binding("Text", dgvfood.DataSource, "iD", true, DataSourceUpdateMode.Never));
            txttendouong.DataBindings.Clear();
            txttendouong.DataBindings.Add(new Binding("Text", dgvfood.DataSource, "name", true, DataSourceUpdateMode.Never));
            //txtloaidouong.DataBindings.Clear();
            //txtloaidouong.DataBindings.Add(new Binding("Text", dgvtk.DataSource, "iDCategory", true, DataSourceUpdateMode.Never));
             nmgia.DataBindings.Clear();
             nmgia.DataBindings.Add(new Binding("Value", dgvfood.DataSource, "price",true,DataSourceUpdateMode.Never));

        }
        //hàm biding loại đồ uống
        void AddCategoryBiding()
        {
            txtidcategory.DataBindings.Clear();
            txtidcategory.DataBindings.Add(new Binding("Text", dgvcategory.DataSource, "iD", true, DataSourceUpdateMode.Never));
            txtnamecategory.DataBindings.Clear();
            txtnamecategory.DataBindings.Add(new Binding("Text", dgvcategory.DataSource, "name", true, DataSourceUpdateMode.Never));

        }
        //button load danh sách đồ uống
        private void btnxemmon_Click(object sender, EventArgs e)
        {
            loadlistfood();
        }
        //hàm load loại đồ uống trong combobox
        void Loadcategoryintocombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        //hàm sự kiện textchanged bắt loại đồ uống theo mã đồ uống
        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvfood.SelectedCells[0].OwningRow.Cells["IDCategory"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                cbcategory.SelectedIndex = category.ID - 1;
            }
            catch { }
        }
        //button thêm đồ uống
        private void btnthemmon_Click(object sender, EventArgs e)
        {
            string name = txttendouong.Text;
            int categoryID = (cbcategory.SelectedItem as Category).ID;
            float price = (float)nmgia.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                loadlistfood();
                MessageBox.Show("Thêm  đồ uống thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm đồ uống");
            }
        }
        //button xóa đồ uống
        private void btnxoamon_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa đồ uống thành công");
                loadlistfood();

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa đồ uống");
            }
        }
        //button sữa đồ uống
        private void btnsuamon_Click(object sender, EventArgs e)
        {
            string name = txttendouong.Text;
            int categoryID = (cbcategory.SelectedItem as Category).ID;
            float price = (float)nmgia.Value;
            int id = Convert.ToInt32(txtid.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {

                MessageBox.Show("Sửa món thành công");
                loadlistfood();
                
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa đồ uống");
            }
        }
        //button tìm đồ uống theo tên
        private void btntim_Click(object sender, EventArgs e)
        {
            string name = txtsearch.Text;
            dgvfood.DataSource = null;
            dgvfood.DataSource = FoodDAO.Instance.SearchFoodByName(name);
            Loadcategoryintocombobox(cbcategory);
            AddFoodBiding();


        }
        //button show danh sách loại đồ uống
        private void btnshow_Click(object sender, EventArgs e)
        {
            loadlistcategory();
        }
        //button thêm loại đồ uống
        private void btnadd_Click(object sender, EventArgs e)
        {
            string name = txtnamecategory.Text;

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                loadlistcategory();
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm loại đồ uống");
            }
        }
        //button cập nhật loại đồ uống
        private void btnup_Click(object sender, EventArgs e)
        {
            string name = txtnamecategory.Text;
            int id = Convert.ToInt32(txtidcategory.Text);

            if (CategoryDAO.Instance.UpdateCategory(name,id))
            {

                MessageBox.Show("Cập nhật  thành công");
                loadlistcategory();

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa loại đồ uống");
            }
        }
        //button xóa loại đồ uóng
        private void btndel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtidcategory.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa  thành công");
                loadlistcategory();

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa loại đồ uống");
            }
        }

        private void txttendangnhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txttenhienthi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tentk = txttendangnhap.Text;
            string tenhienthi = txttenhienthi.Text;
            string matkhau = txtmatkhau.Text;
            int loaitk = int.Parse(txtloaitk.Text);
            if (AccountDAO.Instance.InsertTK(tentk,tenhienthi,matkhau,loaitk))
            {
                loadAccount();
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi Thêm");
            }
        }
    }
  }
        
 


