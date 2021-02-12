using System;
using AutoMapper;
using Codesmith.MvcSample.DataAccess.EntityRepo;
using Codesmith.MvcSample.DataAccess.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using Codesmith.MvcSample.DataAccess.Contracts;
using Codesmith.MvcSample.BusinessObjects;
using System.Data.Entity;

namespace Codesmith.MvcSample.DataAccess
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IMapper _mapper;

        public IssueRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IssueDto GetIssueById(int issueId)
        {
            using (var context = new DatabaseContext())
            {
                return context.Issues
                    .FirstOrDefault(x => x.IssueId == issueId)
                    .ToDto(_mapper);
            }
        }

        public List<IssueDto> GetIssues()
        {
            using (var context = new DatabaseContext())
            {
                return context.Issues
                    .Include(x => x.AssignedTo)
                    .Include(x => x.CreatedBy)
                    .ToList()
                    .Select(x => x.ToDto(_mapper))
                    .ToList();
            }
        }

        public IssueDto UpdateIssue(IssueDto dto)
        {
            using (var context = new DatabaseContext())
            {
                var entity = context.Issues
                    .FirstOrDefault(x => x.IssueId == dto.IssueId);

                if (entity == null)
                {
                    entity = new IssueEntity { CreateDate = DateTime.Now };
                    context.Issues.Add(entity);
                }

                _mapper.Map(dto, entity);
                entity.LastUpdateDate = DateTime.Now;
                context.SaveChanges();

                return _mapper.Map<IssueDto>(entity);
            }
        }
    }
}
