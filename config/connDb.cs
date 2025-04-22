using Microsoft.EntityFrameworkCore;
using NetStock.Entities;

namespace NetStock.config{
    public class ContextNetStockDb:DbContext{

        public ContextNetStockDb(DbContextOptions<ContextNetStockDb> options):base(options){}

        public DbSet<Categories>Categories{get;set;}

        public DbSet<User>Users{get;set;}

        public DbSet<Products>Products{get;set;}



    }
}