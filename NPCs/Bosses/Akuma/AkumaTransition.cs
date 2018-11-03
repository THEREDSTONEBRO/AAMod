using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using AAMod.NPCs.Bosses.Akuma;

namespace AAMod.NPCs.Bosses.Akuma
{
    public class AkumaTransition : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.friendly = false;
        }
        public int timer;
        public override void AI()
        {
            timer++;
            if (timer < 870)
            {
                Dust dust1;
                Dust dust2;
                Dust dust3;
                Dust dust4;
                Vector2 position = projectile.position;
                dust1 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaDust>(), 1, 1, 0, default(Color), 1f)];
                dust2 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaDust>(), 1, 1, 0, default(Color), 1f)];
                dust3 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaDust>(), 1, 1, 0, default(Color), 1f)];
                dust4 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaDust>(), 1, 1, 0, default(Color), 1f)];
                dust1.noGravity = true;
                dust2.noGravity = true;
                dust3.noGravity = true;
                dust4.noGravity = true;
            }
            if (timer == 375)          //if the timer has gotten to 7.5 seconds, this happens (60 = 1 second)
            {
                Main.NewText("Heh...", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
            }
            if (timer == 750)
            {
                Main.NewText("You know, kid...", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
            }
            if (timer >= 900)
            {
                Dust dust1;
                Dust dust2;
                Dust dust3;
                Dust dust4;
                Vector2 position = projectile.position;
                dust1 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
                dust2 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
                dust3 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
                dust4 = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
                dust1.noGravity = true;
                dust2.noGravity = true;
                dust3.noGravity = true;
                dust4.noGravity = true;
            }

            if (timer == 900)
            {
                Main.NewText("fanning the flames doesn't put them out...", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
            }

            if (timer == 1125)
            {
                projectile.Kill();
            }

        }

        public override void Kill(int timeleft)
        {
            Dust dust1;
            Dust dust2;
            Dust dust3;
            Dust dust4;
            Dust dust5;
            Dust dust6;
            Vector2 position = projectile.position;
            dust1 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
            dust2 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
            dust3 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
            dust4 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
            dust5 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
            dust6 = Main.dust[Dust.NewDust(position, 144, 144, mod.DustType<Dusts.AkumaADust>(), 1, 1, 0, default(Color), 1f)];
            dust1.noGravity = false;
            dust2.noGravity = false;
            dust3.noGravity = false;
            dust4.noGravity = false;
            dust5.noGravity = false;
            dust6.noGravity = false;
            Main.NewText("IT ONLY MAKES THEM STRONGER", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, mod.NPCType<AkumaA>());
        }
        
    }
}