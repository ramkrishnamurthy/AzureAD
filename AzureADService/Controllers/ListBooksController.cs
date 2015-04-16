using System.Web.Http;

namespace AzureAD.Controllers
{
    [Authorize]
    public class ListBooksController : ApiController
    {
        public string Get()
        {
            return @"<books>
    <book>
        <id>HP1</id>
        <title>Harry Potter and the Sorcerer's Stone</title>
    </book>
    <book>
        <id>HP2</id>
        <title>Harry Potter and the Chamber of Secrets</title>
    </book>
    <book>
        <id>HP3</id>
        <title>Harry Potter and the Prisoner of Azkaban</title>
    </book>    
</books>";
        }
    }
}
