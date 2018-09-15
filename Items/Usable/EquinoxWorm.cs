using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    //imported from my tAPI mod because I'm lazy
    public class EquinoxWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EquinoxWorm");
            Tooltip.SetDefault(@"Brings forth the serpents of the celestial heavans");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 28;
            item.maxStack = 20;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("Nightcrawler")) && !NPC.AnyNPCs(mod.NPCType("Daybringer"));
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Nightcrawler"));
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Daybringer"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalWorm, 2);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}