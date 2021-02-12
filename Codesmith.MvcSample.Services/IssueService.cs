using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.DataAccess;

namespace Codesmith.MvcSample.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IUserRepository _userRepository;

        public IssueService(IIssueRepository issueRepository, IUserRepository userRepository)
        {
            _issueRepository = issueRepository;
            _userRepository = userRepository;
        }

        public IssueDto GetIssueById(int issueId)
        {
            return _issueRepository.GetIssueById(issueId);
        }

        public List<IssueDto> GetIssues()
        {
            return _issueRepository.GetIssues();
        }

        public IssueDto CreateIssue(IssueDto issueDto)
        {
            throw new NotImplementedException();
        }

        public IssueDto UpdateIssue(IssueDto issueDto)
        {
            // TODO: Get the logged in user instead of hard coding
            var currentUserId = 1;

            issueDto.CreatedByUserId = currentUserId;
            return _issueRepository.UpdateIssue(issueDto);
        }

        public void AssignIssueById(int issueId, int userId)
        {
            var issue = _issueRepository.GetIssueById(issueId);
            issue.AssignedToUserId = userId;
            _issueRepository.UpdateIssue(issue);
        }
    }
}
