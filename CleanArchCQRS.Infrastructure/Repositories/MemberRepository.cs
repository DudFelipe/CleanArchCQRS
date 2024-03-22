using CleanArchCQRS.Domain.Abstractions;
using CleanArchCQRS.Domain.Entities;
using CleanArchCQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRS.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberById(int memberId)
        {
            var member = await _context.Members.FindAsync(memberId);

            if(member is null)
                throw new InvalidOperationException("Member not found");

            return member;
        }

        public async Task<Member> AddMember(Member member)
        {
            if(member is null)
                throw new ArgumentNullException(nameof(member));

            await _context.Members.AddAsync(member);
            return member;
        }

        public void UpdateMember(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            _context.Members.Update(member);
        }

        public async Task<Member> DeleteMember(int memberId)
        {
            var member = await _context.Members.FindAsync(memberId);

            if (member is null)
                throw new InvalidOperationException("Member not found");

            _context.Members.Remove(member);
            return member;
        }
    }
}
