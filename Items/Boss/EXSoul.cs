using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss
{
    public class EXSoul : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EX Soul");
            Tooltip.SetDefault("Essence of ancient, arcane magic");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
            ItemID.Sets.ItemNoGravity[item.type] = true;
            /*if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Boss/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }*/

        }

        // TODO -- Velocity Y smaller, post NewItem?
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 1000000;
            item.rare = 11;
            item.expert = true;
            //item.glowMask = customGlowMask;
            item.alpha = 100;
        }

        // The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
        public override void GrabRange(Player player, ref int grabRange)
        {
            grabRange *= 2;
        }

        public override void PostUpdate()
        {
            item.color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
        }
        public static Color GetItemLight(ref Color currentColor, ref float scale, int type, bool outInTheWorld = false)
        {
            currentColor.R = (byte)Main.DiscoR;
            currentColor.G = (byte)Main.DiscoG;
            currentColor.B = (byte)Main.DiscoB;
            currentColor.A = 255;
            return currentColor;
        }
    }
}