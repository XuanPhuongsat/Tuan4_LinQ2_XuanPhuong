using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tuan4_LinQ2_XuanPhuong.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int masach { get; set; }
        // -------ten sach

        [Display(Name = "Ten Sach")]
        public string tensach { get; set; }

        // -------anh bia
        [Display(Name = "Anh bia")]
        public string hinh { get; set; }

        // -------gia ban

        [Display(Name = "Gia ban")]
        public double giaban { get; set; }

        // -------so luong

        [Display(Name = "So luong")]
        public int iSoluong { get; set; }

        // -------thanh tien
        [Display(Name = "Thanh Tien")]
        public Double dThanhTien
        {
        get { return iSoluong * giaban; }
        }
        public GioHang(int id)
        {
            masach = id;
            Sach sach = data.Saches.Single(n => n.masach == masach);
            tensach = sach.tensach;
            hinh = sach.hinh;
            giaban = double.Parse(sach.giaban.ToString());
            iSoluong = 1;
        }
    }
}