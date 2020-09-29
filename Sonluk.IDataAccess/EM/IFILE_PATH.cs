using Sonluk.Entities.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface IFILE_PATH
    {
         EM_FILE_PATH Read(string type);
         EM_FILE_PATH ReadByID(int type);
    }
}
