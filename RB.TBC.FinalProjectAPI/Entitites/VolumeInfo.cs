using MongoDB.Bson;

namespace RB.TBC.FinalProjectAPI.Entitites
{
    public class VolumeInfo
    {
        public ObjectId VolumeInfoId { get; set; }
        public string title { get; set; }
        public IEnumerable<string> authors { get; set; }
        public ImageLinks imageLinks { get; set; }
        public string description { get; set; }
    }
}
