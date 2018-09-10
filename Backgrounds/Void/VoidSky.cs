using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace AAMod.Backgrounds.Void
{
    public class VoidSky : CustomSky
    {
        private struct Bolt
        {
            public Vector2 Position;
            public float Depth;
            public int Life;
            public bool IsAlive;
        }

        private UnifiedRandom _random = new UnifiedRandom();


        public static Texture2D PlanetTexture;
        public static Texture2D BGTexture;
        public Texture2D _boltTexture;
        public Texture2D _flashTexture;
        public bool _isActive;
        public int _ticksUntilNextBolt;
        public float _fadeOpacity;
        private Bolt[] _bolts;
		bool Active;
        float Intensity;

        public override void OnLoad()
        {
            PlanetTexture = TextureManager.Load("Backgrounds/Void/VoidBH");
            BGTexture = TextureManager.Load("Backgrounds/Void/VoidSky");
            _boltTexture = TextureManager.Load("Backgrounds/Void/VoidBolt");
            _flashTexture = TextureManager.Load("Backgrounds/Void/VoidFlash");
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
            if (_ticksUntilNextBolt <= 0)
            {
                _ticksUntilNextBolt = _random.Next(1, 5);
                int num = 0;
                while (_bolts[num].IsAlive && num != _bolts.Length - 1)
                {
                    num++;
                }
                _bolts[num].IsAlive = true;
                _bolts[num].Position.X = _random.NextFloat() * ((float)Main.maxTilesX * 16f + 4000f) - 2000f;
                _bolts[num].Position.Y = _random.NextFloat() * 500f;
                _bolts[num].Depth = _random.NextFloat() * 8f + 2f;
                _bolts[num].Life = 30;
            }
            _ticksUntilNextBolt--;
            for (int i = 0; i < _bolts.Length; i++)
            {
                if (_bolts[i].IsAlive)
                {
                    Bolt[] expr_168_cp_0 = _bolts;
                    int expr_168_cp_1 = i;
                    expr_168_cp_0[expr_168_cp_1].Life = expr_168_cp_0[expr_168_cp_1].Life - 1;
                    if (_bolts[i].Life <= 0)
                    {
                        _bolts[i].IsAlive = false;
                    }
                }
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
            for (int i = 0; i < _bolts.Length; i++)
            {
                if (_bolts[i].IsAlive && _bolts[i].Depth > minDepth && _bolts[i].Depth < maxDepth)
                {
                    Vector2 value4 = new Vector2(1f / _bolts[i].Depth, 0.9f / _bolts[i].Depth);
                    Vector2 position = (_bolts[i].Position - value3) * value4 + value3 - Main.screenPosition;
                    if (rectangle.Contains((int)position.X, (int)position.Y))
                    {
                        Texture2D texture = _boltTexture;
                        int life = _bolts[i].Life;
                        if (life > 26 && life % 2 == 0)
                        {
                            texture = _flashTexture;
                        }
                        float scale2 = life / 30f;
                        spriteBatch.Draw(texture, position, null, Color.White * scale * scale2 * _fadeOpacity, 0f, Vector2.Zero, value4.X * 5f, SpriteEffects.None, 0f);
                    }
                }
            }
        }

        public override float GetCloudAlpha()
        {
            return (1f - _fadeOpacity) * 0.3f + 0.7f;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            _fadeOpacity = 0.002f;
            _isActive = true;
            _bolts = new Bolt[500];
            for (int i = 0; i < _bolts.Length; i++)
            {
                _bolts[i].IsAlive = false;
            }
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