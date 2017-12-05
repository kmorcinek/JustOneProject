using System.Collections.Generic;

namespace JustOneProject.Marek
{
    public class Parameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DesignParameters> DesignParameterses { get; set; }
    }
}