using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class Database
    {
        private static DatabaseEntities7 db = null;

        private Database() { }

        public static DatabaseEntities7 getDb()
        {
            if(db == null)
            {
                db = new DatabaseEntities7();
            }

            return db;
        }
    }
}