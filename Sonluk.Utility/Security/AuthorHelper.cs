using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Utility.Security
{
    public class AuthorHelper
    {
        public static bool Valid(string ecode, string ekey)
        {
            string dcode = DESE.Decrypt(ecode, ekey);
            int dkeyNum = Convert.ToInt32(dcode.Substring(0, 3));
            string dkey = dcode.Substring(3, dkeyNum);
            long dtime = Convert.ToInt64(dcode.Substring(3 + dkeyNum));
            if (dkey == ekey && (DateTime.Now.ToFileTimeUtc() - dtime) / 10000000 < 900)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
