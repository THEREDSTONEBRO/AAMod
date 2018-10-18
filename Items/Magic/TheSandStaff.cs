using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace AAMod.Items.Magic
{
    public class TheSandStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 20;                        
            item.magic = true;                     //this make the item do magic damage
            item.width = 64;
            item.height = 64;

            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = 1;        //this is how the item is holded
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 1;
            item.mana = 9;             //mana use
            item.UseSound = SoundID.Item21;            //this is the sound when you use the item
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("TSSP");  //this make the item shoot your projectile
            item.shootSpeed = 5f;    //projectile speed when shoot
        }   

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Sand Staff");
      Tooltip.SetDefault("Its a sand staff.");
    }

		public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 20);   //you need 10 Wood
			recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}
