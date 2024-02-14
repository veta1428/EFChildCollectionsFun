using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EChildCollectionsFun;
internal class MyContext : DbContext
{
    public MyContext()
    {
        Database.Migrate();
        ChangeTracker.StateChanging += ChangeTracker_StateChanging;
        ChangeTracker.StateChanged += ChangeTracker_StateChanged;
        ChangeTracker.Tracking += ChangeTracker_Tracking;
        ChangeTracker.Tracked += ChangeTracker_Tracked;

    }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<PersonCourse> PersonCourses { get; set; }

    public DbSet<Relationship> Relationships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Server=LIZAXPS\\MSSQLSERVER01;Database=test-collections;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=True;");

    private void ChangeTracker_Tracking(object? sender, EntityTrackingEventArgs e)
    {
        Console.WriteLine(sender);
    }

    private void ChangeTracker_Tracked(object? sender, EntityTrackedEventArgs e)
    {
        Console.WriteLine(sender);
    }

    private void ChangeTracker_StateChanging(object? sender, EntityStateChangingEventArgs e)
    {
        Console.WriteLine(sender);
    }

    private void ChangeTracker_StateChanged(object? sender, EntityStateChangedEventArgs e)
    {
        Console.WriteLine(sender);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // PersonCourse  
        modelBuilder
            .Entity<PersonCourse>()
            .ToTable(nameof(PersonCourse));

        modelBuilder
            .Entity<PersonCourse>()
            .HasKey(map => new { map.PersonId, map.CourseId });

        modelBuilder
            .Entity<PersonCourse>()
            .HasOne(map => map.Person)
            .WithMany(person => person.Courses)
            .HasForeignKey(map => map.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<PersonCourse>()
            .HasOne(map => map.Course)
            .WithMany()
            .HasForeignKey(map => map.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Person
        modelBuilder
            .Entity<Person>()
            .HasMany<Person>()
            .WithMany()
            .UsingEntity<Relationship>(
        l => l
            .HasOne<Person>()
            .WithMany(x => x.RelationshipOnes)
            .HasForeignKey(x => x.PersonOneId)
            .OnDelete(DeleteBehavior.Restrict),
        r => r
            .HasOne<Person>()
            .WithMany(x => x.RelationshipAnothers)
            .HasForeignKey(x => x.PersonAnotherId)
            .OnDelete(DeleteBehavior.Restrict));

        // Relationship
        modelBuilder
            .Entity<Relationship>()
            .HasOne(x => x.RelationshipType)
            .WithMany()
            .HasForeignKey(x => x.RelatioshipTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
