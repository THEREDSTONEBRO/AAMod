using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee   //where is located
{
    public class Lolkat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Lolkat");
            Tooltip.SetDefault("Memes memes memes galore");
        }

        public override void SetDefaults()
        {

            item.damage = 300;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 64;              //Sword width
            item.height = 70;             //Sword height
            item.useTime = 10;          //how fast 
            item.useAnimation = 10;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 4;      //Sword knockback
            item.value = 300000;        
            item.rare = 11;
            item.UseSound = SoundID.Item1;       //1 is the sound of the sword
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;
            item.expert = true;
			item.shoot = 502;
			item.shootSpeed = 11f;
        }

        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(ItemID.Meowmere, 1);
            recipe.AddIngredient(null, "TrueCopperShortsword", 1);
            recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddTile(TileID.LunarCraftingStation);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
