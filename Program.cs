using Microsoft.EntityFrameworkCore;

namespace EChildCollectionsFun;

internal class Program
{
    static void Main(string[] args)
    {
        using var ctx = new MyContext();
        var person = ctx.Persons
            .Where(p => p.Id == 1)
            .Include(p => p.Courses)
            .Include(p => p.RelationshipOnes)
            .Include(p => p.RelationshipAnothers)
            .Single();

        //person.Courses.Remove(person.Courses.First());
        //person.RelationshipOnes.Remove(person.RelationshipOnes.First());
        ctx.SaveChanges();
    }
}
