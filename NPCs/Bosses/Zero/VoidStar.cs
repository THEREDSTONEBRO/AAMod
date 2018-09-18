using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.NPCs.Bosses.Zero
{
    class VoidStar : ZeroArm
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/VoidStar"; } }

        public override void Init()
        {
            base.Init();
            VS = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Star");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 26;
            npc.height = 30;
            npc.friendly = false;
            npc.damage = 100;
            npc.defense = 90;
            npc.lifeMax = 28000;
            npc.life = 28000;
            npc.noGravity = true;
            npc.HitSound = new LegacySoundStyle(3, 4, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 14, Terraria.Audio.SoundType.Sound);
            npc.value = 0f;
            npc.knockBackResist = -1f;
            npc.aiStyle = -1;
            animationType = NPCID.PrimeCannon;
        }
    }
}