using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee   //where is located
{
    public class Lolkat : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Lolkat");
            Tooltip.SetDefault(@"Memes memes memes galore
Meowmere EX");
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Melee/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
        }

        public override void SetDefaults()
        {

            item.damage = 450;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 64;              //Sword width
            item.height = 70;             //Sword height
            item.useTime = 10;          //how fast 
            item.useAnimation = 10;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 4;      //Sword knockback
            item.value = 300000;        
            item.rare = 11;
            item.UseSound = SoundID.Item1;       //1 is the sound of the sword
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;
            item.expert = true;
			item.shoot = 502;
			item.shootSpeed = 12f;
            item.glowMask = customGlowMask;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Meowmere);
            recipe.AddIngredient(null, "EXSoul");
            recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
