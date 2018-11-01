using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
	public class DraculaKnives : ModItem
	{

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {

            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Melee/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            DisplayName.SetDefault("Dracula Knives");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
		{
            item.glowMask = customGlowMask;
            item.damage = 100;            
            item.melee = true;
            item.width = 32;
            item.height = 32;
			item.useTime = 8;
            item.maxStack = 999;
			item.useAnimation = 8;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.knockBack = 0;
			item.value = 8;
			item.rare = 6;
			item.shootSpeed = 15f;
			item.shoot = ProjectileID.VampireKnife;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(null, "EXSoul");
		    recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
		}
    }
}
