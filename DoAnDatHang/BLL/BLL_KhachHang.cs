﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnDatHang.BLL
{
    class BLL_KhachHang
    {
        private static BLL_KhachHang _Instance;
        public static BLL_KhachHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_KhachHang();
                }
                return _Instance;
            }
        }
        public List<Khach> getAllKhach()
        {
            var db = new DoAnEntities();
            return db.Khaches.Select(s => s).ToList();
        }

        public Khach getKhachByID(int ID)
        {
            List<Khach> all = getAllKhach();
            foreach( Khach i in all)
            {
                if (i.MaKhachHang == ID)
                {
                    return i;
                }
            }
            return null;
        }
        public bool addKhachHang(Khach khach)
        {
            try {
                using (var db = new DoAnEntities())
                {
                    db.Khaches.Add(khach);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editKhachHang(Khach khach)
        {
            try
            {
                using (var db = new DoAnEntities())
                {
                    var result = db.Khaches.Find(khach.MaKhachHang);
                    if (result != null)
                    {
                        result.HoTen = khach.HoTen;
                        result.SDT = khach.SDT;
                        result.DiaChi = khach.DiaChi;
                        result.Email = khach.Email;
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool removeKhachHang(Khach khach)
        {
            try
            {
                using (var db = new DoAnEntities())
                {
                    var result = db.Khaches.Find(khach.MaKhachHang);
                    if (result != null)
                    {
                        db.Khaches.Remove(result);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}