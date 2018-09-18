using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.NPCs.Bosses.Zero
{
    class RealityCannon : ZeroArm
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/RealityCannon"; } }

        public override void Init()
        {
            base.Init();
            RC = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reality Cannon");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 26;
            npc.height = 48;
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
            animationType = NPCID.PrimeLaser;
        }
    }
}