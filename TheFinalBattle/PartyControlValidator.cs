using Utils;

namespace TheFinalBattle
{
    public class PartyControlValidator
    {
        public IPartyControl? Validate(string input)
        {
            return input.Clean() switch
            {
                "pc" => new PartyAI(),
                "human" => new PartyHuman(),
                _ => null,
            };
        }
    }
}