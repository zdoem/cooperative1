using System;
using System.Collections.Generic;
using System.Text;

namespace LogingSendID
{
    public class SendIDEmp : MarshalByRefObject
    {
        public SendIDEmp()
        {
        }

        private static string empID = "";
        public string EmpoyeeID
        {
            get
            {
                return empID;
            }

        }

        public static void setEmpID(string id)
        {
            empID = id;

        }



    }
}
