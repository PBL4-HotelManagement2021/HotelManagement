﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using HotelManagement.ViewModel;
using Newtonsoft.Json;
using System.Windows.Forms;
using HotelManagement.View;
using HotelManagement.BLL.Implement;
using HotelManagement.BBL.Implement;
using PBL3REAL.Extention;
using PBL3REAL.Model;
using PBL3REAL.ViewModel;

namespace PBL3REAL.View
{
    public partial class UserControl_Receptionist_Admin : UserControl
    {
        private RoomBLL roomBLL;
        private RoomTypeBLL roomTypeBLL;
        public UserControl_Receptionist_Admin()
        {

            InitializeComponent();
            roomBLL = new RoomBLL();
            roomTypeBLL = new RoomTypeBLL();
            addCbRoom1();
            setCbbRoomType();
            setCbbRoom2();
        }
        private void showRoom(int idRoomType , string name)
        {
            dataGridView1.DataSource = null;
            
            dataGridView1.DataSource = roomBLL.getAll(1, 10, idRoomType, name);
            dataGridView1.Columns["IdRoom"].Visible = false;
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            int idRoomType = ((CbbItem)cbRoom1.SelectedItem).Value;
            string name = searchRoom.Text;
            showRoom(idRoomType , name);
            /*string json = JsonConvert.SerializeObject(listVM, Formatting.Indented);
            richTextBox1.Text = json;*/

        }
        private void addCbRoom1()
        {
            List<CbbItem> list = roomTypeBLL.addCombobox();
            list.Insert(0, new CbbItem(0,"All RoomType"));
            List<CbbItem> res = list;
            cbRoom1.DataSource = res;
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            Form_Detail_Room f = new Form_Detail_Room(0);
            f.Show();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count != 1)
            {
                MessageBox.Show("Please choose only 1 row  !!!");
            }
            else
            {
                int idRoom = Int32.Parse(r[0].Cells["IdRoom"].Value.ToString());
                Form_Detail_Room f = new Form_Detail_Room(idRoom);
                f.Show();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Please choose rows  !!!");
            }
            else
            {
                List<int> listdel = new List<int>();
                foreach (DataGridViewRow val in r)
                {
                    listdel.Add(Int32.Parse(val.Cells["IdRoom"].Value.ToString()));
                }
                try
                {
                    roomBLL.deleteRoom(listdel);
                    showRoom(0,"");
                }
                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }

            }
        }

        private void showRoomType()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = roomTypeBLL.getAll();
            dataGridView2.Columns["IdRoomtype"].Visible = false;
            /*dataGridView1.Columns["ListImg"].Visible = false;*/
        }
        private void btnroty_show_Click(object sender, EventArgs e)
        {
            showRoomType();
        }

        private void btnroty_add_Click(object sender, EventArgs e)
        {
            Form f = new Form_Detail_Room_Categorycs(0);
            f.Show();
        }

        private void btnroty_edit_Click(object sender, EventArgs e)
        {
            
                DataGridViewSelectedRowCollection r = dataGridView2.SelectedRows;
                if (r.Count != 1)
                {
                    MessageBox.Show("Please choose only 1 row  !!!");
                }
                else
                {
                    int idRoomType = Int32.Parse(r[0].Cells["IdRoom"].Value.ToString());
                    Form f = new Form_Detail_Room_Categorycs(idRoomType);
                    f.Show();
               
            }
        }

        private void btnroty_del_Click(object sender, EventArgs e)
        {
            int idRoomType = Convert.ToInt32(dataGridView2.CurrentRow.Cells["0"].Value);
            if(dataGridView2.SelectedRows.Count > 0)
            {
                int count = dataGridView2.SelectedRows.Count;
                for(int i = 0; i < count; i++)
                {
                    roomTypeBLL.deleteRoomType(Convert.ToInt32(dataGridView2.SelectedRows[i].Cells[0].Value.ToString()));
                }
            }
            else
            {
                MessageBox.Show("Không có phong nao`");
            }
            showRoomType();
        }

        public void setCbbRoomType()
        {
            cbbRoomtype.Items.AddRange(new object[]
            {
                "Tên loại phòng", "Giá tiền", "Sức chứa"
            });
            cbbRoomtype.SelectedIndex = 0;
        }
        private void cbbRoomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<RoomTypeVM> listrtvm = new List<RoomTypeVM>();
            foreach(RoomTypeVM i in roomTypeBLL.getAll())
            {
                listrtvm.Add(i);
            }
            if(cbbRoomtype.Text== "Tên loại phòng")
            {
                roomTypeBLL.sort(listrtvm, RoomTypeVM.compareName);
            }
            if(cbbRoomtype.Text == "Giá tiền")
            {
                roomTypeBLL.sort(listrtvm, RoomTypeVM.comparePrice);
            }
            if(cbbRoomtype.Text=="Sức chứa")
            {
                roomTypeBLL.sort(listrtvm, RoomTypeVM.compareCapacity);
            }
            dataGridView2.DataSource = listrtvm;
        }
        public void setCbbRoom2()
        {
            cbRoom2.Items.AddRange(new object[]
            {
                "Tên phòng", "Giá tiền", "Loại phòng"
            });
            cbRoom2.SelectedIndex = 0;
        }
        private void cbRoom2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idRoomType = ((CbbItem)cbRoom1.SelectedItem).Value;
            string name = searchRoom.Text;
            List<RoomVM> listr = new List<RoomVM>();
            foreach (RoomVM i in roomBLL.getAll(1, 10, idRoomType, name))
            {
                listr.Add(i);
            }
            if(cbRoom2.Text== "Tên phòng")
            {
                roomBLL.sort(listr, RoomVM.compareName);
            }
            if (cbRoom2.Text == "Giá tiền")
            {
                roomBLL.sort(listr, RoomVM.comparePrice);
            }
            if (cbRoom2.Text == "Loại phòng")
            {
                roomBLL.sort(listr, RoomVM.compareRoTyName);
            }
            dataGridView1.DataSource = listr;

        }
    }
    }
