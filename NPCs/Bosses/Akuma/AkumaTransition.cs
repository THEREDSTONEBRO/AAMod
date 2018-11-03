using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace AAMod.NPCs.Bosses.Akuma
{
    public class AkumaTransition : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            npc.dontTakeDamage = true;
            npc.lifeMax = 1;
            npc.width = 1;
            npc.height = 1;
            npc.friendly = false;
            npc.noGravity = true;
        }
        public int timer;
        public override void AI()
        {
            timer++;
            if (timer < 375)
            {
                Dust dust1;
                Dust dust2;
                Dust dust3;
                Dust dust4;
                Vector2 position = npc.position;
                dust1 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaDust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust2 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaDust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust3 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaDust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust4 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaDust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust1.noGravity = false;
                dust2.noGravity = false;
                dust3.noGravity = false;
                dust4.noGravity = false;
            }
            if (timer == 375)          //if the timer has gotten to 7.5 seconds, this happens (60 = 1 second)
            {
                Main.NewText("Heh...", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
                music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Akuma2");
            }
            if (timer == 750)
            {
                Main.NewText("You know, kid...", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
            }
            if (timer <= 870)
            {
                Dust dust1;
                Dust dust2;
                Dust dust3;
                Dust dust4;
                Vector2 position = npc.position;
                dust1 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust2 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust3 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust4 = Main.dust[Dust.NewDust(position, npc.width, npc.height, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust1.noGravity = false;
                dust2.noGravity = false;
                dust3.noGravity = false;
                dust4.noGravity = false;
            }

            if (timer == 900)
            {
                Main.NewText("fanning the flames doesn't put them out...", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
            }

            if (timer == 1125)
            {
                npc.life = 0;
            }

        }

        public override void NPCLoot()
        {
            Dust dust1;
            Dust dust2;
            Dust dust3;
            Dust dust4;
            Dust dust5;
            Dust dust6;
            Vector2 position = npc.position;
            dust1 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
            dust2 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
            dust3 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
            dust4 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
            dust5 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
            dust6 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
            dust1.noGravity = false;
            dust2.noGravity = false;
            dust3.noGravity = false;
            dust4.noGravity = false;
            dust5.noGravity = false;
            dust6.noGravity = false;
            Main.NewText("IT ONLY MAKES THEM STRONGER", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType<AkumaA>());
        }
        
    }
}