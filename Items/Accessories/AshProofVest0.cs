using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace AAMod.Items.Accessories
{
    public class AshProofVest0 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateInventory(Player player)
        {
            if (Main.itemAnimations[item.type].Frame == 5)
            {
                item.TurnToAir();
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Main.itemAnimations[item.type].Frame == 5)
            {
                item.TurnToAir();
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ash-Proof Vest");
            Tooltip.SetDefault(@"Temporary accessory to completly remove Ash Rain");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
        }
    }
}