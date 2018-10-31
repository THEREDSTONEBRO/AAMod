using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

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
            projectile.penetrate = -1;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
        }
        public int timer;
        public override void AI()
        {
            timer++;
            if (timer == 300)          //if the timer has gotten to 7.5 seconds, this happens (60 = 1 second)
            {
                Main.NewText("You know, kid...fanning the flames doesn't put them out...", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
            }
            if (timer == 600)
            {
                projectile.Kill();
            }
        }
        
        public override void Kill(int timeLeft)
        {
            Main.NewText("IT MAKES THEM STRONGER", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            NPC.NewNPC((int)projectile.position.X + Main.rand.Next(-800, 800), (int)projectile.position.Y + Main.rand.Next(250, 1000), mod.NPCType<AkumaAHead>());
        }
    }
}