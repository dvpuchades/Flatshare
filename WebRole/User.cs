using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole
{
    public class User : TableServiceEntity
    {
        public User() : base()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = String.Empty;
        }
        
        public User(string nickname, string email, string password) : base()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = String.Empty;
            this.nickname = nickname;
            this.email = email;
            this.password = password;
        }

        public string nickname
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public int age
        {
            get;
            set;
        }
        public string activity
        {
            get;
            set;
        }
        public string interest
        {
            get;
            set;
        }
        public string searchingIn
        {
            get;
            set;
        }
    }

    public class UserDataServiceContext : TableServiceContext
    {
        internal UserDataServiceContext(string baseAddress, Microsoft.WindowsAzure.StorageCredentials credentials): base(baseAddress, credentials)
        { }

        internal const string UserTableName = "UserTable";
    }
}