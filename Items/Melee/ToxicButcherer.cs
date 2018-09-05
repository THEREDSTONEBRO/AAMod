using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class ToxicButcherer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toxic Butcherer");
			Tooltip.SetDefault("The blade of a forgotten god of plagues and doom itself");
		}
		public override void SetDefaults()
		{
			item.damage = 50;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 800000;
			item.rare = 9;
			item.expert = true;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("Toxin");
            item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.ChlorophyteSaber, 1);
			recipe.AddIngredient(ItemID.StarWrath, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		 public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 1000);
        }
	}
}
