using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole
{
    public class EnrollFunctions
    {
        public EnrollDataServiceContext ConnectToTable(string tablename)
        {
            string value = "UseDevelopmentStorage=true";

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(value);

            cloudStorageAccount.CreateCloudTableClient().CreateTableIfNotExist(tablename);

            EnrollDataServiceContext svc = new EnrollDataServiceContext(cloudStorageAccount.TableEndpoint.ToString(), cloudStorageAccount.Credentials);
            return svc;
        }

        public void Delete_all(EnrollDataServiceContext svc)
        {
            var q = from Enroll in svc.CreateQuery<Enroll>("EnrollTable")
                    select Enroll;
            foreach (var p in q)
            {
                svc.DeleteObject(p);
            }

            svc.SaveChanges();
        }
    }
}