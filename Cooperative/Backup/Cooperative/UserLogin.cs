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
        //�� class ����㹡�õԴ��͡�� class �׹���¼�ҹ�����
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

