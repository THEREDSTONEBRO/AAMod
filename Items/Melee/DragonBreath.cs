using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee   //where is located
{
    public class DragonBreath : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 54;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 52;              //Sword width
            item.height = 52;             //Sword height
            item.useTime = 25;          //how fast 
            item.useAnimation = 25;     
            item.useStyle = 5;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 4;      //Sword knockback
            item.value = 20000;        
            item.rare = 4;
            item.shoot = mod.ProjectileType("DragonBreathP");
            item.UseSound = SoundID.Item20;       //1 is the sound of the sword
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true; 
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Dragon's Breath");
      Tooltip.SetDefault("It must need to brush it's teeth");
    }

        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(null, "DragonSpirit", 20);		//you need 1 DirtBlock
            recipe.AddTile(TileID.DemonAltar);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
