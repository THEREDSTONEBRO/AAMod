using AAMod.Items.Tools;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace AAMod.UI
{
    class TerratoolUI : UIState
    {
        public static bool visible = false;

        public TerraToolUI TerraToolUIToolAxe;
        public TerraToolUI TerraToolUIToolPick;
        public TerraToolUI TerraToolUIToolHammer;

        public override void OnInitialize()
		{
            TerraToolUIToolAxe = new TerraToolUI(ModLoader.GetTexture("AAMod/UI/Axe"));
            TerraToolUIToolAxe.SetPadding(0);
            TerraToolUIToolAxe.Left.Set(40f, 0f);
            TerraToolUIToolAxe.Top.Set(300f, 0f);
            TerraToolUIToolAxe.Width.Set(40f, 0f);
            TerraToolUIToolAxe.Height.Set(40f, 0f);
            Append(TerraToolUIToolAxe);

            TerraToolUIToolPick = new TerraToolUI(ModLoader.GetTexture("AAMod/UI/Pick"));
            TerraToolUIToolPick.SetPadding(0);
            TerraToolUIToolPick.Left.Set(60f, 0f);
            TerraToolUIToolPick.Top.Set(310f, 0f);
            TerraToolUIToolPick.Width.Set(40f, 0f);
            TerraToolUIToolPick.Height.Set(40f, 0f);
            Append(TerraToolUIToolPick);

            TerraToolUIToolHammer = new TerraToolUI(ModLoader.GetTexture("AAMod/UI/Hammer"));
            TerraToolUIToolHammer.SetPadding(0);
            TerraToolUIToolHammer.Left.Set(80f, 0f);
            TerraToolUIToolHammer.Top.Set(300f, 0f);
            TerraToolUIToolHammer.Width.Set(40f, 0f);
            TerraToolUIToolHammer.Height.Set(40f, 0f);
            Append(TerraToolUIToolHammer);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            if (TerraToolUIToolAxe.IsMouseHovering)
            {
                if (!Terratool.AxeBool)
                {
                    Terratool.AxeBool = true;
                }
                else
                {
                    Terratool.AxeBool = false;
                }
            }
            if (TerraToolUIToolPick.IsMouseHovering)
            {
                if (!Terratool.PickBool)
                {
                    Terratool.PickBool = true;
                }
                else
                {
                    Terratool.PickBool = false;
                }
            }
            if (TerraToolUIToolHammer.IsMouseHovering)
            {
                if (!Terratool.HammerBool)
                {
                    Terratool.HammerBool = true;
                }
                else
                {
                    Terratool.HammerBool = false;
                }
            }
        }
    }

    internal class TerraToolUI : UIImageButton
    {
        public TerraToolUI(Texture2D texture) : base(texture)
        {
            if (ModLoader.GetTexture("AAMod/UI/Axe") == null || ModLoader.GetTexture("AAMod/UI/Pick") == null || ModLoader.GetTexture("AAMod/UI/Hammer") == null)
            {
                texture = ModLoader.GetTexture("AAMod/UI/Base");
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
        }
    }
}
