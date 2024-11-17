using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal abstract class xe
    {
        public string BienSo { get; set; }
        public DateTime NgaySanXuat { get; set; }

        // Constructor của lớp Xe (Chỉ được tạo đối tượng thông qua các lớp kế thừa)

        
        protected xe(string bienSo, DateTime ngaySanXuat)
        {
            BienSo = bienSo;
            NgaySanXuat = ngaySanXuat;
        }

        // Phương thức tính tuổi xe, không thể truy cập ngoài lớp hoặc lớp kế thừa
        protected int TinhTuoiXe()
        {
            return DateTime.Now.Year - NgaySanXuat.Year;
        }

        // Phương thức tính thời gian đăng kiểm, được triển khai trong lớp kế thừa
        public abstract DateTime ThoiGianDangKiem();

        // Override phương thức ToString để hiển thị thông tin của xe
        public override string ToString()
        {
            return $"Bien so: {BienSo}, Ngày sản xuất: {NgaySanXuat:dd/MM/yyyy}";
        }
    }
}
