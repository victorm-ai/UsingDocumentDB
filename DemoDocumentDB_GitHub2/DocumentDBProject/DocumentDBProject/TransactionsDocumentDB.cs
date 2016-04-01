using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DocumentDBProject
{
    public static class TransactionsDocumentDB<T>
    {
        static DocumentClient Client = Repository.Client;
        static DocumentCollection Collection = Repository.Collection;

        //Select Method
        public static IEnumerable<T> GetAllItems()
        {
            return Client.CreateDocumentQuery<T>(Collection.DocumentsLink).AsEnumerable();
        }

        //Create Document Method
        public static async Task<Document> CreateItemAsync(T Item)
        {
            return await Client.CreateDocumentAsync(Collection.SelfLink, Item);
        }

        //Get Document for ID Method
        public static Document GetDocument(string ItemID)
        {
            return Client.CreateDocumentQuery(Collection.DocumentsLink).Where(d => d.Id == ItemID).AsEnumerable().FirstOrDefault();
        }

        //Update Document Method
        public static async Task<Document> UpdateItemsAsync(string ItemID, T item)
        {
            Document DocumentExisting = GetDocument(ItemID);
            return await Client.ReplaceDocumentAsync(DocumentExisting.SelfLink, item);
        }

        //Delete Document Method
        public static async Task<Document> DeleteItemsAsync(string ItemID)
        {
            Document DocumentExisting = GetDocument(ItemID);
            return await Client.DeleteDocumentAsync(DocumentExisting.SelfLink);
        }
    }
}