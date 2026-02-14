namespace TheFinalBattle.Tests
{
    public class LevelsJSONFormats
    {
        public static string ValidFormat = "[{\"enemies\": [\n" +
                "{\n\"name\": \"Pixie\", " +
                "\n\"defensiveModifier\": \"AtiumBead\"," +
                "\n\"gear\": \"Gun\"\n}\n],\n" +
                "\"enemyInventory\": [\n" +
                "   {\n" +
                "    \"name\": \"DASDAS\",\n" +
                "   \"amount\": 2\n" +
                "   },\n " +
                "   {" +
                "       \"name\": \"ShortGun\",\n" +
                "       \"amount\": 1\n}\n" +
                "],\n" +
                "\"rewards\": [\n" +
                "{\n\"name\": \"Medicine\",\n " +
                "\"amount\": 2\n      }\n    ]\n  }\n]";

        public static string InvalidFormat = "[{\"enemies\": [\n" +
              "{\n\"name\": \"Pixie\", " +
              "\n\"defensiveModifier\": \"AtiumBead\"," +
              "\n\"gear\": \"Gun\"\n}\n],\n" +
              "\"enemyInventory\": [\n" +
              "   {\n" +
              "    \"name\": \"DASDAS\",\n" +
              "   \"amount\": 2\n" +
              "   },\n " +
              "   {" +
              "       \"name\": \"ShortGun\",\n" +
              "       \"amount\": 1\n}\n" +
              "],\n";
    }
}
