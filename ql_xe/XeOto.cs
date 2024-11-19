using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal class XeOto : xe
    {
        public int SoCho { get; set; }
        public bool KinhDoanhVanTai { get; set; }

        // Constructor của xe ô tô
        public XeOto(string bienSo, DateTime ngaySanXuat, int soCho, bool kinhDoanhVanTai)
            : base(bienSo, ngaySanXuat)
        {
            SoCho = soCho;
            KinhDoanhVanTai = kinhDoanhVanTai;
        }

        // Tính thời gian đăng kiểm cho xe ô tô
        public override DateTime ThoiGianDangKiem()
        {
            DateTime kyDangKiem = NgaySanXuat; // Ngày sản xuất là kỳ kiểm định đầu tiên
            int tuoi = TinhTuoiXe(); // Tính tuổi xe hiện tại
            int chuKy; // Chu kỳ kiểm định

            if (SoCho <= 9 && !KinhDoanhVanTai)
            {
                if (tuoi <= 7)
                    chuKy = 36; // Chu kỳ đầu: 36 tháng
                else if (tuoi <= 20)
                    chuKy = 12; // Định kỳ: 12 tháng
                else
                    chuKy = 6; // Định kỳ: 6 tháng
            }
            else
            {
                if (tuoi <= 5)
                    chuKy = 24; // Chu kỳ đầu: 24 tháng
                else
                    chuKy = 6; // Định kỳ: 6 tháng
            }

            // Tính chu kỳ tiếp theo
            while (kyDangKiem <= DateTime.Now)
            {
                if (SoCho <= 9 && !KinhDoanhVanTai)
                {
                    if (tuoi <= 7)
                        chuKy = 24; // Định kỳ: 24 tháng
                    else if (tuoi <= 20)
                        chuKy = 12; // Định kỳ: 12 tháng
                    else
                        chuKy = 6; // Định kỳ: 6 tháng
                }
                else
                {
                    if (tuoi <= 5)
                        chuKy = 12; // Định kỳ: 12 tháng
                    else
                        chuKy = 6; // Định kỳ: 6 tháng
                }

                kyDangKiem = kyDangKiem.AddMonths(chuKy); // Cộng thêm chu kỳ
                tuoi = kyDangKiem.Year - NgaySanXuat.Year; // Cập nhật tuổi xe
            }

            return kyDangKiem;
        }

        public override string ToString()
        {
            string kinhDoanh = KinhDoanhVanTai ? "Co" : "Khong";
            return base.ToString() + $", So cho ngoi: {SoCho}, Kinh doanh van tai: {kinhDoanh}";
        }
    }
}
