using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace AAMod.Items.Armor.Doomsday
{
    [AutoloadEquip(EquipType.Head)]
	public class DoomsdayHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doomsday Assault Visor");
			Tooltip.SetDefault(@"15% increased melee critical chance
20% increased ranged critical chance
8% increased damage resistance
The power to destroy entire planets rests in this armor");

		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 3000000;
			item.rare = 11;
			item.defense = 30;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 15;
			player.rangedCrit += 25;
			player.endurance *= 1.08f;
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(120, 0, 30);
                }
            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DoomsdayChestplate") && legs.type == mod.ItemType("DoomsdayLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			
			player.setBonus = @"Life termination systems activated
You detect all hostile life around you
you can see in the dark much more easily
Your ranged and melee attacks are strong enough to weaken your enemies defense for a time";


            player.AddBuff(BuffID.Hunter, 2);
            player.AddBuff(BuffID.NightOwl, 2);
            player.GetModPlayer<AAPlayer>(mod).zeroSet = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ApocalyptitePlate", 15);
            recipe.AddIngredient(null, "UnstableSingularity", 5);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}