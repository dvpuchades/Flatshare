using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole
{
    public class Enroll : TableServiceEntity
    {
        public Enroll() : base()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = String.Empty;
        }
        public Enroll(string address, string landlord, string tenant) : base()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = String.Empty;
            this.address = address;
            this.landlord = landlord;
            this.tenant = tenant;
        }

        public string address
        {
            get;
            set;
        }
        
        public string landlord
        {
            get;
            set;
        }

        public string tenant
        {
            get;
            set;
        }
    }

    public class EnrollDataServiceContext : TableServiceContext
    {
        internal EnrollDataServiceContext(string baseAddress, Microsoft.WindowsAzure.StorageCredentials credentials) : base(baseAddress, credentials)
        { }

        internal const string EnrollTableName = "EnrollTable";
    }
}