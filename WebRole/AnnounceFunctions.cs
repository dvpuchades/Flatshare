using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole
{
    public class AnnounceFunctions
    {
        public AnnounceDataServiceContext ConnectToTable(string tablename)
        {
            string value = "UseDevelopmentStorage=true";

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(value);

            cloudStorageAccount.CreateCloudTableClient().CreateTableIfNotExist(tablename);

            AnnounceDataServiceContext svc = new AnnounceDataServiceContext(cloudStorageAccount.TableEndpoint.ToString(), cloudStorageAccount.Credentials);
            return svc;
        }

        
        public void Delete_all(AnnounceDataServiceContext svc)
        {
            var q = from Announce in svc.CreateQuery<Announce>("AnnounceTable")
                    select Announce;
            foreach (var p in q)
            {
                svc.DeleteObject(p);
            }

            svc.SaveChanges();
        }
    }
}