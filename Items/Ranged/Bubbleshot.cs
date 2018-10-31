using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Ranged
{
	public class Bubbleshot : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Bubbleshot");
        }

		public override void SetDefaults()
		{
			item.damage = 29;
			item.ranged = true;
			item.width = 42;
			item.height = 20;
			item.useTime = 5;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 5000;
			item.rare = 5;
			item.UseSound = SoundID.Item85;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Bubbles");
			item.shootSpeed = 4f;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }
    }
}
