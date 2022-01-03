using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole
{
    public class UserFunctions
    {
        public UserDataServiceContext ConnectToTable(string tablename)
        {
            string value = "UseDevelopmentStorage=true";

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(value);

            cloudStorageAccount.CreateCloudTableClient().CreateTableIfNotExist(tablename);

            UserDataServiceContext svc = new UserDataServiceContext(cloudStorageAccount.TableEndpoint.ToString(), cloudStorageAccount.Credentials);
            return svc;
        }


        public void Delete_all(UserDataServiceContext svc)
        {
            var q = from user in svc.CreateQuery<User>("UserTable")
                    select user;
            foreach (var p in q)
            {
                svc.DeleteObject(p);
            }

            svc.SaveChanges();
        }
    }
}