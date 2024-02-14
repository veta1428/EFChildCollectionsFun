namespace EChildCollectionsFun;

internal class Person : Entity
{
    public int Age { get; set; }

    public string Name { get; set; } = null!;

    public HashSet<PersonCourse> Courses { get; set; } = new();

    public HashSet<Relationship> RelationshipOnes { get; set; } = new();

    public HashSet<Relationship> RelationshipAnothers { get; set; } = new();
}
