using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee   //where is located
{
    public class BloodThirster : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 39;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 44;              //Sword width
            item.height = 50;             //Sword height
            item.useTime = 24;          //how fast 
            item.useAnimation = 24;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 4;      //Sword knockback
            item.value = 20;        
            item.rare = 3;
            item.UseSound = SoundID.Item1;       //1 is the sound of the sword
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true; 
        }

		public override void SetStaticDefaults()
			{
			  DisplayName.SetDefault("The Blood Thirster");
			  Tooltip.SetDefault("");
			}

        public override void AddRecipes()  //How to craft this sword
			{
				ModRecipe recipe = new ModRecipe(mod);      
				recipe.AddIngredient(ItemID.BloodButcherer, 1);
				recipe.AddIngredient(ItemID.Muramasa, 1);//you need 1 DirtBlock
				recipe.AddTile(26);   //at work bench
				recipe.SetResult(this);
				recipe.AddRecipe();

			}
    }
}
