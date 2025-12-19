using System.Text;
using System.Text.Json;
using TheFinalBattle.DTO;
using TheFinalBattle.Levels;

namespace TheFinalBattle.Tests
{
    public class JsonParserTests
    {
        [Fact]
        public void Parse_JSONIsValid_ReturnLevels()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(LevelsJSONFormats.ValidFormat);
            MemoryStream stream = new MemoryStream(buffer);

            JsonParser parser = new JsonParser(stream);
            List<LevelDTO> levelsDTO = parser.Parse();

           
            Assert.IsType<List<LevelDTO>>(levelsDTO);
            Assert.Single(levelsDTO);
        }

        [Fact]
        public void Parse_JSONMissesOneAttribute_ThrowJSONException()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(LevelsJSONFormats.InvalidFormat);
            MemoryStream stream = new MemoryStream(buffer);

            JsonParser parser = new JsonParser(stream);

            Assert.Throws<JsonException>(parser.Parse);
        }
    }
}
