using System;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Akuma
{
    public class AkumaBag : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Boss/Akuma/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 32;
            item.expert = true;
            bossBagNPC = mod.NPCType("AkumaA");
            item.glowMask = customGlowMask;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            if (Main.rand.Next(7) == 0)
            {
                //player.QuickSpawnItem(mod.ItemType("ZeroMask"));
            }
            if (Main.rand.NextFloat() < 0.01f)
            {
                int choice = Main.rand.Next(17);
                {
                    if (choice == 0)
                    {
                        player.QuickSpawnItem(mod.ItemType("HalHat"));
                        player.QuickSpawnItem(mod.ItemType("HalTux"));
                        player.QuickSpawnItem(mod.ItemType("HalTrousers"));
                        player.QuickSpawnItem(mod.ItemType("HallamDevWeapon"));
                    }
                    else if (choice == 1)
                    {
                        player.QuickSpawnItem(mod.ItemType("FishDiverMask"));
                        player.QuickSpawnItem(mod.ItemType("FishDiverJacket"));
                        player.QuickSpawnItem(mod.ItemType("FishDiverBoots"));
                        player.QuickSpawnItem(mod.ItemType("AquamancerWings"));
                        player.QuickSpawnItem(mod.ItemType("AmphibianLongsword"));
                    }
                    else if (choice == 2)
                    {
                        player.QuickSpawnItem(mod.ItemType("N1"));
                        player.QuickSpawnItem(mod.ItemType("Sax"));
                    }
                    if (choice == 3)
                    {
                        player.QuickSpawnItem(mod.ItemType("GlitchesHat"));
                        player.QuickSpawnItem(mod.ItemType("GlitchesBreastplate"));
                        player.QuickSpawnItem(mod.ItemType("GlitchesGreaves"));
                        player.QuickSpawnItem(mod.ItemType("UmbreonSP"));
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
                        player.QuickSpawnItem(mod.ItemType("ChinStaff"));
                    }
                    if (choice == 6)
                    {
                        player.QuickSpawnItem(mod.ItemType("SkrallStaff"));
                    }
                    if (choice == 7)
                    {
                        player.QuickSpawnItem(mod.ItemType("Ryugen"));
                    }
                    if (choice == 8)
                    {
                        player.QuickSpawnItem(mod.ItemType("TimeTeller"));
                    }
                    if (choice == 9)
                    {
                        player.QuickSpawnItem(mod.ItemType("TitanAxe"));
                    }
                    if (choice == 10)
                    {
                        player.QuickSpawnItem(mod.ItemType("EnderStaff"));
                    }
                    if (choice == 11)
                    {
                        player.QuickSpawnItem(mod.ItemType("CatsEyeRifle"));
                    }
                    if (choice == 12)
                    {
                        player.QuickSpawnItem(mod.ItemType("DuckstepGun"));
                    }
                    if (choice == 13)
                    {
                        player.QuickSpawnItem(mod.ItemType("GentlemansRapier"));
                    }

                    if (choice == 14)
                    {
                        player.QuickSpawnItem(mod.ItemType("Etheral"));
                    }
                }
            }
            player.QuickSpawnItem(mod.ItemType("CrucibleScales"), Main.rand.Next(30, 40));
            player.QuickSpawnItem(mod.ItemType("TaiyangBaolei"));
            string[] lootTable = { "Solar", "SunSpear", "ReignOfFire", "DaybreakArrow", "Daycrusher", "Dawnstrike", "Sunstorm", "SunStaff" };
            int loot = Main.rand.Next(lootTable.Length);
            player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}