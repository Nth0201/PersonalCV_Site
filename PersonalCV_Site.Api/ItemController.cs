using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Firestore;
using Data;
namespace PersonalCV_Site.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly FirebaseConfig _firebaseConfig;

        public ItemController(FirebaseConfig firebaseConfig)
        {
            _firebaseConfig = firebaseConfig;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                Query query = _firebaseConfig.Database.Collection("TestData");
                QuerySnapshot snapshot = await query.GetSnapshotAsync();
                var items = snapshot.Documents.Select(d => d.ConvertTo<TestDataJson>());
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Dictionary<string, object> item)
        {
            try
            {
                DocumentReference docRef = _firebaseConfig.Database.Collection("items").Document();
                await docRef.SetAsync(item);
                return Ok(new { Id = docRef.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}