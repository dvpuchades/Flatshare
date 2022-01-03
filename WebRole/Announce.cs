using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole
{
    public class Announce : TableServiceEntity
    {
        public Announce() : base()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = String.Empty;
        }
        public Announce(string address, string city, int rooms, double prize, string description) : base()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = String.Empty;
            this.address = address;
            this.city = city;
            this.rooms = rooms;
            this.prize = prize;
            this.description = description;
        }

        public string address
        {
            get;
            set;
        }
        public string city
        {
            get;
            set;
        }
        public int rooms
        {
            get;
            set;
        }
        public double prize
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public string landlord
        {
            get;
            set;
        } 
    }

    public class AnnounceDataServiceContext : TableServiceContext
    {
        internal AnnounceDataServiceContext(string baseAddress, Microsoft.WindowsAzure.StorageCredentials credentials) : base(baseAddress, credentials)
        { }

        internal const string AnnounceTableName = "AnnounceTable";
    }
}