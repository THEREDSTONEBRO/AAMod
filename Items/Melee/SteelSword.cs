using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee   //where is located
{
    public class SteelSword : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 19;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 34;              //Sword width
            item.height = 40;             //Sword height

            item.useTime = 25;          //how fast 
            item.useAnimation = 25;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 5;      //Sword knockback
            item.value = 4;        
            item.rare = 1;
            item.UseSound = SoundID.Item1;       //1 is the sound of the sword
            item.autoReuse = false;   //if it's capable of autoswing.
            item.useTurn = false;               
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Steel Sword");
      Tooltip.SetDefault("I dont think copper and iron gives steel");
    }

        public override void AddRecipes()  //How to craft this sword
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 15);   //you need 1 DirtBlock
                recipe.AddIngredient(ItemID.CopperBar, 10);
                recipe.AddTile(TileID.Anvils);   //at work bench
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 15);   //you need 1 DirtBlock
                recipe.AddIngredient(ItemID.TinBar, 10);
                recipe.AddTile(TileID.Anvils);   //at work bench
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 15);   //you need 1 DirtBlock
                recipe.AddIngredient(ItemID.CopperBar, 10);
                recipe.AddTile(TileID.Anvils);   //at work bench
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 15);   //you need 1 DirtBlock
                recipe.AddIngredient(ItemID.TinBar, 10);
                recipe.AddTile(TileID.Anvils);   //at work bench
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
