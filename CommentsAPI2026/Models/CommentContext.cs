using Microsoft.EntityFrameworkCore;
namespace CommentsAPI2026.Models;

public class CommentContext(DbContextOptions<CommentContext> options) : DbContext(options)
{
    public DbSet<CommentItem> CommentItems { get; set; } = null!;
}