using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_LinQ2_XuanPhuong.Models;

namespace Tuan4_LinQ2_XuanPhuong.Controllers
{
    public class NguoiDungController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        [HttpGet]
        // GET: NguoiDung
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["hoten"];
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var dienthoai = collection["dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Phài nhập mật khấu xác nhân!";
            }
            else
            {
                if (!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mat khau va mat khau xac nhan phai giong nhau";
                }
                else
                {
                    kh.hoten = hoten;
                    kh.tendangnhap = tendangnhap;
                    kh.matkhau = matkhau;
                    kh.email = email;
                    kh.diachi = diachi;
                    kh.dienthoai = dienthoai;
                    kh.ngaysinh = DateTime.Parse(ngaysinh);
                    data.KhachHangs.InsertOnSubmit(kh);
                    data.SubmitChanges();
                    return RedirectToAction("DangNhap");
                }
            }
            return this.DangKy();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.tendangnhap == tendangnhap && n.matkhau == matkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đãng nhập thành công";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = "Tên đãng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}