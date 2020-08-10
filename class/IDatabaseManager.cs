using RoadBook.CsharpBasic.Chapter10.Examples.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadBook.CsharpBasic.Chapter10.Examples.Manager
{
    public interface IDatabaseManager
    {
        void Open(DatabaseInfo dbInfo);
        DataTable Select(string sql);
        int Insert(string sql);
        int Update(string sql);
        int Delete(string sql);
        void Close();
    }
}
