using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_xe
{
    internal class DangKiem
    {

        // Tính chi phí đăng kiểm cho từng loại xe
        public static decimal TinhChiPhiDangKiem(xe xe)
        {
            // Kiểm tra loại xe và tính chi phí
            if (xe is XeOto)
            {
                XeOto xeOTo = (XeOto)xe;
                if (xeOTo.SoCho <= 10)
                {
                    return 240000; // Xe ô tô <= 10 chỗ
                }
                else
                {
                    return 320000; // Xe ô tô > 10 chỗ
                }
            }
            else if (xe is XeTai)
            {
                XeTai xeTai = (XeTai)xe;
                if (xeTai.TrongTai > 20)
                {
                    return 560000; // Xe tải > 20 tấn
                }
                else if (xeTai.TrongTai >= 7)
                {
                    return 350000; // Xe tải từ 7 đến 20 tấn
                }
                else
                {
                    return 320000; // Xe tải < 7 tấn
                }
            }
            return 0; // Nếu không thuộc loại xe hợp lệ
        }
    }
}