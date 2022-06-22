using FluentAssertions;
using System.Text;

namespace Calastone.Test.Unit
{    
    public class TextFilterServiceTests
    {
        private readonly StringBuilder _fileContents;
  
        public TextFilterServiceTests()
        {
            _fileContents = new StringBuilder();                           
        }

        [Theory]
        [InlineData($" What ", $" ")]
        [InlineData($" currently ", $" ")]
        [InlineData($" clean ", $" ")]
        [InlineData($" here ", $" here ")]
        [InlineData($" Sync ", $" Sync ")]
        public void ApplyVowelFiltersReturnsValidText(string fileContent, string expectedResult)
        {
            // Arrange
            var fileContents = new StringBuilder();
            fileContents.Append(fileContent);    

            //Act 
            var sut = new TextFilterService();
            sut.ApplyFilters(fileContents);
            var resutls = fileContents.ToString();
            
            //Assert
            resutls.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData($" c ", $" ")]
        [InlineData($" cc ", $" ")]
        [InlineData($" ccc ", $" ccc ")]
        public void ApplyLenthFiltersReturnsValidText(string fileContent, string expectedResult)
        {
            // Arrange
            var fileContents = new StringBuilder();
            fileContents.Append(fileContent);

            //Act 
            var sut = new TextFilterService();
            sut.ApplyFilters(fileContents);
            var resutls = fileContents.ToString();

            //Assert
            resutls.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData($" rather ", $" ")]
        [InlineData($" bit ", $" ")]
        [InlineData($" Teach ", $" ")]
        [InlineData($" Lynx ", $" Lynx ")]
        public void ApplyTFiltersReturnsValidText(string fileContent, string expectedResult)
        {
            // Arrange
            var fileContents = new StringBuilder();
            fileContents.Append(fileContent);

            //Act 
            var sut = new TextFilterService();
            sut.ApplyFilters(fileContents);
            var resutls = fileContents.ToString();

            //Assert
            resutls.Should().Be(expectedResult);
        }

        [Fact]
        public void ApplyFiltersOnFileReturnsValidText()
        {
            // Arrange
            TestDataBuilder.BuildFileData(_fileContents);
            var expectedResult = $"Alice beginning bank, and do: once she reading, it, 'and use book,' Alice 'without conversation?'So she considering own (as she could, made and stupid), pleasure and picking daisies, eyes close her.There remarkable that; Alice itself, 'Oh dear! dear! late!' (when she over afterwards, occurred she have this, all natural); pocket, and it, and hurried on, Alice feet, flashed across she never before pocket, it, and burning curiosity, she across it, and see large hole under hedge.In Alice it, never once considering world she again.The hole like some way, and dipped down, Alice herself before she herself falling well.Either deep, she slowly, she she and wonder happen next. First, she and make she to, see anything; she sides well, and were filled and shelves; here and she and upon pegs. She one shelves she passed; `ORANGE MARMALADE', empty: she like killing somebody, one she it.";

            //Act 
            var sut = new TextFilterService();
            sut.ApplyFilters(_fileContents);
            var resutls = _fileContents.ToString();

            //Assert
            resutls.Should().Be(expectedResult);
        }
    }
}