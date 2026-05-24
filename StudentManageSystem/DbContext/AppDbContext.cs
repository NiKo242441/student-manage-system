using Microsoft.EntityFrameworkCore;
using StudentManageSystem.Entity;

namespace StudentManageSystem.Context
{
    public class AppDbContext:DbContext
    {
        // 通过此类访问数据库
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
