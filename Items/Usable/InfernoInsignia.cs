using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    public class InfernoInsignia : ModItem
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
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Usable/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            item.glowMask = customGlowMask;
            DisplayName.SetDefault("Scorched Insignia");
            Tooltip.SetDefault("Breaking this tablet releases a raging chaos upon your world");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("InfernoProj");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Torchstone", 50);
            recipe.AddIngredient(null, "Incinerite", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}