using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace AAMod.Backgrounds
{
    public class MireSky : CustomSky
    {

        private UnifiedRandom _random = new UnifiedRandom();


        public static Texture2D PlanetTexture;
        public static Texture2D BGTexture;
        public bool _isActive;
        public float _fadeOpacity;
		bool Active;
        float Intensity;

        public override void OnLoad()
        {
            PlanetTexture = TextureManager.Load("Backgrounds/MireMoon");
            BGTexture = TextureManager.Load("Backgrounds/MireSky");
        }

        public override void Update(GameTime gameTime)
        {
            if (_isActive)
            {
                _fadeOpacity = Math.Min(1f, 0.01f + _fadeOpacity);
            }
            else
            {
                _fadeOpacity = Math.Max(0f, _fadeOpacity - 0.01f);
            }
            
        }

        public override Color OnTileColor(Color inColor)
        {
            Vector4 value = inColor.ToVector4();
            return new Color(Vector4.Lerp(value, Vector4.One, _fadeOpacity * 0.5f));
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            
            if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
            {
                
                spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this._fadeOpacity);
                spriteBatch.Draw(BGTexture, new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16.0 - (double)Main.screenPosition.Y - 2400.0) * 0.10000000149011612)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f * this._fadeOpacity));
                Vector2 value = new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
                Vector2 value2 = 0.01f * (new Vector2((float)Main.maxTilesX * 8f, (float)Main.worldSurface / 2f) - Main.screenPosition);
                spriteBatch.Draw(PlanetTexture, value + new Vector2(-100f, -200f) + value2, null, Color.White * 0.9f * this._fadeOpacity, 0f, new Vector2((float)(PlanetTexture.Width >> 1), (float)(PlanetTexture.Height >> 1)), 1f, SpriteEffects.None, 1f);

            }
            float scale = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
            Vector2 value3 = Main.screenPosition + new Vector2(Main.screenWidth >> 1, Main.screenHeight >> 1);
            Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
            
        }

        public override float GetCloudAlpha()
        {
            return (1f - _fadeOpacity) * 0.3f + 0.7f;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            _fadeOpacity = 0.002f;
            _isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            _isActive = false;
        }

        public override void Reset()
        {
            _isActive = false;
        }

        public override bool IsActive()
        {
            return _isActive || _fadeOpacity > 0.001f;
        }
    }
}