using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Dev   //where is located
{
    public class Ryugen : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doragonburedo");
            Tooltip.SetDefault("'I'm gonna wipe their whole team' \n" + "-Jace");
        }
        public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.Arkhalis);
            item.damage = 220;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 56;              //Sword width
            item.height = 56;             //Sword height
            item.expert = true;
            item.useTime = 6;
            item.useAnimation = 6;
            item.knockBack = 6;      //Sword knockback
            item.value = 100000;        
            item.rare = 7;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;
            item.shoot = mod.ProjectileType("Ryugen");
        }
    }
}
