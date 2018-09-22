using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Retriever
{
    [AutoloadEquip(EquipType.Shield)]
    public class StormRiot : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = -12;
            item.expert = true;
            item.accessory = true;
            item.defense = 6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Riot Shield");
            Tooltip.SetDefault(
@"For every hit you land on an enemy, 45 true damage (damage unassigned to any class) is dealt
Allows you to dash into enemies, damaging them
Non-autoswing weapons can be swung faster");
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<AAPlayer>().clawsOfChaos = true;
            player.GetModPlayer<AAPlayer>().StormClaw = true;
            player.dash = 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BulwarkOfChaos", 1);
            recipe.AddIngredient(null, "StormClaw", 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}