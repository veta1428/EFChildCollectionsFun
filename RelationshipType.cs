using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChildCollectionsFun;
internal class RelationshipType : Entity
{
    public string Name { get; set; } = null!;
}
