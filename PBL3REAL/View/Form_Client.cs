﻿using PBL3REAL.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PBL3REAL.View
{
    public partial class Form_Client : Form
    {
        /***** GLOBAL DECLARATION *****/
        /*** Global Parameter For Client ***/
        private ClientBLL clientBLL;
        private string search = "";
        private string orderBy = "";
        private readonly int ROWS = 5;
        private int currentPage = 1;
        private int totalPage = 0;


        private List<Button> listButton;
        /***** CONSTRUCTOR *****/
        public Form_Client()
        {
            InitializeComponent();
            clientBLL = new ClientBLL();
            cbb_ClientSort.SelectedIndex = 0;
            cbb_ClientStatus.SelectedIndex = 0;

            listButton = new List<Button>()
            {
                CLIE_ACTIVE,CLIE_ADD,CLIE_INACTIVE,CLIE_UPDATE,CLIE_VIEW
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
        /*** Events ***/
        private void btn_Home_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /***** CLIENT MANAGEMENT *****/
        /*** Functions ***/
        //-> Load Data Functions
        private void LoadData()
        {
            dgv.DataSource = null;
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("name", search);
            properties.Add("status", cbb_ClientStatus.SelectedItem.ToString());
            totalPage = clientBLL.getPagination(ROWS, properties);
            if (totalPage != 0)
            {
                dgv.DataSource = clientBLL.findByProperty(currentPage, ROWS, properties, orderBy);
                dgv.Columns["IdClient"].Visible = false;
                dgv.Columns["CliActiveflag"].Visible = false;              
                tb_ClientPageNumber.Text = currentPage + "/" + totalPage;
            }
            else
            {
                tb_ClientPageNumber.Text = "0/0";
            }
            
        }
        /*** Events ***/
        private void picbx_ClientSearch_Click(object sender, EventArgs e)
        {
            search = tb_ClientSearch.Text;
            orderBy = cbb_ClientSort.SelectedItem.ToString();
            currentPage = 1;
            LoadData();
        }
        private void btn_ClientView_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                //truyền ID_CLient 
                Form_Detail_Client f = new Form_Detail_Client(int.Parse(dgv.SelectedRows[0].Cells["IdClient"].Value.ToString()), false);
                f.myDel = LoadData;
                this.Hide();
                f.ShowDialog();
                this.Show();
            }   
            else
            {
                MessageBox.Show("Please choose only 1 rows to view !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
        private void btn_ClientAdd_Click(object sender, EventArgs e)
        {
            Form_Detail_Client f = new Form_Detail_Client(0, true);
            f.myDel = LoadData;
            this.Hide();
            f.ShowDialog();
            this.Show();
            //Reload Data
        }
        private void btn_ClientEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                
                if ((bool)dgv.SelectedRows[0].Cells["CliActiveflag"].Value == true)
                {
                    Form_Detail_Client f = new Form_Detail_Client(int.Parse(dgv.SelectedRows[0].Cells["IdClient"].Value.ToString()), true);
                    f.myDel = LoadData;
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Can't update inactive client!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
            }   
            else
            {
                MessageBox.Show("Please choose only 1 rows to update !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
        }
        private void btn_ClientDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                //Delete client
                clientBLL.delete(int.Parse(dgv.SelectedRows[0].Cells["IdClient"].Value.ToString()));
                LoadData();
            }
            else
            {
                MessageBox.Show("Please choose only 1 rows to delete !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void btn_ClientNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage) //Thay 10 thanh ham get total booking record 
            {
                currentPage += 1;
                LoadData();
                tb_ClientPageNumber.Text = currentPage + "/" + totalPage;
            }
        }

        private void btn_ClientPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage -= 1;
                LoadData();
                tb_ClientPageNumber.Text = currentPage + "/" + totalPage;
            }
        }

        private void btn_ClientRestore_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                clientBLL.restore(int.Parse(dgv.SelectedRows[0].Cells["IdClient"].Value.ToString()));
                LoadData();
            }
            else
            {
                MessageBox.Show("Please choose only 1 rows to restore !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}