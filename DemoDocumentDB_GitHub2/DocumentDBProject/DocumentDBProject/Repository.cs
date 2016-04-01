using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentDBProject
{
    public class Repository
    {
        public static string _enpoint =
       "https://mydocumentdbtest2.documents.azure.com:443";

        public static string _authKey = "b2QL5Qzqus4euui8hhkQ2b6h1pTYOG93A8LatCsWRb2fg5q47cwWynS1ovR1LjNkZUsyketUz0qFTNKZQgEOgQ==";

        public static string _database =
        "MyDataBaseDocumentDB";

        public static string _colletion =
        "CollectionDocumentDB";

        #region properties

        private static DocumentClient client;

        public static DocumentClient Client
        {
            get
            {
                if (client == null)
                {
                    Uri enpointUri = new Uri(_enpoint);
                    client = new DocumentClient(enpointUri, _authKey);
                }

                return client;
            }
        }

        private static string dataBaseId;
        private static string DataBaseId
        {
            get
            {
                if (string.IsNullOrEmpty(dataBaseId))
                {
                    dataBaseId = _database;
                }

                return dataBaseId;
            }
        }

        private static string collectionId;
        private static string CollectionID //tenia public
        {
            get
            {
                if (string.IsNullOrEmpty(collectionId))
                {
                    collectionId = _colletion;
                }

                return collectionId;
            }
        }

        private static Database database;
        private static Database DataBase
        {
            get
            {
                if (database == null)
                {
                    database = ReadOrCreateDataBase();
                }

                return database;
            }
        }

        private static DocumentCollection collection;

        public static DocumentCollection Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = ReadOrCreateCollection(DataBase.SelfLink);
                }

                return collection;
            }
        }

        #endregion

        #region Methods

        private static Database ReadOrCreateDataBase()
        {
            var DataBase = Client.CreateDatabaseQuery().Where(d => d.Id == DataBaseId).AsEnumerable().FirstOrDefault();

            if (DataBase == null)
            {
                DataBase = Client.CreateDatabaseAsync(new Database { Id = DataBaseId }).Result;
            }

            return DataBase;
        }

        private static DocumentCollection ReadOrCreateCollection(string DataBaseLink)
        {
            var TheCollection =
            Client.CreateDocumentCollectionQuery(DataBaseLink).Where(c => c.Id == CollectionID).AsEnumerable().FirstOrDefault();

            if (TheCollection == null)
            {
                var collectionSpec = new DocumentCollection { Id = CollectionID };
                var requestOptions = new RequestOptions { OfferType = "S1" };

                TheCollection = Client.CreateDocumentCollectionAsync(DataBaseLink, collectionSpec, requestOptions).Result;
            }

            return TheCollection;
        }

        #endregion
    }
}