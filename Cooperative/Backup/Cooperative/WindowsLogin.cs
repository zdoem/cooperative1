/*using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperative
{
    class WindowsLogin
    {
    }
}*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperative
{
    public class WindowsLogin
    {
        public WindowsLogin() { }
        //สร้าง พร๊อพเพอร์ตี้ ชนิดข้อมูลแบบ enum
        public enum CoopUser
        {
            //กำหนดค่าตัวแปร 2 ค้า
            User = 1,
            Admin = 2
        }
    }
}

