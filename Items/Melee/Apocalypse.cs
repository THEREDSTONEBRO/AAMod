using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class Apocalypse : ModItem
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
            item.glowMask = customGlowMask;
            DisplayName.SetDefault("Apocalypse");
            Tooltip.SetDefault("Horseman's Blade EX");
        }
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.TheHorsemansBlade);
			item.damage = 200;
			item.width = 54;
			item.height = 54;
			item.useTime = 17;
			item.useAnimation = 17;
			item.value = 1000000;
            item.expert = true;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TheHorsemansBlade);
			recipe.AddIngredient(mod, "EXSoul", 1);
			recipe.AddTile(null, "QuantumFusionAccelerator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 400);
        }
	}
}
