/*using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperative
{
    class UserLogin
    {
    }
}*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperative
{
    public class UserLogin
    {
        //เป้น class ทีใช้ในการติดต่อการ class อืนๆๆโดยผ่านตัวแปร
        private string nUser;
        private string nPass;
        private string nStatus;
        public UserLogin() { }

        public string User
        {
            get { return nUser; }
            set { nUser = value; }
        }

        public string Pass
        {
            get { return nPass; }
            set { nPass = value; }
        }

        public string Status
        {
            get { return nStatus; }
            set { nStatus = value; }
        }

    }
}

