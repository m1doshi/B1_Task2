﻿using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IClassService
    {
        Task<int> CreateClass(ClassModel model);
        Task<IEnumerable<ClassModel>> GetAllClasses();
        Task<ClassModel> GetClassById(int id);
        Task<ClassModel> GetClassByName(string name);
        Task<ClassModel> GetLastClass();
    }
}