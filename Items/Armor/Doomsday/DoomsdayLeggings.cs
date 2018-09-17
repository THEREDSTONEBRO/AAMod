using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace AAMod.Items.Armor.Doomsday
{
    [AutoloadEquip(EquipType.Legs)]
	public class DoomsdayLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doomsday Assault Greaves");
			Tooltip.SetDefault(@"18% increased movement speed
16% increased melee speed
25% decreased ammo consumption
8% increased damage resistance
The power to destroy entire planets rests in this armor");

		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 3000000;
			item.rare = 11;
			item.defense = 24;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.18f;
			player.meleeSpeed += 0.16f;
			player.ammoCost75 = true;
			player.endurance *= 1.08f;
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new ColorColor(100, 0, 10);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ApocalyptitePlate", 18);
            recipe.AddIngredient(null, "UnstableSingularity", 5);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}