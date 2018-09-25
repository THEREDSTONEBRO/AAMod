using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Equinox
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class DarkVoid : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 11;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateEquip(Player player)
        {
            if (!Main.dayTime)
            {
                player.lifeRegen += 5;
                player.statDefense += 8;
                player.meleeSpeed += 0.3f;
                player.meleeDamage += 0.3f;
                player.meleeCrit += 4;
                player.rangedDamage += 0.3f;
                player.rangedCrit += 4;
                player.magicDamage += 0.3f;
                player.magicCrit += 4;
                player.pickSpeed -= 0.30f;
                player.minionDamage += 0.3f;
                player.minionKB += 0.7f;
                player.thrownDamage += 0.3f;
                player.thrownCrit += 4;
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiant Star");
            Tooltip.SetDefault(
@"Gives immensely increased stats at night
'Dark and spooky'");
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Wrath, 2);
        }

    }
}