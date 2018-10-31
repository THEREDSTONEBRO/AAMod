using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class BreakingDawn : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Breaking Dawn");
        }

		public override void SetDefaults()
		{
            item.glowMask = customGlowMask;
			item.damage = 200;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 18;
            item.shoot = mod.ProjectileType("MorningStar");
            item.shootSpeed = 10f;
            item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 500000;
			item.UseSound = new LegacySoundStyle(2, 15, Terraria.Audio.SoundType.Sound);
			item.autoReuse = true;
            item.rare = 11;
		}


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RadiumBar", 15);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust dust;
            dust = Terraria.Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType<Dusts.StarDust>(), 0f, 0f, 46, default(Color), 1.25f);
			dust.noGravity = true;
        }
	}
}