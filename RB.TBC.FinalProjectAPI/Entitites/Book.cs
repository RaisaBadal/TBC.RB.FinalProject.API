using MongoDB.Bson;

namespace RB.TBC.FinalProjectAPI.Entitites
{
    public class Book
    {
        public ObjectId BookId { get; set; }
        public string Id { get; set; }

        public VolumeInfo VolumeInfo { get; set; }
    }
}
