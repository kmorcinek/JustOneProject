using FluentAssertions;
using Xunit;

namespace JustOneProject.TsImportsGenerator.Tests
{
    public class RetrieveClassNameTests
    {
        [Fact]
        public void For_class_test()
        {
            string content = @"
    export class AssemblyMarkingNavigationService {
        constructor(
            private assemblyMarkingService: AssemblyMarkingService
        ) {
        }";

            string expected = "AssemblyMarkingNavigationService";

            RetrieveClassName.GetClassName(content).Should().Be(expected);
        }

        [Fact]
        public void For_interface_test()
        {
            string content = @"
    export interface ISpecificShape {
        isMachined(articleDimensions: ShapeWithDimensionsViewModel, materialDimensions: ShapeWithDimensionsViewModel) : boolean;
        }";

            string expected = "ISpecificShape";

            RetrieveClassName.GetClassName(content).Should().Be(expected);
        }
    }
}