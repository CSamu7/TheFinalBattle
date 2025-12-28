using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayableClasses.Heroes;
using TheFinalBattle.UI;
using Utils;

namespace TheFinalBattle
{
    public class Game
    {
        public void Start()
        {
            var settings = new GameSettingsUI().GetSettings(); //Conseguir la configuración global del juego

            //Formación de los equipos. Tal vez GetHeroesParty(). Quein sabe.
            string name = ConsoleUtils.GetInput("Enter your name, hero: ");
            name = name == String.Empty ? "A hero with no name" : name;

            Entity player = new Protagonist(name); // Conseguir al jugador
            //Una clase que se encargue de esto?. Aunque me parece muy poco codigo para una clase. Si tuvieramos
            //que configurar mas cosas lo veria mas viable.
            Party heroes = new Party(settings.PartySettings.HeroePartyAI); //Construye el equipo del jugador.
            heroes.Inventory.AddItem(new Medicine(), 3);
            heroes.AddMembers(player);

            //Aqui ya estamos mandando los niveles construidos.
            Battles battles = new Battles(settings);
            battles.Start(heroes);
        }
    }
}
