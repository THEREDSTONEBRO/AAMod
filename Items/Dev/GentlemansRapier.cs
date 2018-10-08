using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Dev
{
	public class GentlemansRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Gentleman's Rapier");
            Tooltip.SetDefault(@"Shoots dapper top hats
Right clicking thrusts the blade forward
Left clicking swings the blade
'Spoopy'
-Tied");
		}

		public override void SetDefaults()
		{
			item.damage = 200;
			item.melee = true;
			item.width = 64;
			item.height = 66;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 100000;
			item.rare = 11;
            item.shoot = mod.ProjectileType("TopHat");
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shootSpeed = 12f;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(0, 105, 0);
                }
            }
        }

        public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 3;
                item.useTime = 20;
                item.useAnimation = 20;
            }
            else
            {
                item.useStyle = 1;
                item.useTime = 23;
                item.useAnimation = 23;
            }
            return base.CanUseItem(player);
		}
	}
}