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
    public class User //class ����Ǩ�ͺ status 
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

