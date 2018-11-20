using System; using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using BaseMod;

namespace AAMod.Items.BossSummons
{
	public class HydraChow : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hydra Chow");
            Tooltip.SetDefault(@"Just holding this makes you gag
Summons the Hydra
Only Usable at night");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MirePod", 15);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
		{
			SpawnBoss(player, "Hydra", "The Hydra");
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
		}

		public override bool CanUseItem(Player player)
		{
            if (Main.dayTime)
            {
                if (player.whoAmI == Main.myPlayer) BaseUtility.Chat("Nothing is coming. The creatures of the Mire sleep.", Color.Indigo.R, Color.Indigo.G, Color.Indigo.B, false);
                return false;
            }
            if (player.GetModPlayer<AAPlayer>(mod).ZoneMire)
			{
				if (NPC.AnyNPCs(mod.NPCType("Hydra")))
				{
					if(player.whoAmI == Main.myPlayer) BaseUtility.Chat("The Hydra wants that food.", Color.Indigo.R, Color.Indigo.G, Color.Indigo.B, false);
					return false;
				}
                return true;
			}
			if(player.whoAmI == Main.myPlayer) BaseUtility.Chat("Nothing is coming. Now you look dumb holding out this smelly ball of gunk.", Color.Indigo.R, Color.Indigo.G, Color.Indigo.B, false);			
			return false;
		}

		public void SpawnBoss(Player player, string name, string displayName)
		{
			if (Main.netMode != 1)
			{
				int bossType = mod.NPCType(name);
				if(NPC.AnyNPCs(bossType)){ return; } //don't spawn if there's already a boss!
				int npcID = NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, bossType, 0);
				Main.npc[npcID].Center = player.Center - new Vector2(MathHelper.Lerp(-100f, 100f, (float)Main.rand.NextDouble()), 800f);
				Main.npc[npcID].netUpdate2 = true;
				string npcName = (!string.IsNullOrEmpty(Main.npc[npcID].GivenName) ? Main.npc[npcID].GivenName : displayName);
				if (Main.netMode == 0){ Main.NewText(Language.GetTextValue("Announcement.HasAwoken", npcName), 175, 75, 255, false); }else 
				if (Main.netMode == 2)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
					{
						NetworkText.FromLiteral(npcName)
					}), new Color(175, 75, 255), -1);
				}
			}
		}	

		public override void UseStyle(Player p) { BaseMod.BaseUseStyle.SetStyleBoss(p, item, true, true); }
		public override bool UseItemFrame(Player p) { BaseMod.BaseUseStyle.SetFrameBoss(p, item); return true; }		
	}
}