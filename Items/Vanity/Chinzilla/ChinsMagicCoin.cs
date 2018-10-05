using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace AAMod.Items.Vanity.Chinzilla
{
    [AutoloadEquip(EquipType.Wings)]
    public class ChinsMagicCoin : ModItem
	{
        private int timer = 5;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chinzilla00's Coin Barrier");
			Tooltip.SetDefault("'Great for impersonating AA devs!'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8));
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(0, 128, 64);
                }
            }
        }
        public override void SetDefaults()
		{
			item.width = 64;
			item.height = 42;
			item.rare = 10;
            item.accessory = true;
            item.value = 500000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.HasItem(ItemID.PlatinumCoin))
            {
                player.wingTimeMax = 400;
            }
            else if (player.HasItem(ItemID.GoldCoin))
            {
                player.wingTimeMax = 300;
            }
            else if (player.HasItem(ItemID.SilverCoin))
            {
                player.wingTimeMax = 200;
            }
            else if (player.HasItem(ItemID.CopperCoin))
            {
                player.wingTimeMax = 100;
            }
            else
            {
                player.wingTimeMax = 0;
            }
        }

        public override bool WingUpdate(Player player, bool inUse)
        {
            if (timer > 0)
            {
                timer--;
            }
            if (inUse)
            {
                player.GetModPlayer<AAPlayer>().CoinWings = true;
                if (player.wingFrame == 4 && timer == 0)
                {
                    player.wingFrame = 0;
                    timer = 5;
                }
                if (timer == 0)
                {
                    player.wingFrame++;
                    timer = 5;
                }
            }
            else
            {
                player.GetModPlayer<AAPlayer>().CoinWings = false;
            }
            return true;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 10f;
            acceleration *= 2.5f;
        }
    }
}