using Codesmith.MvcSample.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.DataAccess.Contracts
{
    public interface IIssueRepository
    {
        IssueDto GetIssueById(int issueId);

        List<IssueDto> GetIssues();

        IssueDto UpdateIssue(IssueDto issue);
    }
}
