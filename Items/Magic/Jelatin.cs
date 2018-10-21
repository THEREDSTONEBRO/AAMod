using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace AAMod.Items.Magic
{
    public class Jelatin : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 71;                        
            item.magic = true;                     //this make the item do magic damage
            item.width = 38;
            item.height = 40;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;        //this is how the item is holded
            item.noMelee = true;
            item.knockBack = 4;        
            item.value = 1000;
            item.rare = 6;
            item.mana = 14;             //mana use
            item.UseSound = SoundID.Item21;            //this is the sound when you use the item
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("JP");  //this make the item shoot your projectile
            item.shootSpeed = 8f;    //projectile speed when shoot
        }   

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Jelly Maker");
      Tooltip.SetDefault("Shoots Jelly that fires projectiles at nearby enemies.");
    }

		public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Jelly", 25);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}
