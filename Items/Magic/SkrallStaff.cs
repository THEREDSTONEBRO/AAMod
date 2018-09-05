using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Magic
{
	public class SkrallStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Skrall Staff");
            Tooltip.SetDefault(@"A skraltopian Diamond wrapped in a stick 
It's the stick that's magic. The diamond is just for show
-Kingskrall");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 70;
			item.magic = true;
			item.mana = 6;
			item.width = 58;
			item.height = 58;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 1000000;
			item.rare = 11;
            item.expert = true;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Crystal");
			item.shootSpeed = 20f;
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
                item.mana = 12;
                item.useTime = 30;
                item.useAnimation = 30;
                item.useStyle = 5;
                item.noMelee = true; //so the item's animation doesn't do damage
                item.damage = 270;
                item.shoot = mod.ProjectileType("BigCrystal");
                item.shootSpeed = 15f;
            }
            else
            {
                item.mana = 12;
                item.useStyle = 5;
                item.useTime = 5;
                item.useAnimation = 5;
                item.melee = true;
                item.shoot = mod.ProjectileType("Crystal");
                item.damage = 70;
                item.noMelee = false;
                item.shootSpeed = 20f;
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WandofSparking, 1);
            recipe.AddIngredient(ItemID.DD2ElderCrystal, 1);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}