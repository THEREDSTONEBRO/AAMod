using AAMod.Items.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace AAMod.Items.Dev
{
	public class TheFourSeasons : ModItem
    {
        private bool burst = true;

        private DrawAnimation anime = new DrawAnimation();

        public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("The 4 Seasons");
            Tooltip.SetDefault(@"Changes color based on ammo type
Right click for burst shot
Left click for spew shot
Super Saucer EX
Sauce 2: Electric Boogaloo");
            anime.FrameCount = 8;
            Main.RegisterItemAnimation(item.type, anime);
        }

        public override void SetDefaults()
		{
			item.damage = 170;
            item.ranged = true;
            item.width = 90;
			item.height = 36;
			item.useTime = 4;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 2500000;
			item.rare = 8;
            item.expert = true;
            item.autoReuse = true;
			item.shootSpeed = 7.75f;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(255, 212, 58);
                }
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            if (burst)
            {
                burst = false;
                item.damage = 170;
                item.useTime = 4;
                item.useAnimation = 12;
                item.shootSpeed = 7.75f;
            }
            else
            {
                burst = true;
                item.damage = 150;
                item.useTime = 6;
                item.useAnimation = 18;
                item.shootSpeed = 12f;
            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.HasItem(mod.ItemType<WasabiBowl>()) || player.HasItem(mod.ItemType<ChiliSauce>()) || player.HasItem(mod.ItemType<LemonJuice>()) || player.HasItem(mod.ItemType<BlueberryJam>()))
            {
                return true;
            }
            return false;
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (item.ammo == mod.ItemType<WasabiBowl>())
            {
                return true;
            }
            if (item.ammo == mod.ItemType<ChiliSauce>())
            {
                return true;
            }
            if (item.ammo == mod.ItemType<LemonJuice>())
            {
                return true;
            }
            if (item.ammo == mod.ItemType<BlueberryJam>())
            {
                return true;
            }
            return false;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.ammo == mod.ItemType<WasabiBowl>())
            {
                if (burst)
                {
                    anime.Frame = 2;
                    type = mod.ProjectileType<WasabiBowlBurstEX>();
                    damage = (int)(damage * 1.25);
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
                else
                {
                    anime.Frame = 6;
                    type = mod.ProjectileType<WasabiBowlSpewEX>();
                    damage = (int)(damage * 1.25);
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
            }
            if (item.ammo == mod.ItemType<ChiliSauce>())
            {
                if (burst)
                {
                    anime.Frame = 1;
                    type = mod.ProjectileType<ChiliSauceBurstEX>();
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
                else
                {
                    anime.Frame = 5;
                    type = mod.ProjectileType<ChiliSauceSpewEX>();
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
            }
            if (item.ammo == mod.ItemType<LemonJuice>())
            {
                if (burst)
                {
                    anime.Frame = 4;
                    type = mod.ProjectileType<LemonJuiceBurstEX>();
                    speedX = (int)(speedX * 1.25);
                    speedY = (int)(speedY * 1.25);
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
                else
                {
                    anime.Frame = 8;
                    type = mod.ProjectileType<LemonJuiceSpewEX>();
                    speedX = (int)(speedX * 1.25);
                    speedY = (int)(speedY * 1.25);
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
            }
            if (item.ammo == mod.ItemType<BlueberryJam>())
            {
                if (burst)
                {
                    anime.Frame = 3;
                    type = mod.ProjectileType<BlueberryJamBurstEX>();
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
                else
                {
                    anime.Frame = 7;
                    type = mod.ProjectileType<BlueberryJamSpewEX>();
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, 0f, player.whoAmI);
                }
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SuperSaucer");
            recipe.AddIngredient(null, "EXSoul");
            recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
