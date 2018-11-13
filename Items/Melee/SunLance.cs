using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class SunLance : ModItem
    {
        public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Aqua Lance");
		Tooltip.SetDefault("");
		}
        public override void SetDefaults()
        {
            item.damage = 100;
            item.melee = true;
            item.width = 74;
            item.height = 84;
            item.scale = 1.1f;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
			item.autoReuse = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 5; //put your Spear projectile name
            item.shootSpeed = 4f;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
                item.shoot = mod.ProjectileType("SunLance");
                item.useStyle = 5;
                item.shootSpeed = 12f;
                item.noMelee = true;
                item.noUseGraphic = true;
                return player.ownedProjectileCounts[item.shoot] < 1;
            }
            else
            {
                item.useStyle = 1;
                item.shoot = 0;
                item.damage = 200;
                item.noMelee = false;
                item.noUseGraphic = false;
            }
            return base.CanUseItem(player);
        }
        
    }
}
