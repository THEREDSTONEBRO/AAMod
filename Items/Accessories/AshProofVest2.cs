using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Accessories
{
    public class AshProofVest2 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 36;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (item.accessory)
            {
                player.GetModPlayer<AAPlayer>().AshRemover = true;
                if (Main.rand.Next(3600) == 0 && player.GetModPlayer<AAPlayer>().ZoneInferno && !Main.dayTime)
                {
                    Main.PlaySound(SoundID.Item34);
                    item.type = mod.ItemType<AshProofVest1>();
                    item.CloneDefaults(mod.ItemType<AshProofVest1>());
                }
            }
            else
            {
                player.GetModPlayer<AAPlayer>().AshRemover = false;
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ash-Proof Vest");
            Tooltip.SetDefault(@"Temporary accessory to completly remove Ash Rain");
        }
    }
}