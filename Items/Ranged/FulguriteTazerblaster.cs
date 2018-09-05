using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.Items.Ranged
{
	public class FulguriteTazerblaster : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Fulgurite Tazerblaster");
            Tooltip.SetDefault("Rapidly fires taserblasts");
		}

		public override void SetDefaults()
		{
			item.damage = 38;
			item.magic = true;
			item.mana = 6;
			item.width = 52;
			item.height = 18;
            item.useAnimation = 12;
            item.useTime = 12;
            item.reuseDelay = 2;
            item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2.5f;
            item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Taserblast");
            item.shootSpeed = 17f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
        public override void AddRecipes()
        {                                                   //How to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FulguriteBar", 20);              //example of how to craft with a modded item
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}