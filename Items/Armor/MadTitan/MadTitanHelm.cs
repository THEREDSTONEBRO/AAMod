using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace AAMod.Items.Armor.MadTitan
{
    [AutoloadEquip(EquipType.Head)]
	public class MadTitanHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mad Titan's Helm");
			Tooltip.SetDefault(@"+7 max minions 
160 Increased max mana");

		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 14;
			item.value = 3000000;
			item.rare = 11;
			item.defense = 30;
		}
		
		public override void UpdateEquip(Player player)
		{
            player.maxMinions += 6;
            player.statManaMax2 += 160;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MadTitanChestplate") && legs.type == mod.ItemType("MadTitanBoots");
		}

		public override void UpdateArmorSet(Player player)
		{
			
			player.setBonus = @"The infinity gauntlet is now at it's most powerful
'The power of a mad titan is now at your fingertips'";
            player.GetModPlayer<AAPlayer>(mod).TrueInfinityGauntlet = true;
            player.GetModPlayer<AAPlayer>(mod).InfinityGauntlet = false;
        }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("AAMod:DarkmatterHelmets");
            recipe.AddRecipeGroup("AAMod:RadiumHelmets");
            recipe.AddIngredient(ItemID.SolarFlareHelmet, 1);
            recipe.AddIngredient(ItemID.VortexHelmet, 1);
            recipe.AddIngredient(ItemID.NebulaHelmet, 1);
            recipe.AddIngredient(ItemID.StardustHelmet, 1);
            recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}