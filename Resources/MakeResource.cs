using System.Collections.Generic;
using Vega.Domain;

namespace Vega.Resources
{
    public class MakeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}