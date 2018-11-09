using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace AAMod.Items.Armor.Draco
{
    [AutoloadEquip(EquipType.Body)]
	public class DracoPlate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Draconian Sun Dao");
			Tooltip.SetDefault(@"25% increased melee and magic damage
10% increased damage resistance
The blazing fury of the Inferno rests in this armor");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.value = 3000000;
			item.defense = 49;
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(180, 41, 32);
                }
            }
        }

        public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.25f;
			player.magicDamage *= 1.25f;
			player.endurance *= 1.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DaybreakIncinerite", 20);
			recipe.AddIngredient(null, "CrucibleScale", 5);
            recipe.AddIngredient(null, "KindledDou", 1);
            recipe.AddTile(null, "BinaryReassembler");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}