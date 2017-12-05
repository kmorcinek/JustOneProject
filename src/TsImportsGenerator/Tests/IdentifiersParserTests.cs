using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace JustOneProject.TsImportsGenerator.Tests
{
    public class IdentifiersParserTests
    {
        [Fact]
        public void Test()
        {
            string content = @"
    export class AssemblyMarkingNavigationService {
        constructor(
            private assemblyMarkingService: AssemblyMarkingService
        ) {
        }

        navigate(component: ComponentViewModel) {
            let articleLinkId = this.assemblyMarkingService.getMarkedArticleLinkId(component);

            let elementId = AssemblyMarkingNavigationService.getElementIdForFindingNodes(articleLinkId);
            
            TreeGridService.scrollTreeViewToElement(elementId);
        }

        static getElementIdForFindingNodes(articleLinkId: Guid) {
            return 'article-link-id-' + articleLinkId;
        }
        
    }";

            string[] expectedToContain = { "AssemblyMarkingService", "ComponentViewModel", "Guid", "TreeGridService" };

            string[] allIdentifiers = IdentifiersParser.GetWords(content);

            foreach (string word in expectedToContain)
            {
                allIdentifiers.Should().Contain(word);
            }
        }

        [Fact]
        public void EasyTest()
        {
            string content = @"ala;ma kota";

            string[] expectedToContain = { "ala", "ma", "kota" };

            string[] allIdentifiers = IdentifiersParser.GetWords(content);

            foreach (string word in expectedToContain)
            {
                allIdentifiers.Should().Contain(word);
            }
        }

        [Fact]
        public void Should_not_return_duplicates()
        {
            string content = @"ala;ma kota ala";

            // When
            string[] allIdentifiers = IdentifiersParser.GetWords(content);

            // Then
            IEnumerable<string> withoutDuplicates = allIdentifiers.Distinct();

            allIdentifiers.Length.Should().Be(withoutDuplicates.Count());
        }

        [Fact]
        public void Should_parse_vm_as_array_defintion()
        {
            string content = @"ng.IPromise<SynchronizationLogViewModel[]>";

            // When
            string[] allIdentifiers = IdentifiersParser.GetWords(content);

            allIdentifiers.Should().Contain("SynchronizationLogViewModel");
        }
    }
}