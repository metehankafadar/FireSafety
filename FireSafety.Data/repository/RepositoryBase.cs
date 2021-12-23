using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Data.repository
{
    public class RepositoryBase
    {
        private static FireSafetyContext _db;
        private static object _lockSync = new object();

        public RepositoryBase()
        {

        }
        public static FireSafetyContext CreateContext()
        {
            if (_db == null)
            {
                lock (_lockSync)
                {
                    if (_db == null)
                    {
                        _db = new FireSafetyContext();
                    }

                }

            }
            return _db;
        }

    }
}
