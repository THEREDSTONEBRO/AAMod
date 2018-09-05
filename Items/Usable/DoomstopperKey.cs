using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    public class DoomstopperKey : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doomstopper Chip");
			Tooltip.SetDefault("'Unlocks Doomsday Chests'");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = 6;
            item.maxStack = 99;
			item.value = 800000;
           // item.useStyle = 4;
           // item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            //item.consumable = true;
            //item.autoReuse = false;

       //     item.UseSound = SoundID.Item43;
        }

       
    }
}
