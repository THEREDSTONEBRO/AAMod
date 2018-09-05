using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Usable
{
    public class GoblinDoll : ModItem
    {
        

        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 28;
            item.rare = 1;
            item.value = 50000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(204, 102, 0);
                }
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goblin Tinkerer Doll");
            Tooltip.SetDefault(@"I'm sorry, little one...");
        }

        public override void PostUpdate()
        {
            if (item.lavaWet)
            {
                //if (Main.netMode != 1)
                //{
                for (int i = 0; i < 200; ++i)
                {
                    if (Main.npc[i].type == NPCID.GoblinTinkerer && NPC.downedMoonlord)
                    {
                        int variable = Player.FindClosest(item.position, item.width, item.height);
                        Player player = Main.player[Player.FindClosest(item.position, item.width, item.height)];
                        Item.NewItem((int)item.position.X, (int)item.position.Y, player.width, player.height, mod.ItemType("SoulStone"), 1, false, item.prefix);
                        Main.npc[i].StrikeNPCNoInteraction(9999, 10f, -Main.npc[i].direction, false, false, false);
                        item.active = false;
                        item.type = 0;
                        //item.name = ""; 
                        item.stack = 0;
                        Main.NewText("The soul stone materializes in your hand", 180, 120, 0);
                    }
                }
                //}
            }
        }
    }
}
