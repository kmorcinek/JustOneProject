using System.Collections.Generic;
using System.Linq;

namespace JustOneProject.Marek
{
    public class Runner
    {
        public static IEnumerable<DesignParameters> Do(
            IEnumerable<DesignParameters> designParameterses,
            string parameterNames)
        {
            return designParameterses.Where(x => x.Parameter.Name == parameterNames)
                .GroupBy(x => x.ParameterId)
                .Select(x => x.OrderBy(y => y.RevisionId).First())
                .ToList();
        }
    }
}