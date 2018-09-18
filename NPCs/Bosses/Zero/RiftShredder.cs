using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.NPCs.Bosses.Zero
{
    class RiftShredder : ZeroArm
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/RiftShredder"; } }

        public override void Init()
        {
            base.Init();
            RS = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift Shredder");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 18;
            npc.height = 128;
            npc.friendly = false;
            npc.damage = 100;
            npc.defense = 90;
            npc.lifeMax = 28000;
            npc.life = 28000;
            npc.HitSound = new LegacySoundStyle(3, 4, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 14, Terraria.Audio.SoundType.Sound);
            npc.value = 0f;
            npc.noGravity = true;
            npc.knockBackResist = -1f;
            npc.aiStyle = -1;
            animationType = NPCID.PrimeSaw;
        }
    }
}