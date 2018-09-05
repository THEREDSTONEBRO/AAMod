using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace AAMod.Items.Magic
{
	public class YairsGildedKazoo : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Yair's Gilded Kazoo");
            Tooltip.SetDefault("Doot Doot");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 150;
			item.magic = true;
			item.mana = 6;
			item.width = 42;
			item.height = 16;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 7;
			item.value = 100000;
			item.rare = 11;
            item.expert = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Sounds/Doot");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Doot");
            item.shootSpeed = 5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(null, "Kazoo", 1);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}