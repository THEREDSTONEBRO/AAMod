﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Materials
{
    public class SoulOfSpite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Spite");
            Tooltip.SetDefault("The essence of Mire creatures");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        // TODO -- Velocity Y smaller, post NewItem?
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 1000;
            item.rare = 3;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.OrangeRed.ToVector3() * 0.55f * Main.essScale);
        }
    }

    public class SoulofSpiteGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if ((Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AAPlayer>(mod).ZoneMire) && Main.hardMode)
            {
                if (Main.rand.Next(0, 100) >= 80)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfSpite"), 1);
                }
            }
        }
    }
}