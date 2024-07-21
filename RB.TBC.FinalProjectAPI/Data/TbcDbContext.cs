using MongoDB.Driver;
using RB.TBC.FinalProjectAPI.Entitites;

namespace RB.TBC.FinalProjectAPI.Data
{
    public class TbcDbContext
    {
        private readonly MongoClient client;
        public IMongoCollection<Book> Books { get; set; }
        public TbcDbContext()
        {
            client = new MongoClient("mongodb+srv://Raisa:Raisa2001@cluster0.rhi3iad.mongodb.net/");
            var database = client.GetDatabase("TBCFINAL");
            Books = database.GetCollection<Book>("Books");
        }
    }
}
