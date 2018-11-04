using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AAMod.NPCs.Bosses.Akuma;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AAMod.Items.BossSummons
{
    public class DraconianRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draconian Sun Rune");
            Tooltip.SetDefault(@"An enchanted tablet bursting with flaming chaotic energy
Summons Akuma Awakened
Only Usable during the day");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 28;
            item.rare = 2;
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
                    line2.overrideColor = new Color(180, 41, 32);
                }
            }
        }


        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType<Akuma>()) && Main.dayTime && !NPC.AnyNPCs(mod.NPCType<AkumaA>());
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("Cutting right to the chase I see..? Alright then, prepare for hell..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            NPC.NewNPC((int)player.position.X + Main.rand.Next(-2000, 2000), (int)player.position.Y + Main.rand.Next(2000, 2000), mod.NPCType<AkumaA>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            if (Main.expertMode)
            { 
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "CrucibleScale", 20);
                recipe.AddIngredient(null, "DraconianSigil");
                recipe.AddTile(null, "QuantumFusionAccelerator");
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
            }
        }
    }
}