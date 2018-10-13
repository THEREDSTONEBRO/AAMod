using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    //imported from my tAPI mod because I'm lazy
    public class CyberneticBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cybernetic Bell");
            Tooltip.SetDefault(@"A carefully tinkered bell
Summons the Raider Ultima
Can only be used at night");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 38;
            item.maxStack = 20;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = true;
        }

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
        public override bool CanUseItem(Player player)
        {
            AAPlayer modPlayer = player.GetModPlayer<AAPlayer>(mod);
            return !NPC.AnyNPCs(mod.NPCType("Raider")) && modPlayer.ZoneInferno;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Raider"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "IncineriteBar", 6);
                recipe.AddIngredient(ItemID.LeadBar, 6);
                recipe.AddIngredient(null, "Abyssium", 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "IncineriteBar", 6);
                recipe.AddIngredient(ItemID.LeadBar, 6);
                recipe.AddIngredient(null, "Incinerite", 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
            }
        }
    }
}