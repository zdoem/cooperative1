/*using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperative
{
    class User
    {
    }
}*/


using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperative
{
    public class User //class ไว้ตรวจสอบ status 
    {
        private int nCoop;
        public User()
        { }

        public int Coop
        {
            get { return nCoop; }
            set { nCoop = value; }
        }

    }
}

