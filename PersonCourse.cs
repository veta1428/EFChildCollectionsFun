namespace EChildCollectionsFun;
internal class PersonCourse
{
    public int PersonId { get; set; }

    public int CourseId { get; set; }

    public Person Person { get; set; } = null!;

    public Course Course { get; set; } = null!;

    //public override int GetHashCode() => CourseId;
}
