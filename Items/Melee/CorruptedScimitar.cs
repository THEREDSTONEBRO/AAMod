using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee   //where is located
{
    public class CorruptedScimitar : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 54;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 46;              //Sword width
            item.height = 100;             //Sword height
            item.useTime = 19;          //how fast 
            item.useAnimation = 19;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 3;      //Sword knockback
            item.value = 19;        
            item.rare = 9;
            item.UseSound = SoundID.Item1;                  //1 is the sound of the sword
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;               
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Corrupted Scimitar");
      Tooltip.SetDefault("");
    }

        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(ItemID.SoulofNight, 5);   //you need 1 DirtBlock
			recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddTile(TileID.DemonAltar);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
