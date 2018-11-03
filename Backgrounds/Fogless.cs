using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace AAMod.Backgrounds
{
    public class Fogless : CustomSky
    {
        public static Texture2D FoglessTexture;
        public bool Active;
        public float Intensity;
        private float FoglessTime = 0f;

        public override void Update(GameTime gameTime)
        {
            if (Active)
            {
                Intensity = 0.1f;
                if (FoglessTime < 1f)
                {
                    FoglessTime += 0.1f;
                }
            }
            else
            {
                Intensity = 0f;
                if (FoglessTime > 0f)
                {
                    FoglessTime -= 0.1f;
                }
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
                Player player = Main.player[Main.myPlayer];
                spriteBatch.Draw(FoglessTexture, player.Center, null, Color.White * FoglessTime * Intensity, 0f, new Vector2(player.Center.X, player.Center.Y), 1f, SpriteEffects.None, 10f);
            }
        }

        public override float GetCloudAlpha()
        {
            return (1f - Intensity);
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            Intensity = 0.1f;
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
            return Active || Intensity == 0.1f;
        }
    }
}