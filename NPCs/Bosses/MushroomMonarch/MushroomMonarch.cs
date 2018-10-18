using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.MushroomMonarch
{
    public class MushroomMonarch : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Monarch");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 15;  //5 is the flying AI
            npc.lifeMax = 1500;   //boss life
            npc.damage = 24;  //boss damage
            npc.defense = 12;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 74;
            npc.height = 106;
            animationType = NPCID.GreenSlime;   //this boss will behavior like the DemonEye
            Main.npcFrameCount[npc.type] = 2;    //boss frame/animation 
            npc.value = Item.buyPrice(0, 0, 75, 45);
            npc.npcSlots = 1f;
            npc.boss = true;  
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.buffImmune[46] = true;
			npc.buffImmune[47] = true;
            music = MusicID.Boss4;
            npc.netAlways = true;
            bossBag = mod.ItemType("MonarchBag");
        }
	
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.Mushroom;   //boss drops
            AAWorld.downedMonarch = true;
            Projectile.NewProjectile((new Vector2(npc.position.X, npc.position.Y)), (new Vector2(0f, 0f)), mod.ProjectileType("MonarchRUNAWAY"), 0, 0);
            if (Main.expertMode == true)
            {
                npc.DropBossBags();
            }
            else
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mushium"), Main.rand.Next(20, 30));
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.1f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.1f);  //boss damage increase in expermode
        }
    }
}   
