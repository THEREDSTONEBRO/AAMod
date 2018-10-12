using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Broodmother
{
    [AutoloadEquip(EquipType.Back, EquipType.Front)]
    public class DragonCape : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragontamer's Cloak");
            Tooltip.SetDefault(
@"10% Increased Damage Resistance");
        }
        public override void SetDefaults()
        {
            item.width = 66;
            item.height = 78;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.endurance *= 1.1f;
        }
    }
    
}