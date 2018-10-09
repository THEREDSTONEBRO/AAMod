using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Dev
{
	//imported from my tAPI mod because I'm lazy
	public class EnderStaffEX : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Conflagrate Staff");
            Tooltip.SetDefault(@"Summons a spinning construct that shreds through enemies
I thought the sky was purple
-Ender");
        }

		public override void SetDefaults()
		{
			item.damage = 400;
			item.summon = true;
			item.mana = 20;
			item.width = 64;
			item.height = 64;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 20, 0, 0);
			item.rare = 8;
            item.expert = true;
			item.UseSound = SoundID.Item44;
			item.shootSpeed = 7f;	//The buff added to player after used the item
            item.buffTime = 18000;
		}
        public override bool AltFunctionUse(Player player)
		{
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnderStaff");
            recipe.AddIngredient(null, "EXSoul");
            recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


        public override bool UseItem(Player player)
		{
            if (player.altFunctionUse == 2)
            {
                Item.staff[item.type] = false;
                item.useTime = 13;
                item.useAnimation = 13;
                item.shoot = mod.ProjectileType("EnderSickle");
                item.noMelee = false;
            }
            else
            {
                Item.staff[item.type] = true;
                item.useTime = 16;
                item.useAnimation = 16;
                item.shoot = mod.ProjectileType("EnderMinionEX");
                item.buffType = mod.BuffType("EnderMinionBuffEX");
                item.noMelee = true;
            }
            return base.CanUseItem(player);
        }
    }
}
