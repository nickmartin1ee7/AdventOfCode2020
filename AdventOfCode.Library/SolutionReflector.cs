using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Library
{
    public static class SolutionReflector
    {
        public static IEnumerable<Type> ReflectEverySolutionType() =>
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISolution)
                                .IsAssignableFrom(x) &&
                            !x.IsInterface &&
                            !x.IsAbstract)
                .OrderBy(x => x.Name);
    }
}
