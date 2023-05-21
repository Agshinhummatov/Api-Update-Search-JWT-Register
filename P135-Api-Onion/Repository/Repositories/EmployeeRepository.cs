using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Reflection;
using System;

namespace Repository.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(AppDbContext context) : base(context) { }

            
        


       
    }
}

