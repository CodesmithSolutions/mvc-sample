using Codesmith.MvcSample.BusinessObjects;
using System.Collections.Generic;

namespace Codesmith.MvcSample.Services.Contracts
{
    public interface IIssueService
    {
        IssueDto GetIssueById(int issueId);

        List<IssueDto> GetIssues();

        IssueDto UpdateIssue(IssueDto issueDto);

        void AssignIssueById(int issueId, int userId);
    }
}
