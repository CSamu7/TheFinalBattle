namespace TheFinalBattle
{
    public class EnemiesSubmenu : MenuTemplate<Entity>
    {
        protected override List<MenuItemAction<Entity>> Options { get; set ; }
        public EnemiesSubmenu(Entity entity, Party enemies)
        {
            //No es necesario la entidad aqui.
            Options = new MenuOptions(entity).GetEnemies(enemies);
            MenuTitle = "=========ENEMY PARTY========";
            InputText = "Enter the enemy to attack: ";
            
            IsSubmenu = true;
        }
        public Entity? SelectEnemy()
        {
            if (Options.Count == 1) return Options[0].Action;

            return GetOption();
        }
    }
}
