﻿using CleanArchCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRS.Domain.Abstractions
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMemberById(int memberId);
    }
}
