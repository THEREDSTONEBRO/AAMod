using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class Chaos : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos");
			Tooltip.SetDefault("Wrath and fury upon those struck by this twisted blade");
		}
		public override void SetDefaults()
		{
			item.damage = 140;
			item.melee = true;
			item.width = 94;
			item.height = 94;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 200000;
			item.rare = 8;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ChaosShot");
            item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "TrueBlazingDawn", 1);
			recipe.AddIngredient(mod, "TrueAbyssalTwilight", 1);
            recipe.AddIngredient(mod, "Discord", 1);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		 public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 500);
			target.AddBuff(BuffID.Venom, 500);
        }
	}
}
