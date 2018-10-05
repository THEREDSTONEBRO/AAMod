using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Equinox
{
    public class Equinox : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Equinox");
            Tooltip.SetDefault(
@"Gives immensely increased stats
'True balance'");

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 8));
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.rare = 11;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateEquip(Player player)
        {
                player.lifeRegen += 6;
                player.statDefense += 9;
                player.meleeSpeed += 0.35f;
                player.meleeDamage += 0.35f;
                player.meleeCrit += 5;
                player.rangedDamage += 0.35f;
                player.rangedCrit += 5;
                player.magicDamage += 0.35f;
                player.magicCrit += 5;
                player.pickSpeed -= 0.35f;
                player.minionDamage += 0.35f;
                player.minionKB += 0.75f;
                player.thrownDamage += 0.35f;
                player.thrownCrit += 5;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoR, 125, Main.DiscoB);
                }
            }
        }
        

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.NightOwl, 3);
            player.AddBuff(BuffID.Shine, 3);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RadiantStar", 1);
            recipe.AddIngredient(null, "DarkVoid", 1);
            recipe.AddIngredient(null, "DarkMatter", 20);
            recipe.AddIngredient(null, "RadiumBar", 20);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}