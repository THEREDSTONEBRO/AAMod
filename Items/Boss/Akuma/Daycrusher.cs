using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAmod.Items.Boss.Akuma
{
    public class Daycrusher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daycrusher");
            Tooltip.SetDefault(@"Slams into foes with the force of a solar mass
Inflicts Daybroken");
        }

        public override void SetDefaults()
        {
            item.width = 54;
            item.height = 44;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 1;

            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 40;
            item.knockBack = 7.5F;
            item.damage = 240;
            item.scale = 2F;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("Daycrusher");
            item.shootSpeed = 20F;
            item.UseSound = SoundID.Item1;
            item.melee = true;
        }
    }
}