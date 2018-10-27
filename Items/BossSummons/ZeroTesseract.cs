using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.BossSummons
{
    //imported from my tAPI mod because I'm lazy
    public class ZeroTesseract : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/BossSummons/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            item.glowMask = customGlowMask;
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
            return modPlayer.ZoneVoid && !NPC.AnyNPCs(mod.NPCType("Zero")) && !NPC.AnyNPCs(mod.NPCType("ZeroAwakened"));
        }

        public override bool UseItem(Player player)
        {
            if (!AAWorld.downedZero && Main.expertMode)
            {
                Main.NewText("ZER0 UNIT ACTIVATED. ENGAGE D00MBRINGER PR0T0C0L.", Color.Red.R, Color.Red.G, Color.Red.B);
            }

            if (!AAWorld.downedZeroA && Main.expertMode)
            {
                Main.NewText("ZER0 UNIT ACTIVATED. ENGAGE D00MBRINGER PR0T0C0L.", Color.Red.R, Color.Red.G, Color.Red.B);
            }
            if (!Main.expertMode && AAWorld.downedZero)
            {
                Main.NewText("TARGET L0CKED. FAILURE T0 TERMINATE Y0U IS N0T A P0SSIBILITY THIS TIME, TERRARIAN.", Color.Red.R, Color.Red.G, Color.Red.B);
            }
            if (Main.expertMode && AAWorld.downedZeroA)
            {
                Main.NewText("TARGET L0CKED. FAILURE T0 TERMINATE Y0U IS N0T A P0SSIBILITY THIS TIME, TERRARIAN.", Color.Red.R, Color.Red.G, Color.Red.B);
            }


            NPC.NewNPC((int)player.position.X + Main.rand.Next(-1200, 1200), (int)player.position.Y + Main.rand.Next(-1100, -350), mod.NPCType("Zero"));
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Sounds/Glitch"));
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