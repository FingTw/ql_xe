using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal class XeTai : xe
    {
        private double v;

        public double TrongTai { get; private set; }

        // Constructor của xe tải
        public XeTai(string bienSo, DateTime ngaySanXuat, float trongTai)
            : base(bienSo, ngaySanXuat)
        {
            TrongTai = trongTai;
        }

        public XeTai(string bienSo, DateTime ngaySanXuat, double v) : base(bienSo, ngaySanXuat)
        {
            this.v = v;
        }

        // Tính thời gian đăng kiểm cho xe tải
        public override DateTime ThoiGianDangKiem()
        {
            DateTime kyDangKiem = NgaySanXuat; // Ngày sản xuất là kỳ đăng kiểm đầu tiên
            int tuoi = TinhTuoiXe(); // Tính tuổi xe hiện tại
            int chuKy; // Chu kỳ kiểm định

            if (tuoi <= 7)
            {
                chuKy = 24; // Chu kỳ đầu: 24 tháng
            }
            else
            {
                chuKy = 6; // Chu kỳ đầu: 6 tháng
            }

            // Tính chu kỳ tiếp theo dựa trên các mốc
            while (kyDangKiem <= DateTime.Now)
            {
                if (tuoi <= 7)
                {
                    chuKy = 12; // Định kỳ 12 tháng
                }
                else
                {
                    chuKy = 6; // Định kỳ 6 tháng
                }
                kyDangKiem = kyDangKiem.AddMonths(chuKy); // Cộng chu kỳ
                tuoi = kyDangKiem.Year - NgaySanXuat.Year; // Cập nhật tuổi xe
            }

            return kyDangKiem;
        }

        public override string ToString()
        {
            return base.ToString() + $", Trong tai: {TrongTai} tan";
        }
    }

}
