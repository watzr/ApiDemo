using Microsoft.EntityFrameworkCore;

namespace ModelsLibrary.YouTubeModels;

public partial class YouTubeAnalyzerContext : DbContext
{
    public YouTubeAnalyzerContext()
    {
    }

    public YouTubeAnalyzerContext(DbContextOptions<YouTubeAnalyzerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<YouTubeChannel> YouTubeChannels { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-O0JR452\\SQLEXPRESS;Initial Catalog=YouTubeAnalyzer;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.Etag)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Kind)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SnippetChannelId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SnippetChannelTitle)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SnippetDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SnippetPublishTime).HasColumnType("datetime");
            entity.Property(e => e.SnippetTitle)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.YouTubeChannel).WithMany(p => p.Items)
                .HasForeignKey(d => d.YouTubeChannelId)
                .HasConstraintName("FK_Item_Item");
        });

        modelBuilder.Entity<YouTubeChannel>(entity =>
        {
            entity.ToTable("YouTubeChannel");

            entity.Property(e => e.Etag)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Kind)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.RegionCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
