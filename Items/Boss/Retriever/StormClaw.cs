using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AAMod.Items;
using AAMod;

namespace AAMod.Items.Boss.Retriever
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class StormClaw : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 30;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = -12;
            item.expert = true;
            item.accessory = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Claw");
            Tooltip.SetDefault(
@"For every hit you land on an enemy, 40 true damage (damage unassigned to any class) is dealt
Your non-autoswinging weapons are lightning fast");
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<AAPlayer>().StormClaw = true;
        }
    }
}