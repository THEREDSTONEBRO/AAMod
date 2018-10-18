using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee   //where is located
{
    public class TrueBeekeeper : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 40;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 50;              //Sword width
            item.height = 52;             //Sword height

            item.useTime = 30;          //how fast 
            item.useAnimation = 30;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 5;      //Sword knockback
            item.value = 10;        
            item.rare = 5;
            item.UseSound = SoundID.Item1;       //1 is the sound of the sword
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = false;
			item.shoot = 181;
			item.shootSpeed = 9f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("True Beekeeper");
      Tooltip.SetDefault("Shoots bees when swung!");
    }

        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(ItemID.BeeKeeper, 1);
			recipe.AddIngredient(ItemID.Starfury, 1);   //you need 1 DirtBlock
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
