namespace TheFinalBattle
{
    public class ConfigParty
    {
        private readonly PartyControlValidator _partyValidator = new PartyControlValidator();
        public Party CreateParty(string message)
        {
            while (true)
            {
                Console.Write(message);
                string inputAI = Console.ReadLine();
                IPartyControl ai = _partyValidator.Validate(inputAI);

                if (ai != null) return new Party(ai);
            }
        }
    }
}
