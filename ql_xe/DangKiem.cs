using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal class DangKiem
    {// Tính hạn đăng kiểm tiếp theo
        public static DateTime TinhThoiGianDangKiemTiepTheo(xe xe, DateTime? lanDangKiemGanNhat = null)
        {
            DateTime now = DateTime.Now;
            DateTime ngaySanXuat = xe.NgaySanXuat;

            // Nếu chưa từng đăng kiểm, lấy ngày sản xuất làm mốc
            DateTime lanDangKiemCuoi = lanDangKiemGanNhat ?? ngaySanXuat;

            int yearsUsed = now.Year - ngaySanXuat.Year;
            if (now < ngaySanXuat.AddYears(yearsUsed)) yearsUsed--;

            int chuKyThang = 0;

            if (xe is XeOto oto)
            {
                if (oto.SoCho <= 9 && !oto.KinhDoanhVanTai)
                {
                    if (yearsUsed <= 7)
                    {
                        chuKyThang = lanDangKiemGanNhat == null ? 36 : 24; // Chu kỳ đầu 36 tháng, sau đó 24 tháng
                    }
                    else if (yearsUsed <= 20)
                    {
                        chuKyThang = 12; // Định kỳ 12 tháng
                    }
                    else
                    {
                        chuKyThang = 6; // Định kỳ 6 tháng
                    }
                }
                else
                {
                    if (yearsUsed <= 5)
                    {
                        chuKyThang = lanDangKiemGanNhat == null ? 24 : 12; // Chu kỳ đầu 24 tháng, sau đó 12 tháng
                    }
                    else
                    {
                        chuKyThang = 6; // Định kỳ 6 tháng
                    }
                }
            }
            else if (xe is XeTai tai)
            {
                if (yearsUsed <= 7)
                {
                    chuKyThang = lanDangKiemGanNhat == null ? 24 : 12; // Chu kỳ đầu 24 tháng, sau đó 12 tháng
                }
                else
                {
                    chuKyThang = 6; // Định kỳ 6 tháng
                }
            }

            // Tính hạn đăng kiểm tiếp theo
            return lanDangKiemCuoi.AddMonths(chuKyThang);
        }

        // Tính chi phí đăng kiểm
        public static decimal TinhChiPhiDangKiem(xe xe)
        {
            if (xe is XeOto oto)
            {
                return oto.SoCho > 10 ? 320000 : 240000;
            }
            else if (xe is XeTai tai)
            {
                if (tai.TrongTai > 20)
                    return 560000;
                else if (tai.TrongTai >= 7)
                    return 350000;
                else
                    return 320000;
            }
            return 0;
        }
    }
}