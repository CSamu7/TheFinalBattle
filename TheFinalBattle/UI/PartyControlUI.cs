using TheFinalBattle.Parties;
using Utils;

namespace TheFinalBattle.UI
{
    public class PartyControlUI()
    {
        public IPartyControl GetPartyAI(string message)
        {
            while (true)
            {
                string inputAI = ConsoleUtils.GetInput(message);

                if (inputAI == "pc") return new PartyAI();
                else if (inputAI == "human") return new PartyHuman();

                ConsoleUtils.Error("You have to enter pc or human.");
            }
        }
    }
}
