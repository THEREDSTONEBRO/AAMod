using Terraria;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Retriever
{
	public class RetrieverBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 36;
			item.height = 32;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Retriever");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("RetrieverMask"));
            }
            if (Main.rand.Next(2) == 0)
            {
                int choice = Main.rand.Next(7);
                {
                    if (choice == 0)
                    {
                        player.QuickSpawnItem(mod.ItemType("HalHat"));
                        player.QuickSpawnItem(mod.ItemType("HalTux"));
                        player.QuickSpawnItem(mod.ItemType("HalTrousers"));
                    }
                    else if (choice == 1)
                    {
                        player.QuickSpawnItem(mod.ItemType("FishDiverMask"));
                        player.QuickSpawnItem(mod.ItemType("FishDiverJacket"));
                        player.QuickSpawnItem(mod.ItemType("FishDiverBoots"));
                        player.QuickSpawnItem(mod.ItemType("AquamancerWings"));
                    }
                    else if (choice == 2)
                    {
                        player.QuickSpawnItem(mod.ItemType("N1"));
                    }
                    if (choice == 3)
                    {
                        player.QuickSpawnItem(mod.ItemType("GlitchesHat"));
                        player.QuickSpawnItem(mod.ItemType("GlitchesBreastplate"));
                        player.QuickSpawnItem(mod.ItemType("GlitchesGreaves"));
                    }
                    if (choice == 4)
                    {
                        player.QuickSpawnItem(mod.ItemType("GavransGoggles"));
                        player.QuickSpawnItem(mod.ItemType("GavransChest"));
                        player.QuickSpawnItem(mod.ItemType("GavransChest"));
                    }
                    if (choice == 5)
                    {
                        player.QuickSpawnItem(mod.ItemType("ChinMask"));
                        player.QuickSpawnItem(mod.ItemType("ChinSuit"));
                        player.QuickSpawnItem(mod.ItemType("ChinPants"));
                        player.QuickSpawnItem(mod.ItemType("ChinsMagicCoin"));
                    }
                }
            }
            player.QuickSpawnItem(mod.ItemType("Fulgurite"), Main.rand.Next(40, 76));
            player.QuickSpawnItem(mod.ItemType("StormClaw"));
		}
	}
}