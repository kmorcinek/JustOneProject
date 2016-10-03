using System.Collections.Generic;
using System.Linq;

namespace JustOneProject.VariousStuff.ExampleEnums
{
    public static class UnitConverter
    {
        static readonly Dictionary<string, Unit> Units;
        static readonly Dictionary<Unit, string> InvertedUnits;

        static UnitConverter()
        {
            Units = new Dictionary<string, Unit>
            {
                {"PC", Unit.Pieces},
                {"M", Unit.Meters},
                {"KG", Unit.Kilograms},
            };

            InvertedUnits = Units.ToDictionary(x => x.Value, x => x.Key);
        }

        public static Option<Unit> Convert(string unit)
        {
            var uppercaseUnit = (unit ?? "").ToUpperInvariant();

            Unit value;
            if (Units.TryGetValue(uppercaseUnit, out value))
            {
                return value;
            }

            return Option<Unit>.None;
        }

        public static string ConvertToString(Unit Unit)
        {
            return InvertedUnits[Unit];
        }
    }

}