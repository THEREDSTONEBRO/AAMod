using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Akuma
{
    public class RadiantDawn : ModItem
    {
        //TODO: Radiant Dawn needs to do something unique
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiant Dawn");
            Tooltip.SetDefault("Placeholder Weapon");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 32;
            item.damage = 250;
            item.knockBack = 5;
            item.useAmmo = 40;
        }
    }
}
