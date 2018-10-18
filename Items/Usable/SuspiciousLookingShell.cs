using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    public class SuspiciousLookingShell : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.maxStack = 999;

            item.value = 1;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Suspicious Looking Shell");
      Tooltip.SetDefault(@"Spawns the Icegrim
Only Usable at night");
    }

        public override bool CanUseItem(Player player)
        {           
            return !NPC.AnyNPCs(mod.NPCType("TheIcegrim")) && !Main.dayTime;
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TheIcegrim"));   //boss spawn
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 20);
			recipe.AddIngredient(ItemID.SnowBlock, 30);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
