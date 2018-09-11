using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace AAMod.Backgrounds.Mire
{
    public class MireSky : CustomSky
    {

        public static Texture2D PlanetTexture;
        public static Texture2D BGTexture;
<<<<<<< HEAD
        public bool Active;
        public float Intensity;
=======
        public bool _isActive;
        public float _fadeOpacity;
>>>>>>> faebf1def1479bca55ad918d2d95236089e79ac8

        public override void OnLoad()
        {
            PlanetTexture = TextureManager.Load("Backgrounds/Mire/MireMoon");
            BGTexture = TextureManager.Load("Backgrounds/Mire/MireSky");
        }

        public override void Update(GameTime gameTime)
        {
            if (Active)
            {
                Intensity = Math.Min(1f, 0.01f + Intensity);
            }
            else
            {
                Intensity = Math.Max(0f, Intensity - 0.01f);
            }

        }

        public override Color OnTileColor(Color inColor)
        {
            Vector4 value = inColor.ToVector4();
            return new Color(Vector4.Lerp(value, Vector4.One, Intensity * 0.5f));
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {

            if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
            {

                spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this.Intensity);
                spriteBatch.Draw(BGTexture, new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16.0 - (double)Main.screenPosition.Y - 2400.0) * 0.10000000149011612)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f * this.Intensity));
                Vector2 value = new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
                Vector2 value2 = 0.01f * (new Vector2((float)Main.maxTilesX * 8f, (float)Main.worldSurface / 2f) - Main.screenPosition);
                spriteBatch.Draw(PlanetTexture, value + new Vector2(-100f, -200f) + value2, null, Color.White * 0.9f * this.Intensity, 0f, new Vector2((float)(PlanetTexture.Width >> 1), (float)(PlanetTexture.Height >> 1)), 1f, SpriteEffects.None, 1f);

            }
            float scale = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
            Vector2 value3 = Main.screenPosition + new Vector2(Main.screenWidth >> 1, Main.screenHeight >> 1);
            Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);

        }

        public override float GetCloudAlpha()
        {
            return (1f - Intensity);
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            Intensity = 0.002f;
            Active = true;
        }

        public override void Deactivate(params object[] args)
        {
            Active = false;
        }

        public override void Reset()
        {
            Active = false;
        }

        public override bool IsActive()
        {
            return Active || Intensity > 0.001f;
        }
    }
}