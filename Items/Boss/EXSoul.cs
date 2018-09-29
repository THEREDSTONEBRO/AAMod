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
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EX Soul");
            Tooltip.SetDefault("Essence of ancient, arcane magic");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
            ItemID.Sets.ItemNoGravity[item.type] = true;
            
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
            item.rare = 7;
        }

        // The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
        public override void GrabRange(Player player, ref int grabRange)
        {
            grabRange *= 3;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB).ToVector3() * 0.55f * Main.essScale);
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