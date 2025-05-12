using Microsoft.EntityFrameworkCore;
using th4.Domain.Models;

namespace th4.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Stock> Stocks { get; set; } 
        public DbSet<Comments> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Stock)
                .HasForeignKey(c => c.StockId);

            modelBuilder.Entity<Comments>()
                .HasKey(c => c.Id);           //Khai báo Id là khóa chính của bảng Comments.

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Stock)                     //Mỗi Comment liên kết đến một Stock(cổ phiếu).
                .WithMany(s => s.Comments)                //Một Stock có thể có nhiều Comments.
                .HasForeignKey(c => c.StockId)            //Nếu Stock bị xóa → các comment liên quan cũng bị xóa(Cascade Delete).
                .OnDelete(DeleteBehavior.Cascade);         
                                                                                              

        }
    }
    
}
