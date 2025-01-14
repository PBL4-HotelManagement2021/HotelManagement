﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using HotelManagement.View;
using HotelManagement.BLL.Implement;
using HotelManagement.BBL.Implement;
using HotelManagement.ViewModel;
using PBL3REAL.ViewModel;
using PBL3REAL.BLL;
using PBL3REAL.Extention;
using PBL3REAL.View;
using System.Linq;
using PBL3REAL.BLL.FacadeBLL;

namespace PBL3REAL.View
{
    public partial class Form_Receptionist : Form
    {
        //---------- GLOBAL DECLARATION ----------//
        //----- BLL Variables -----//
        ReceiptionistManageFacade _receiptionistManage;


        //----- Booking Variables -----//
        private int BookingCurrentPage = 1;
        private int totalBookingPages = 0;
        private string bookingSearch = "";
  
        private string bookOrderBy = "None";
        private string bookStatus = "";


        //----- Room Variables -----//
        private int totalRoomPages = 0;
        private string nameSearch = "";
        private int roomActivate = 0;
        private int RoomCurrentPage = 1;

        //----- RoomType Variables -----//
        private int idRoomTypeSearch = 0;
        private string rotySearch ="";
        private string rotyOrderBy = "None";
        private string rotyStatus = "";

        //----- Other Variables -----//
        private readonly int ROWS = 5;
        private CalendarVM searchByDate;
        private List<Button> listButton;
        public Form_Receptionist(int LoggedID, string LoggedRole)
        {
            InitializeComponent();

            /*** Initialize Parameter ***/
            _receiptionistManage = new ReceiptionistManageFacade();
            //-> Booking Parameters
            searchByDate = new CalendarVM();

            //-> Room Parameters
            tb_RoomPageNumber.Text = "";

            //-> Room Type Parameters
            cbb_RoomTypeStatus.SelectedIndex = 0;

            /*** Load Data & Set GUI ***/
            //-> Tab Page Booking
            cbb_BookingSearchFilter.SelectedIndex = 0;
            cbb_BookingSort.SelectedIndex = 0;
            cbb_BookingStatus.SelectedIndex = 0;
            tb_BookingPageNumber.Text = "0/0";

            //-> Tab Page Room
            AddCbbRoomFilter();
            addCbbRoomTypeOrder();
            AddCbbActive();

            //-> Tab Page Room Type
            listButton = new List<Button>()
            {
                ROOM_VIEW,ROOM_ADD,ROOM_UPDATE,ROOM_INACTIVE,ROOM_ACTIVE,
                TYPE_ACTIVE,TYPE_ADD,TYPE_INACTIVE,TYPE_UPDATE,TYPE_VIEW,
                BOOK_ADD,BOOK_DELETE,BOOK_UPDATE,BOOK_EXPORTINVOICE,BOOK_VIEW
            };
            Authorization();
        }

        private void Authorization()
        {
            List<string> listAction = QLUserBLL.stoUser.ListRole.Where(x => x.IsSelected == true).FirstOrDefault().ActionList;
            foreach (var button in listButton)
            {
                string idbutton = button.Name.ToString();
                if (listAction.Contains(idbutton)) button.Enabled = true;
            }
        }
                                            /***** GENERAL *****/
        //-> General Functions

        //-> General Events
        private void btn_Home_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

                                        /***** BOOKING *****/
        //----- Booking Functions -----//
        private void LoadBookingList()
        {
           
            dgv_Booking.DataSource = null;
            dgv_Booking.DataSource = _receiptionistManage.FindBooking(BookingCurrentPage, ROWS,searchByDate, bookingSearch, bookOrderBy,bookStatus);
            dgv_Booking.Columns["Deposit"].Visible = false;
            dgv_Booking.Columns["IdBook"].Visible = false;
            dgv_Booking.Columns["BookNote"].Visible = false;
        }
        public void searchBookData()
        {
            bookingSearch = tb_BookingSearch.Text;
            bookOrderBy = cbb_BookingSort.SelectedItem.ToString();
            bookStatus = cbb_BookingStatus.SelectedItem.ToString();
            searchByDate.type = cbb_BookingSearchFilter.SelectedItem.ToString();
            searchByDate.fromDate = dtp_BookingFrom.Value;
            searchByDate.toDate = dtp_BookingTo.Value;
            BookingCurrentPage = 1;
            totalBookingPages = _receiptionistManage.GetBookingPagination(ROWS, searchByDate, bookingSearch, bookStatus);
            if (totalBookingPages != 0)
            {
                tb_BookingPageNumber.Text = BookingCurrentPage + "/" + totalBookingPages;
                LoadBookingList();
            }
            else
            {
                tb_BookingPageNumber.Text = "0/0";
                dgv_Booking.DataSource = null;
            }
        }
        private int CheckBookingData()
        {
            if (cbb_BookingSearchFilter.SelectedItem == null)
            {
                return 1;
            }
            if (dtp_BookingFrom.Value > dtp_BookingTo.Value)
            {
                return 2;
            }
            return 0;
        }

        //----- Booking Events  -----//
        private void btn_BookingExport_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgv_Booking.SelectedRows;
            if (r.Count == 1)
            {
                if(r[0].Cells["Status"].Value.ToString() != "Processed")
                {
                    Form_Detail_Invoice f = null;
                    var list = _receiptionistManage.FindInvoice(1, 1, r[0].Cells["Code"].Value.ToString(), "", "",null);
                    if(list.Count!=0) f = new Form_Detail_Invoice("",list[0].IdInvoice);
                    else  f = new Form_Detail_Invoice(r[0].Cells["Code"].Value.ToString(),0);
                    f.myDel = searchBookData;
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Can't export booking with status 'Processed'", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn đơn để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một đơn trong một lần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_BookingView_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgv_Booking.SelectedRows;
            if (r.Count == 1)
            {
                Form_Detail_Booking f = new Form_Detail_Booking(int.Parse(r[0].Cells["IdBook"].Value.ToString()), false);
                f.myDel = searchBookData;
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn đơn để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một đơn trong một lần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_BookingAdd_Click(object sender, EventArgs e)
        {
            Form_Detail_Booking f = new Form_Detail_Booking(0, true);
            f.myDel = searchBookData;
            this.Hide();
            f.ShowDialog();
            this.Show();
            //Reload Data
        }
        private void btn_BookingEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgv_Booking.SelectedRows;
            if (r.Count == 1)
            {
                if(r[0].Cells["Status"].Value.ToString() == "Processed")
                {
                    Form_Detail_Booking f = new Form_Detail_Booking(int.Parse(r[0].Cells["IdBook"].Value.ToString()), true);
                    f.myDel = searchBookData;
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Only booking with status 'Processed' can update");
                }
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn đơn để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một đơn trong một lần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_BookingDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgv_Booking.SelectedRows;
            if (r.Count == 1)
            {
                if (r[0].Cells["Status"].Value.ToString() == "Processed")
                {
                    try
                    {
                        _receiptionistManage.DelBooking(int.Parse(r[0].Cells["IdBook"].Value.ToString()), r[0].Cells["Status"].Value.ToString());
                        searchBookData();
                    }
                    catch (Exception mes)
                    {
                        MessageBox.Show(mes.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Only booking with status 'Processed' can delete");
                }
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một đơn trong một lần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void picbx_BookingSearch_Click(object sender, EventArgs e)
        {
            //Search 
            switch(CheckBookingData())
            {
                case 1:
                    MessageBox.Show("Bạn chưa chọn loại cần tìm kiếm theo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("Dữ liệu thời gian bạn nhập chưa phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    //Gọi hàm tìm kiếm booking
                    searchBookData();
                    break;
            }
        }
        private void picbx_BookingRefresh_Click(object sender, EventArgs e)
        {
            //searchBookData();
        }
        private void btn_BookingPrevPage_Click(object sender, EventArgs e)
        {
            if (BookingCurrentPage > 1)
            {
                BookingCurrentPage -= 1;
                LoadBookingList();
                tb_BookingPageNumber.Text = BookingCurrentPage+"/"+totalBookingPages;
            }
        }
        private void btn_BookingNextPage_Click(object sender, EventArgs e)
        {
            if (BookingCurrentPage < totalBookingPages) //Thay 10 thanh ham get total booking record 
            {
                BookingCurrentPage += 1;
                LoadBookingList();
                tb_BookingPageNumber.Text = BookingCurrentPage + "/" + totalBookingPages;
            }
        }



                                             /***** BOOKING *****/
        //----- Room Functions -----//
        private void AddCbbRoomFilter()
        {
            List<CbbItem> list = _receiptionistManage.AddCombobox();
            list.Insert(0, new CbbItem(0, "All RoomType"));
            List<CbbItem> res = list;
            cbb_RoomFilter.DataSource = res;
            cbb_RoomFilter.SelectedIndex = 0;
        }
        private void AddCbbActive()
        {
            cbb_RoomActive.Items.Add("All");
            cbb_RoomActive.Items.Add("Activate");
            cbb_RoomActive.Items.Add("Inactivate");
            cbb_RoomActive.SelectedIndex = 0;
        }
        private void LoadRoomList()
        {
            fllaypn_RoomSwitchPage.DataSource = null;
            fllaypn_RoomSwitchPage.DataSource = _receiptionistManage.FindRoom(RoomCurrentPage, ROWS, idRoomTypeSearch, nameSearch, roomActivate);
            fllaypn_RoomSwitchPage.Columns["IdRoom"].Visible = false;
            fllaypn_RoomSwitchPage.Columns["RoomActiveflag"].Visible = false;
            
        }
        public void findidRoom()
        {
            RoomDetailVM roomDetailVM = _receiptionistManage.FindRoomById(1);
        }
        public void ReloadRoomData()
        {
            cbb_RoomFilter.SelectedIndex = 0;
            idRoomTypeSearch = 0;
            nameSearch = tb_RoomSearch.Text="";
            cbb_RoomActive.SelectedIndex = 0;
            searchRoomData();
        }
        public void searchRoomData()
        {
            idRoomTypeSearch = ((CbbItem)cbb_RoomFilter.SelectedItem).Value;
            nameSearch = tb_RoomSearch.Text;
            roomActivate = cbb_RoomActive.SelectedIndex;
            RoomCurrentPage = 1;
            totalRoomPages = _receiptionistManage.GetRoomPagination(ROWS, idRoomTypeSearch, nameSearch,roomActivate);
            LoadRoomList();
            if (totalRoomPages != 0) tb_RoomPageNumber.Text = RoomCurrentPage + "/" + totalRoomPages;
            else tb_RoomPageNumber.Text = "0/0";
        }

        //----- Room Events -----//
        private void picbx_RoomSort_Click(object sender, EventArgs e)
        {
        }
        private void picbx_RoomSearch_Click(object sender, EventArgs e)
        {
            //Search 
            searchRoomData();
        }
        private void btn_RoomView_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = fllaypn_RoomSwitchPage.SelectedRows;
            if (r.Count == 1)
            {
                HotelManagement.View.Form_Detail_Room f = new HotelManagement.View.Form_Detail_Room(int.Parse(r[0].Cells["IdRoom"].Value.ToString()), false);
                this.Hide();
                f.myDel = new HotelManagement.View.Form_Detail_Room.MyDel(ReloadRoomData);
                f.ShowDialog();
                this.Show();
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn phòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một phòng trong một lần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_RoomAdd_Click(object sender, EventArgs e)
        {
            HotelManagement.View.Form_Detail_Room f = new HotelManagement.View.Form_Detail_Room(0, true);
            this.Hide();
            f.myDel = new HotelManagement.View.Form_Detail_Room.MyDel(ReloadRoomData);
            f.ShowDialog();
            this.Show();
        }
        private void btn_RoomEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = fllaypn_RoomSwitchPage.SelectedRows;
            if (r.Count == 1)
            {
                if((bool)r[0].Cells["RoomActiveflag"].Value == true)
                {
                    HotelManagement.View.Form_Detail_Room f = new HotelManagement.View.Form_Detail_Room(int.Parse(r[0].Cells["IdRoom"].Value.ToString()), true);
                    this.Hide();
                    f.myDel = new HotelManagement.View.Form_Detail_Room.MyDel(ReloadRoomData);
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Can't update inactive room!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn phòng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một phòng trong một lần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_RoomDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = fllaypn_RoomSwitchPage.SelectedRows;
            if (r.Count == 1)
            {
                _receiptionistManage.DeleteRoom(int.Parse(r[0].Cells["IdRoom"].Value.ToString()));
                ReloadRoomData();
                //Reload Data
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn phòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một phòng trong một lần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_RoomRestore_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = fllaypn_RoomSwitchPage.SelectedRows;
            if (r.Count == 1)
            {
                _receiptionistManage.RestoreRoom(int.Parse(r[0].Cells["IdRoom"].Value.ToString()));
                ReloadRoomData();
                //Reload Data
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Please choose 1 row to restore!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Only choose 1 row to restore!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_RoomPrevPage_Click(object sender, EventArgs e)
        {
            if (RoomCurrentPage > 1)
            {
                RoomCurrentPage -= 1;
                LoadRoomList();
                tb_RoomPageNumber.Text = RoomCurrentPage + "/" + totalRoomPages;
            }
        }
        private void btn_RoomNextPage_Click(object sender, EventArgs e)
        {
            if (RoomCurrentPage < totalRoomPages)
            {
                RoomCurrentPage += 1;
                LoadRoomList();
                tb_RoomPageNumber.Text = RoomCurrentPage + "/" + totalRoomPages;
            }
        }
        private void picbx_RoomRefresh_Click(object sender, EventArgs e)
        {
            ReloadRoomData();
        }
        private void dgv_Room_SelectionChanged(object sender, EventArgs e)
        { 
        }
                                        /***** BOOKING *****/
        //----- RoomType Functions -----//
        private void LoadRoomTypeList()
        {
            dgv_RoomType.DataSource = null;
            dgv_RoomType.DataSource = _receiptionistManage.FindRoomType(rotySearch,rotyOrderBy,rotyStatus);
            dgv_RoomType.Columns["IdRoomtype"].Visible = false;
            dgv_RoomType.Columns["RoTyActiveflag"].Visible = false;
        }
        private void addCbbRoomTypeOrder()
        {
            cbb_RoomTypeSort.Items.Add("None");
            cbb_RoomTypeSort.Items.Add("Current Price Asc");
            cbb_RoomTypeSort.Items.Add("Current Price Desc");
            cbb_RoomTypeSort.SelectedIndex = 0;
        }

        //----- RoomType Events -----//
        private void btn_RoomTypeView_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgv_RoomType.SelectedRows;
            if (r.Count == 1)
            {
                Form_Detail_Room_Type f = new Form_Detail_Room_Type(int.Parse(r[0].Cells["IdRoomtype"].Value.ToString()), false);
                this.Hide();
                f.myDel = new Form_Detail_Room_Type.MyDel(LoadRoomTypeList);
                f.ShowDialog();
                this.Show();
                //Reload Data
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn loại phòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một loại phòng trong một lần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_RoomTypeAdd_Click(object sender, EventArgs e)
        {
            Form_Detail_Room_Type f = new Form_Detail_Room_Type(0, true);
            this.Hide();
            f.myDel = new Form_Detail_Room_Type.MyDel(LoadRoomTypeList);
            f.ShowDialog();
            this.Show();
            //Reload data
        }
        private void btn_RoomTypeEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgv_RoomType.SelectedRows;
            if (r.Count == 1)
            {
                if((bool)r[0].Cells["RoTyActiveflag"].Value == true)
                {
                    Form_Detail_Room_Type f = new Form_Detail_Room_Type(int.Parse(r[0].Cells["IdRoomType"].Value.ToString()), true);
                    this.Hide();
                    f.myDel = new Form_Detail_Room_Type.MyDel(LoadRoomTypeList);
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Can't update inactive roomtype!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn loại phòng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một loại phòng trong một lần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_RoomTypeDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgv_RoomType.SelectedRows;
            if (r.Count == 1)
            {
                try
                {
                    _receiptionistManage.DeleteRoomType(int.Parse(r[0].Cells["IdRoomtype"].Value.ToString()));
                    AddCbbRoomFilter();
                    LoadRoomTypeList();
                }
                catch(Exception )
                {
                    MessageBox.Show("Error while deleting!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (r.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn loại phòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chọn một loại phòng trong một lần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_RoomTypeRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection r = dgv_RoomType.SelectedRows;
                if (r.Count == 1)
                {
                    try
                    {
                        _receiptionistManage.RestoreRoomType(int.Parse(r[0].Cells["IdRoomtype"].Value.ToString()));
                        AddCbbRoomFilter();
                        LoadRoomTypeList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error while restoring!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (r.Count == 0)
                {
                    MessageBox.Show("Bạn chưa chọn loại phòng để xóa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Chỉ có thể chọn một loại phòng trong một lần xóa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while restoring!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picbx_RoomTypeSearch_Click(object sender, EventArgs e)
        {
            rotySearch = tb_RoomTypeSearch.Text;
            rotyOrderBy = cbb_RoomTypeSort.SelectedItem.ToString();
            rotyStatus = cbb_RoomTypeStatus.SelectedItem.ToString();
            LoadRoomTypeList();
        }
        private void picbx_RoomTypeSort_Click(object sender, EventArgs e)
        {
        }
       
    }
}
