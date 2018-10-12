using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Broodmother
{
    public class BroodScale : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 24;
            item.maxStack = 99;
            item.rare = 1;
			
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Scale");
            Tooltip.SetDefault("The scale of a formidable foe");
        }
    }
}
