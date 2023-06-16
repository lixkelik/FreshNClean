using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTrsDetail(int trsId, int serviceId, int qty)
        {
            TransactionDetail trsDetail = new TransactionDetail();
            trsDetail.TransactionID = trsId;
            trsDetail.ServiceID = serviceId;
            trsDetail.Qty = qty;

            return trsDetail;
        }
    }
}