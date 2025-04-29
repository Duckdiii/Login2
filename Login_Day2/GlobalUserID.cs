using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Day2
{
    public static class GlobalUserID
    {
        public static int GlobalID { get; private set; }
        public static void SetGlobalID(int id)
        {
            GlobalID = id;
        }
        public static int GetUserId()
        {
            return GlobalID;
        }
    }
}
