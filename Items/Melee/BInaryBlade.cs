using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;//<---This
using Microsoft.Xna.Framework.Graphics;//<---and this are used by the glowmask code.

namespace AAMod.Items.Melee
{
	public class BinaryBlade : ModItem
	{
		public static short customGlowMask = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Binary Blade");//<--- Item name here
			Tooltip.SetDefault(@"I will swear word you
-Glitched");
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
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(247, 0, 42);
                }
            }
        }
        public override void SetDefaults()
		{
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.useStyle = 1;
			item.damage = 235;
			item.useAnimation = 12;
			item.useTime = 12;
			item.width = 62;
			item.height = 74;
			item.shoot = ProjectileID.TerraBeam;
			item.shootSpeed = 18f;
			item.knockBack = 7f;
			item.melee = true;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.autoReuse = true;
			item.crit = 8;
			item.glowMask = customGlowMask;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

