using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Yamata
{
	public class Masamune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Masamune");
            Tooltip.SetDefault(@"Right clicking quickly swings the blade in front of you
Left clicking swings the blade and fires a shadow vortex
Inflicts Moonraze");
		}

		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.Arkhalis);
            item.damage = 200;
            item.melee = true;
            item.width = 70; 
            item.height = 80;          
            item.expert = true;
            item.useTime = 16;
            item.useAnimation = 16;
            item.knockBack = 3;    
            item.value = 1000000;
            item.autoReuse = true;  
            item.useTurn = true;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(20, 20, 76);
                }
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(mod.BuffType("Moonraze"), 600);
        }

        public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{

            if (player.altFunctionUse == 2)
            {
                item.useStyle = 5;
                item.shoot = mod.ProjectileType("Surasshu");
                item.shootSpeed = 15f;
                item.noMelee = true;
                item.noUseGraphic = true;
            }
            else
            {
                item.useStyle = 1;
                item.shoot = mod.ProjectileType("Masamune");
                item.shootSpeed = 6f;
                item.noMelee = false;
                item.noUseGraphic = false;
            }
            return base.CanUseItem(player);
		}
	}
}