﻿using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class NewAccountService : INewAccountService
    {
        private readonly INewAccountRepository repository;
        public NewAccountService(INewAccountRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateAccount(NewAccountModel model)
        {
            var entity = new NewAccountEntity
            {
                Id = model.Id,
                ClassId = model.ClassId,
                FileId = model.FileId
            };
            await repository.CreateAccount(entity);
            return model.Id;
        }
        public async Task<IEnumerable<NewAccountModel>> GetAccountsByFileId(int id)
        {
            var list = await repository.GetAccountsByFileId(id);
            return list.Select(x => new NewAccountModel
            {
                Id = x.Id,
                ClassId = x.ClassId,
                FileId = x.FileId
            }).ToList();
        }
        public async Task<IEnumerable<NewAccountModel>> GetAllAccounts()
        {
            var list = await repository.GetAllAccounts();
            return list.Select(a => new NewAccountModel
            {
                Id = a.Id,
                ClassId = a.ClassId,
                FileId = a.FileId
            });
        }
    }
}
