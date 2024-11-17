using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var danhSachXe = new List<xe>();
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Thêm xe oto");
                Console.WriteLine("2. Them xe tai");
                Console.WriteLine("3. Xuat danh sach tat ca cac xe");
                Console.WriteLine("4. Tim xe oto co so cho ngoi nhieu nhat");
                Console.WriteLine("5. Sap xep xe tai theo trong tai");
                Console.WriteLine("6. Xuat danh sach bien so xe đep");
                Console.WriteLine("7. Danh sach xe TP.HCM");
                Console.WriteLine("8. Thoi gian đang kiem sap toi");
                Console.WriteLine("9. Thoat");
                Console.Write("Chon chuc nang: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Thêm xe ô tô
                        Console.Write("Nhap bien so xe oto: ");
                        string bienSoOto = Console.ReadLine();
                        Console.Write("Nhap ngay san xuat (dd/MM/yyyy): ");
                        DateTime ngaySanXuatOto = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("Nhap so cho ngoi: ");
                        int soCho = int.Parse(Console.ReadLine());
                        Console.Write("Co kinh doanh van tai? (Co/Khong): ");
                        bool kinhDoanh = Console.ReadLine().ToLower() == "co";
                        XeOto xeOto = new XeOto(bienSoOto, ngaySanXuatOto, soCho, kinhDoanh);
                        danhSachXe.Add(xeOto);
                        break;

                    case 2:
                        // Thêm xe tải
                        Console.Write("Nhap bien so xe tai: ");
                        string bienSoTai = Console.ReadLine();
                        Console.Write("Nhap ngay san xuat (dd/MM/yyyy): ");
                        DateTime ngaySanXuatTai = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("Nhap trong tai (tan): ");
                        float trongTai = float.Parse(Console.ReadLine());
                        XeTai xeTai = new XeTai(bienSoTai, ngaySanXuatTai, trongTai);
                        danhSachXe.Add(xeTai);
                        break;

                    case 3:
                        // Xuất danh sách tất cả xe
                        Console.WriteLine("\nDanh sach cac xe:");
                        foreach (var xe in danhSachXe)
                        {
                            Console.WriteLine(xe);
                        }
                        break;

                    case 4:
                        // Tìm xe ô tô có số chỗ ngồi nhiều nhất
                        var xeOtoMax = danhSachXe.OfType<XeOto>().OrderByDescending(x => x.SoCho).FirstOrDefault();
                        if (xeOtoMax != null)
                        {
                            Console.WriteLine("\nXe oto co so cho ngoi nhieu nhat:");
                            Console.WriteLine(xeOtoMax);
                        }
                        else
                        {
                            Console.WriteLine("Khong co xe oto nào.");
                        }
                        break;

                    case 5:
                        // Sắp xếp xe tải theo trọng tải
                        var xeTaiSorted = danhSachXe.OfType<XeTai>().OrderBy(x => x.TrongTai).ToList();
                        Console.WriteLine("\nDanh sach xe tai theo trong tai (tang dan):");
                        foreach (var xe in xeTaiSorted)
                        {
                            Console.WriteLine(xe);
                        }
                        break;

                    case 6:
                        // Xuất danh sách biển số xe đẹp
                        Console.WriteLine("\nDanh sach bien so xe đep:");
                        foreach (var xe in danhSachXe)
                        {
                            if (xe.BienSo.Length == 10 && (xe.BienSo.EndsWith("88888") || xe.BienSo.EndsWith("99999")))
                            {
                                Console.WriteLine(xe.BienSo);
                            }
                        }
                        break;

                    case 7:
                        // Danh sách xe TP.HCM (Giả sử, biển số của TP.HCM là "79")
                        Console.WriteLine("\nDanh sach xe TP.HCM:");
                        foreach (var xe in danhSachXe)
                        {
                            if (xe.BienSo.StartsWith("79"))
                            {
                                Console.WriteLine(xe);
                            }
                        }
                        break;

                    case 8:
                        // Thời gian đăng kiểm sắp tới
                        Console.WriteLine("\nThoi gian đang kiem sap toi:");
                        foreach (var xe in danhSachXe)
                        {
                            Console.WriteLine($"{xe}: {xe.ThoiGianDangKiem():dd/MM/yyyy}");
                        }
                        break;

                    case 9:
                        // Thoát
                        return;

                    default:
                        Console.WriteLine("Chon khong hop le.");
                        break;
                }
            }
        }
        }
    }

