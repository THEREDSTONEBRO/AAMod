using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    //imported from my tAPI mod because I'm lazy
    public class ZeroTesseract : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ERROR:NULL");
            Tooltip.SetDefault(@"DESCRIPTI0NHERE
UNSTABLE. C0NTAINS C0DE TO ACTIVATE THE BRINGER 0F DEATH");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 38;
            item.rare = 11;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(120, 0, 30);
                }
            }
        }

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
        public override bool CanUseItem(Player player)
        {
            AAPlayer modPlayer = player.GetModPlayer<AAPlayer>(mod);
            return modPlayer.ZoneVoid && !NPC.AnyNPCs(mod.NPCType("Zero")) && !NPC.AnyNPCs(mod.NPCType("ZeroAwakened")) && modPlayer.ZoneVoid;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Zero"));
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Sounds/ZeroDeath"));
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ApocalyptitePlate", 15);
            recipe.AddIngredient(null, "DarkMatter", 20);
            recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}