﻿using BetelgeuseAPI.Application.Repositories.User;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.User;

public class UserWriteRepository:WriteRepository<BetelgeuseAPIDbContext,Domain.Entities.User>,IUserWriteRepository
{
    public UserWriteRepository(BetelgeuseAPIDbContext context) : base(context)
    {
    }
}