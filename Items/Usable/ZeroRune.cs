using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    //imported from my tAPI mod because I'm lazy
    public class ZeroRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("0");
            Tooltip.SetDefault(@"ACTIVATES THE GR0UND ZER0 C0DE F0R THE NEAREST ZER0 UNIT");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
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
            return modPlayer.ZoneVoid && !NPC.AnyNPCs(mod.NPCType("Zero")) && !NPC.AnyNPCs(mod.NPCType("ZeroAwakened")) && Main.expertMode;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("ZeroAwakened"));
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Sounds/ZeroDeath"));
            return true;
        }

        public override void AddRecipes()
        {
            if (Main.expertMode == true)
            { 
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ApocalyptitePlate", 10);
            recipe.AddIngredient(null, "UnstableSingularity", 10);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            }
        }
    }
}