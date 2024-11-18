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

            List<xe> danhSachXe = new List<xe>
        {
            // Xe ô tô
            new XeOto("79A-12345", new DateTime(2015, 6, 12), 5, false),
            new XeOto("51B-67890", new DateTime(2020, 10, 15), 7, true),
            new XeOto("62C-88889", new DateTime(2018, 3, 25), 9, false),
            new XeOto("30E-45678", new DateTime(2011, 7, 18), 4, false),
            new XeOto("43A-11122", new DateTime(2013, 11, 20), 16, true),
            new XeOto("60B-99999", new DateTime(2007, 2, 14), 12, true),
            new XeOto("49A-33333", new DateTime(2022, 9, 5), 4, false),
            new XeOto("34B-55555", new DateTime(2010, 1, 10), 10, false),
            new XeOto("28A-22222", new DateTime(2019, 7, 30), 6, true),
            new XeOto("92A-44444", new DateTime(2005, 12, 25), 8, true),

            // Xe tải
            new XeTai("62B-00001", new DateTime(2010, 8, 10), 1.5),
            new XeTai("60C-12345", new DateTime(2018, 5, 12), 10),
            new XeTai("65D-99999", new DateTime(2013, 3, 30), 20),
            new XeTai("61E-55555", new DateTime(2019, 9, 10), 8.5),
            new XeTai("30G-77777", new DateTime(2022, 2, 25), 5),
            new XeTai("50H-11111", new DateTime(2017, 11, 3), 3.5),
            new XeTai("73C-22222", new DateTime(2015, 6, 8), 15),
            new XeTai("54D-66666", new DateTime(2008, 4, 20), 25),
            new XeTai("48C-88888", new DateTime(2003, 1, 9), 2),
            new XeTai("29B-44444", new DateTime(2020, 3, 15), 12.5)
        };

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

