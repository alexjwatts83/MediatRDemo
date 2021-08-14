﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatRDemo.Domain.Entities;

namespace MediatRDemo.Application.Interfaces
{
    public interface IGenericCrudRepositoryScripts
    {
        public string GetByIdAsyncSql { get; }
        public string GetAllAsyncSql { get; }
        public string AddAsyncSql { get; }
        public string UpdateAsyncSql { get; }
        public string DeleteAsyncSql { get; }
    }
}
