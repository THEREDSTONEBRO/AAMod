using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace AAMod.Items.Armor.Doomsday
{
    [AutoloadEquip(EquipType.Body)]
	public class DoomsdayChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Doomsday Assault Armor");
			Tooltip.SetDefault(@"20% increased melee and ranged damage
8% increased damage resistance
The power to destroy entire planets rests in this armor");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.value = 3000000;
			item.rare = 11;
			item.defense = 42;
		}
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(100, 0, 10);
                }
            }
        }

        public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.20f;
			player.rangedDamage *= 1.20f;
			player.endurance *= 1.08f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocalyptitePlate", 20);
			recipe.AddIngredient(null, "UnstableSingularity", 5);
			recipe.AddTile(null, "BinaryReassembler");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}