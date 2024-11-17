using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal class XeTai : xe
    {
        public float TrongTai { get; set; }

        // Constructor của xe tải
        public XeTai(string bienSo, DateTime ngaySanXuat, float trongTai)
            : base(bienSo, ngaySanXuat)
        {
            TrongTai = trongTai;
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
            return base.ToString() + $", Trọng tai: {TrongTai} tan";
        }
    }

}
