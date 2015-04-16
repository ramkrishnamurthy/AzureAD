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
        <id>ICD9CM_DX</id>
        <title>Diagnosis, ICD-9-CM</title>
    </book>
    <book>
        <id>ICD9CM_E</id>
        <title>E Code, ICD-9-CM</title>
    </book>
    <book>
        <id>ICD9CM_PR</id>
        <title>Procedure, ICD-9-CM</title>
    </book>
    <book>
        <id>ICD10CM_DX</id>
        <title>Diagnosis, ICD-10-CM</title>
    </book>
    <book>
        <id>ICD10CM_E</id>
        <title>External Cause, ICD-10-CM</title>
    </book>
    <book>
        <id>ICD10PCS_PR</id>
        <title>Procedure, ICD-10-PCS</title>
    </book>
    <book>
        <id>CPT4</id>
        <title>CPT Tabular</title>
    </book>
    <book>
        <id>HCPCS</id>
        <title>HCPCS Tabular</title>
    </book>
</books>";
        }
    }
}
