using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Common
{
    public class SQLiteTest
    {
        SQLiteConnection.CreateFile("MyDatabase.sqlite");
    }
}
