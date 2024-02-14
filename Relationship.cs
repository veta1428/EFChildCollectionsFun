namespace EChildCollectionsFun;

internal class Relationship : Entity
{
    public int PersonOneId { get; set; }

    public int PersonAnotherId { get; set; }

    public int RelatioshipTypeId { get; set; }

    public RelationshipType? RelationshipType { get; set; }
}
