/*using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class StraightYari : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 27;
            item.melee = true;
            item.width = 90;
            item.height = 90;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 27;
            item.useAnimation = 27;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
			item.autoReuse = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.shoot = mod.ProjectileType("StraightYariP");  //put your Spear projectile name
            item.shootSpeed = 5f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Straight Yari");
      Tooltip.SetDefault("");
    }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarcloudBar", 12);   //you need 1 DirtBlock
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
*/