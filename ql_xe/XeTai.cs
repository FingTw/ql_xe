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
            int tuoi = TinhTuoiXe();
            if (tuoi <= 7)
                return NgaySanXuat.AddMonths(24); // Chu kỳ đầu 24 tháng
            else
                return NgaySanXuat.AddMonths(6); // Định kỳ 6 tháng
        }

        public override string ToString()
        {
            return base.ToString() + $", Trong tai: {TrongTai} tan";
        }
    }

}
