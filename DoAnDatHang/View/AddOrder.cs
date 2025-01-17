﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnDatHang;
using DoAnDatHang.BLL;

namespace DOAN.View
{
    public partial class AddOrder : Form
    {
        int ID;
        public delegate void Del();
        public Del a;
        public AddOrder(int id = 0)
        {
            InitializeComponent();
            ID = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DoAnEntities a = new DoAnEntities();
            List<Khach> khach = a.Khaches.ToList();
            dataGridView1.DataSource = a.Khaches.ToList();
        }
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView a = (sender as DataGridView);
            if (a.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                NuocUong mon = BLL_NuocUong.Instance.getNuocByID(Convert.ToInt32(a.Rows[e.RowIndex].Cells["MaNuocUong"].Value));
                foreach (DataGridViewRow i in dataGridView4.Rows)
                {
                    if (Convert.ToInt32(i.Cells["MaNuocUong"].Value) == Convert.ToInt32(a.Rows[e.RowIndex].Cells["MaNuocUong"].Value))
                    {
                        i.Cells["SoLuongNuoc"].Value = Convert.ToInt32(i.Cells["SoLuongNuoc"].Value) + 1;
                        //SetThanhTien();
                        return;
                    }
                }
                dataGridView4.Rows.Add(mon.MaNuocUong, mon.TenNuocUong, mon.Gia, 1, mon.Gia);
                //SetThanhTien();
            }
        }
        private void AddOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL_MonAn.Instance.getAllMonAnView();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Thêm";
            buttonColumn.HeaderText = "Thêm";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView5.DataSource = BLL_NuocUong.Instance.getAllNuocView();
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Text = "Thêm";
            buttonColumn1.HeaderText = "Thêm";
            buttonColumn1.UseColumnTextForButtonValue = true;
            dataGridView5.Columns.Add(buttonColumn1);
            dataGridView1.Columns.Add(buttonColumn);
            comboBox1.DataSource = BLL_KhachHang.Instance.getAllKhach();
            comboBox1.DisplayMember = "HoTen";
            comboBox2.DataSource = BLL_NhanVien.Instance.getAllNhanVien();
            comboBox2.DisplayMember = "HoTen";
            if (ID != 0)
            {
                foreach (var i in BLL_MonAn.Instance.GetMonAn_HDDatHang(ID))
                {
                    MonAn mon = BLL_MonAn.Instance.getMonAnByID(i.MaMonAn);
                    dataGridView2.Rows.Add(mon.MaMonAn, mon.TenMonAn, i.Gia, i.SoLuong, i.ThanhTien);
                }
                foreach (var i in BLL_NuocUong.Instance.getNuocUong_HDDatHang(ID))
                {
                    NuocUong nuoc = BLL_NuocUong.Instance.getNuocByID(i.MaNuocUong);
                    dataGridView4.Rows.Add(nuoc.MaNuocUong, nuoc.TenNuocUong, nuoc.Gia, i.SoLuong, i.ThanhTien);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView a = (sender as DataGridView);
            if (a.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                MonAn mon = BLL_MonAn.Instance.getMonAnByID(Convert.ToInt32(a.Rows[e.RowIndex].Cells["MaMonAn"].Value));
                foreach (DataGridViewRow i in dataGridView2.Rows)
                {
                    if (Convert.ToInt32(i.Cells["MaMonAn"].Value) == Convert.ToInt32(a.Rows[e.RowIndex].Cells["MaMonAn"].Value))
                    {
                        i.Cells["SoLuong"].Value = Convert.ToInt32(i.Cells["SoLuong"].Value) + 1;
                        //SetThanhTien();
                        return;
                    }
                }
                dataGridView2.Rows.Add(mon.MaMonAn, mon.TenMonAn, mon.Gia, 1, mon.Gia);
                //SetThanhTien();
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView a = (sender as DataGridView);
            if (a.Columns[e.ColumnIndex].Name.Equals("SoLuong") && e.RowIndex >= 0)
            {
                a.Rows[e.RowIndex].Cells["ThanhTien"].Value = Convert.ToDouble(a.Rows[e.RowIndex].Cells["Gia"].Value) * Convert.ToInt32(a.Rows[e.RowIndex].Cells["SoLuong"].Value);
            }
            //SetThanhTien();
        }
        private void dataGridView5_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView a = (sender as DataGridView);
            if (a.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                a.Rows.Remove(a.Rows[e.RowIndex]);
                //SetThanhTien();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<MonAn_HDDatHang> mon = new List<MonAn_HDDatHang>();
            if (ID == 0)
            {
                HDDatHang hoadon = new HDDatHang
                {
                    ThoiGian = DateTime.Now,
                 //   MaNhanVien = (comboBox2.SelectedItem as NhanVien).MaNhanVien,
                    TrangThai = true,
                    MaKhachHang = (comboBox1.SelectedItem as Khach).MaKhachHang
                };
                int ma = BLL_HoaDon.Instance.createHoaDon(hoadon);
                foreach (DataGridViewRow i in dataGridView2.Rows)
                {
                    mon.Add(new MonAn_HDDatHang
                    {
                        MaMonAn = Convert.ToInt32(i.Cells["MaMonAn"].Value),
                        Gia = Convert.ToInt32(i.Cells["Gia"].Value),
                        SoLuong = Convert.ToInt32(i.Cells["SoLuong"].Value),
                        MaHDDHang = ma
                    });
                }
                BLL_MonAn.Instance.addMonAnHDDatHang(mon);
            } else
            {
                foreach (DataGridViewRow i in dataGridView2.Rows)
                {
                    mon.Add(new MonAn_HDDatHang
                    {
                        MaMonAn = Convert.ToInt32(i.Cells["MaMonAn"].Value),
                        Gia = Convert.ToInt32(i.Cells["Gia"].Value),
                        SoLuong = Convert.ToInt32(i.Cells["SoLuong"].Value),
                        MaHDDHang = ID
                    });
                }
                BLL_MonAn.Instance.editMonAnHDDatHang(mon);
            }
            MessageBox.Show("Thanh cong");
            a();
        }
    }
}
