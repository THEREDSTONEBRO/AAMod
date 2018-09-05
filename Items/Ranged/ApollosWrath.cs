using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Ranged
{
    public class ApollosWrath : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 140;
            item.noMelee = true;


            item.ranged = true;
            item.width = 24;
            item.height = 52;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.shoot = 294;
            item.knockBack = 2;
            item.value = 100;
            item.rare = 7;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 18f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Apollo's Wrath");
      Tooltip.SetDefault(@"Shoots Shadow beams
Doesn't use Ammo");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Apollo", 1);
            recipe.AddIngredient(ItemID.PulseBow, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
