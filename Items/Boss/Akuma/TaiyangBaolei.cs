using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Akuma
{
    [AutoloadEquip(EquipType.Shield)]
    public class TaiyangBaolei : ModItem
    {
        private int saveTime;
        private int Defense;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Taiyang Baolei");
            Tooltip.SetDefault(@"Allows you parry incoming attacks with a right-click
During the day, item's defense is doubled and your melee & magic attacks set enemies ablaze
From 11:00 AM to 1:00 PM, ");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.expert = true;
            item.accessory = true;
            item.defense = Defense;
        }
        
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(0, 255, 248);
                }
            }
        }

        /*public override void UpdateEquip(Player player)
        {
            saveTime = (ushort)Main.time;
        }*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AAPlayer>().Baolei = true;
            if (!Main.dayTime)
            {
                Defense = 4;
            }
            if (Main.dayTime && Main.time < 23400 && Main.time > 30600)
            {
                Defense = 8;
            }
            if (Main.dayTime && Main.time >= 23400 && Main.time <= 30600)
            {
                Defense = 16;
            }
        }
    }
}