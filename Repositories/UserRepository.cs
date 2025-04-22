using Microsoft.EntityFrameworkCore;
using NetStock.config;
using NetStock.Entities;

namespace NetStock.Repositories{

    public class UserRepository:IUserRepository{

        private readonly ContextNetStockDb context;
        public UserRepository(ContextNetStockDb _context){
            
            this.context = _context;
        }

    public async Task<IEnumerable<User>> GetAllAsync()=>

         await this.context.Users.ToListAsync();

    


    public async Task<User> GetByIdAsync(int id)=>
        await this.context.Users.FindAsync(id);
         
    
    public async Task<User> GetByEmailAsync(string email)=>

        await this.context.Users.FirstOrDefaultAsync(u=>u.Email == email);

    public async Task AddAsync(User user){
      this.context.Add(user);  
      await this.context.SaveChangesAsync();
    }




    public async Task UpdateAsync(User user){
        this.context.Users.Update(user);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id){
        var user = this.context.Users.Find(id);
        if(user is null)
            return ;
        

        this.context.Users.Remove(user);
        await this.context.SaveChangesAsync();

    }


    
}}