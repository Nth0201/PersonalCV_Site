using Google.Cloud.Firestore;
using System;

namespace Data {
    public class TestData {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required DateTime Time { get; set; }
    }

    [FirestoreData]
    public class TestDataJson {
        [FirestoreDocumentId]
        public required string Id { get; set; }
        [FirestoreProperty]
        public required string Title { get; set; }
        [FirestoreProperty]
        public required DateTime Time { get; set; }
    }
}