

using DataAccessLayer.PersistenceModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{

    /// <summary> The DB context class which will interact with Entity Framework. 
    /// Although set to public (due to the accessibility level of the UnitOfWork), this class should be treated as internal and not accessed outside of the bounds of the DataAccessLayer </summary>
    public partial class StackOverflowAppContext: DbContext
    {

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Bookmark> Bookmark { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostComment> PostComment { get; set; }
        public virtual DbSet<PostLink> PostLink { get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }
        public virtual DbSet<PostType> PostType { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<SearchHistory> SearchHistory { get; set; }
        public virtual DbSet<StackOverflowUser> StackOverflowUser { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<UserSearchHistory> UserSearchHistory { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=wt-220.ruc.dk;database=raw4;user=ccsousa;password=ccsousa_760;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.HasIndex(e => e.ParentId)
                    .HasName("parent_id");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcceptedAnswer)
                    .HasColumnName("accepted_answer")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Editable)
                    .HasColumnName("editable")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("Answer_ibfk_2");
            });

            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId });

                entity.HasIndex(e => e.PostId)
                    .HasName("post_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Bookmark)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookmark_ibfk_4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookmark)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookmark_ibfk_3");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AppLocation)
                    .IsRequired()
                    .HasColumnName("app_location")
                    .HasMaxLength(100);

                entity.Property(e => e.DateOccurred)
                    .HasColumnName("date_occurred")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeveloperComment)
                    .HasColumnName("developer_comment")
                    .HasColumnType("tinytext");

                entity.Property(e => e.ExceptionMessage)
                    .HasColumnName("exception_message")
                    .HasColumnType("text");

                entity.Property(e => e.ExceptionStacktrace)
                    .HasColumnName("exception_stacktrace")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId });

                entity.HasIndex(e => e.PostId)
                    .HasName("post_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Note_ibfk_4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Note_ibfk_3");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.PostType)
                    .HasName("post_type");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostType)
                    .HasColumnName("post_type")
                    .HasMaxLength(25);

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PostTypeNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.PostType)
                    .HasConstraintName("Post_ibfk_4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Post_ibfk_3");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.ToTable("Post_Comment");

                entity.HasIndex(e => e.PostId)
                    .HasName("post_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComment)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("Post_Comment_ibfk_4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostComment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Post_Comment_ibfk_3");
            });

            modelBuilder.Entity<PostLink>(entity =>
            {
                entity.HasKey(e => new { e.DuplicatedPostId, e.ReferencePostId });

                entity.ToTable("Post_Link");

                entity.Property(e => e.DuplicatedPostId)
                    .HasColumnName("duplicated_post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferencePostId)
                    .HasColumnName("reference_post_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.DuplicatedPost)
                    .WithMany(p => p.PostLink)
                    .HasForeignKey(d => d.DuplicatedPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Post_Link_ibfk_2");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(e => new { e.TagName, e.PostId });

                entity.ToTable("Post_Tag");

                entity.HasIndex(e => e.PostId)
                    .HasName("post_id");

                entity.Property(e => e.TagName)
                    .HasColumnName("tag_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Post_Tag_ibfk_4");

                entity.HasOne(d => d.TagNameNavigation)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.TagName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Post_Tag_ibfk_3");
            });

            modelBuilder.Entity<PostType>(entity =>
            {
                entity.HasKey(e => e.TypeName);

                entity.ToTable("Post_Type");

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClosedDate)
                    .HasColumnName("closed_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Editable)
                    .HasColumnName("editable")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.WasEdited)
                    .HasColumnName("was_edited")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Post)
                    .WithOne(p => p.Question)
                    .HasForeignKey<Question>(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Question_ibfk_2");
            });

            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.HasKey(e => e.InputText);

                entity.ToTable("Search_History");

                entity.Property(e => e.InputText)
                    .HasColumnName("input_text")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<StackOverflowUser>(entity =>
            {
                entity.ToTable("StackOverflow_User");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagName);

                entity.Property(e => e.TagName)
                    .HasColumnName("tag_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserSearchHistory>(entity =>
            {
                entity.HasKey(e => new { e.SearchText, e.UserId, e.CreationDate });

                entity.ToTable("User_Search_History");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.SearchText)
                    .HasColumnName("search_text")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.SearchTextNavigation)
                    .WithMany(p => p.UserSearchHistory)
                    .HasForeignKey(d => d.SearchText)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Search_History_ibfk_3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSearchHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Search_History_ibfk_4");
            });
        }


    }

}
