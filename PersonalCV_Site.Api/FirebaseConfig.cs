using Firebase.Storage;
using Google.Cloud.Firestore;
using System.IO;

namespace PersonalCV_Site.Api
{
    public class FirebaseConfig
    {
        public FirestoreDb Database { get; set; }
        
        public FirebaseConfig(IConfiguration configuration)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            Database = FirestoreDb.Create(configuration["Firebase:ProjectId"]);
        }
    }
}