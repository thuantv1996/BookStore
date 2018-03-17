using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.ViewModel
{
    class BooksViewModel
    {
        #region DataContext

        QuanLySachEntities context = new QuanLySachEntities();
        public ObservableCollection<SACH> Sach { get; set; }
        public ObservableCollection<THELOAI> TheLoai { get; set; }
        public ObservableCollection<NHAXUATBAN> NhaXuatBan { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand{ get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public MessageBoxResult DialogResult { get; set; }
        private bool _IsEnable;
        public bool IsEnable { get { return _IsEnable; } set { _IsEnable = value; }
            }


        private ObservableCollection<SACH> getSach()
        {
            return new ObservableCollection<SACH>(context.SACH);
        }
        private ObservableCollection<THELOAI> getTheLoai()
        {
            return new ObservableCollection<THELOAI>(context.THELOAI);
        }
        private ObservableCollection<NHAXUATBAN> getNhaXuatBan()
        {
            return new ObservableCollection<NHAXUATBAN>(context.NHAXUATBAN);
        }
        public void Init()
        {
            
        }
        public BooksViewModel()
        {
            Sach = getSach();
            TheLoai = getTheLoai();
            NhaXuatBan = getNhaXuatBan();
            IsEnable = true;
            DeleteCommand = new RelayCommand<object>((p) => p != null, (p) =>
                 {
                     SACH s = p as SACH;
                     if (MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + s.TenSach + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                     {
                         return;
                     }
                     else
                     {
                         context.SACH.Attach(s);
                         context.SACH.Remove(s);
                         context.SaveChanges();
                         Sach.Remove(s);
                     }
                 });
            SaveCommand = new RelayCommand<UIElementCollection>((p) => p != null, (p) =>
                 {
                // lấy data
                string str_masach = (p[0] as TextBox).Text;
                     string tensach = (p[1] as TextBox).Text;
                     string tacgia = (p[2] as TextBox).Text;
                     THELOAI theloai = (p[3] as ComboBox).SelectedValue as THELOAI;
                     NHAXUATBAN nhaxuatban = (p[4] as ComboBox).SelectedValue as NHAXUATBAN;
                     int i_masach;
                // Kiểm tra dữ liệu
                if (string.IsNullOrEmpty(str_masach))
                     {
                         MessageBox.Show("Mã sách khác rỗng!", "Sách", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return;
                     }
                     if (!Int32.TryParse(str_masach, out i_masach))
                     {
                         MessageBox.Show("Mã sách là một con số!", "Sách", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return;
                     }
                     if (context.SACH.Find(i_masach) != null && p[0].IsEnabled)
                     {
                         MessageBox.Show("Mã sách không được trùng!", "Sách", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return;
                     }
                     if (string.IsNullOrEmpty(tensach))
                     {
                         MessageBox.Show("Tên sách khác rỗng!", "Sách", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return;
                     }
                     if (string.IsNullOrEmpty(tacgia))
                     {
                         MessageBox.Show("Tác giả sách khác rỗng!", "Sách", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return;
                     }
                     if (null == theloai)
                     {
                         MessageBox.Show("Chọn thể loại!", "Sách", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return;
                     }
                     if (null == nhaxuatban)
                     {
                         MessageBox.Show("Chọn nhà xuất bản!", "Sách", MessageBoxButton.OK, MessageBoxImage.Warning);
                         return;
                     }
                // Tạo đối tượng Sách
                SACH sach = new SACH { MaSach = i_masach, TenSach = tensach, TacGia = tacgia, MaNhaXuatBan = nhaxuatban.MaNhaXuatBan, MaTheLoai = theloai.MaTheLoai, NHAXUATBAN = nhaxuatban, THELOAI = theloai };
                // Update or Add new
                if (p[0].IsEnabled)// add new book
                {
                         if (MessageBox.Show("Bạn có chắc muốn thêm sách " + sach.TenSach + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                         {
                             context.SACH.Add(sach);
                             context.SaveChanges();
                             Sach.Add(sach);
                             MessageBox.Show("Thêm mới sách thành công!");
                             p[0].IsEnabled = false;
                             p[1].IsEnabled = false;
                             p[2].IsEnabled = false;
                             p[3].IsEnabled = false;
                             p[4].IsEnabled = false;
                             (p[0] as TextBox).Clear();
                             (p[1] as TextBox).Clear();
                             (p[2] as TextBox).Clear();
                             (p[0] as TextBox).Text = "";
                             (p[0] as TextBox).Text = "";
                             IsEnable = true;
                         }

                     }
                     else // update
                {
                         if (MessageBox.Show("Bạn có chắc muốn sửa sách " + sach.TenSach + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                         {
                             SACH _sach = context.SACH.Find(sach.MaSach);
                             Sach.Remove(_sach);
                             _sach = sach;
                             context.SaveChanges();
                             Sach.Add(sach);
                             MessageBox.Show("Sửa thông tin sách thành công!");
                             p[0].IsEnabled = false;
                             p[1].IsEnabled = false;
                             p[2].IsEnabled = false;
                             p[3].IsEnabled = false;
                             p[4].IsEnabled = false;
                             (p[0] as TextBox).Clear();
                             (p[1] as TextBox).Clear();
                             (p[2] as TextBox).Clear();
                             (p[0] as TextBox).Text = "";
                             (p[0] as TextBox).Text = "";
                             IsEnable = true;
                         }
                     }

                 });
            UpdateCommand = new RelayCommand<UIElementCollection>((p) => p != null, (p) =>
            {
                if((p[0] as TextBox).Text=="")
                {
                    MessageBox.Show("Chưa chọn sách!");
                    return;
                }
                (p[1] as TextBox).IsEnabled = true;
                (p[2] as TextBox).IsEnabled = true;
                (p[3] as ComboBox).IsEnabled = true;
                (p[4] as ComboBox).IsEnabled = true;
            });
            AddCommand = new RelayCommand<UIElementCollection>((p) => p != null, (p) =>
            {
                IsEnable = false;
                UIElementCollection c1 = (p[1] as Grid).Children;
                UIElementCollection c2 = (p[2] as Grid).Children;
                if((c2[0] as DataGrid).IsEnabled)
                {
                    (c2[0] as DataGrid).IsEnabled = false;
                    (c1[0] as TextBox).IsEnabled = true;
                    (c1[1] as TextBox).IsEnabled = true;
                    (c1[2] as TextBox).IsEnabled = true;
                    (c1[3] as ComboBox).IsEnabled = true;
                    (c1[4] as ComboBox).IsEnabled = true;

                    (c1[0] as TextBox).Clear();
                    (c1[1] as TextBox).Clear();
                    (c1[2] as TextBox).Clear();
                    (c1[3] as ComboBox).Text = "";
                    (c1[4] as ComboBox).Text = "";
                }
                else
                {
                    (c2[0] as DataGrid).IsEnabled = true;
                    (c1[0] as TextBox).IsEnabled = false;
                    (c1[1] as TextBox).IsEnabled = false;
                    (c1[2] as TextBox).IsEnabled = false;
                    (c1[3] as ComboBox).IsEnabled = false;
                    (c1[4] as ComboBox).IsEnabled = false;

                    (c1[0] as TextBox).Clear();
                    (c1[1] as TextBox).Clear();
                    (c1[2] as TextBox).Clear();
                    (c1[3] as ComboBox).Text = "";
                    (c1[4] as ComboBox).Text = "";
                }
                
            });
                
        }
        

        #endregion
    }
}
