using CleanArchCQRS.Domain.Abstractions;
using CleanArchCQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRS.Application.Members.Queries
{
    public class GetMembersQuery : IRequest<IEnumerable<Member>>
    {
        public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
        {
            private readonly IMemberDapperRepository _memberDapperReposiotry;

            public GetMembersQueryHandler(IMemberDapperRepository memberDapperReposiotry)
            {
                _memberDapperReposiotry = memberDapperReposiotry;
            }

            public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
            {
                var members = await _memberDapperReposiotry.GetMembers();
                return members;
            }
        }
    }
}
