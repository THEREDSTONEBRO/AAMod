using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Icegrim   //where is located
{
    public class IceGreatsword : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 45;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 80;              //Sword width
            item.height = 80;             //Sword height

            item.useTime = 45;          //how fast 
            item.useAnimation = 45;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 15;      //Sword knockback
            item.value = 100000;        
            item.rare = 3;
            item.UseSound = SoundID.Item1;       //1 is the sound of the sword
            item.autoReuse = false;   //if it's capable of autoswing.
            item.useTurn = false;               
        }

		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Ice Greatsword");
		}
    }
}
