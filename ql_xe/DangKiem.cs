using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal class DangKiem
    {
        public static DateTime TinhThoiGianDangKiemTiepTheo(xe xe)
        {
            DateTime now = DateTime.Now;
            int yearsUsed = now.Year - xe.NgaySanXuat.Year;

            if (now.Month < xe.NgaySanXuat.Month || (now.Month == xe.NgaySanXuat.Month && now.Day < xe.NgaySanXuat.Day))
            {
                yearsUsed--;
            }

            int chuKyThang = 0;

            if (xe is XeOto oto)
            {
                if (oto.SoCho <= 9 && !oto.KinhDoanhVanTai)
                {
                    if (yearsUsed <= 7)
                        chuKyThang = 36;
                    else if (yearsUsed <= 20)
                        chuKyThang = 12;
                    else
                        chuKyThang = 6;
                }
                else
                {
                    if (yearsUsed <= 5)
                        chuKyThang = 24;
                    else
                        chuKyThang = 6;
                }
            }
            else if (xe is XeTai tai)
            {
                if (yearsUsed <= 7)
                    chuKyThang = 24;
                else
                    chuKyThang = 6;
            }

            return xe.NgaySanXuat.AddMonths(chuKyThang * ((yearsUsed == 0) ? 1 : yearsUsed / chuKyThang + 1));
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
