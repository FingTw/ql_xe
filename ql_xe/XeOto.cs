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
            int tuoi = TinhTuoiXe();
            if (SoCho <= 9 && !KinhDoanhVanTai)
            {
                if (tuoi <= 7)
                    return NgaySanXuat.AddMonths(36); // Chu kỳ đầu 36 tháng
                else if (tuoi <= 20)
                    return NgaySanXuat.AddMonths(12); // Định kỳ 12 tháng
                else
                    return NgaySanXuat.AddMonths(6); // Định kỳ 6 tháng
            }
            else
            {
                if (tuoi <= 5)
                    return NgaySanXuat.AddMonths(24); // Chu kỳ đầu 24 tháng
                else
                    return NgaySanXuat.AddMonths(6); // Định kỳ 6 tháng
            }
        }

        public override string ToString()
        {
            string kinhDoanh = KinhDoanhVanTai ? "Co" : "Khong";
            return base.ToString() + $", So cho ngoi: {SoCho}, Kinh doanh van tai: {kinhDoanh}";
        }
    }
}
