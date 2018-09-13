using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AAMod.UI;

namespace AAMod.Items.Tools
{
    public class Terratool : ModItem
    {
        public static bool AxeBool = false;
        public static bool PickBool = false;
        public static bool HammerBool = false;

        public override void SetDefaults()
        {
            item.damage = 40;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 5;
            item.useAnimation = 20;
            item.pick = 0;
            item.axe = 0;
            item.hammer = 0;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 1000000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terratool");
            Tooltip.SetDefault("");
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }

        public override void PostUpdate()
        {
            if (PickBool)
            {
                item.pick = 300;
            }
            else
            {
                item.pick = 0;
            }
            if (AxeBool)
            {
                item.axe = 60;
            }
            else
            {
                item.axe = 0;
            }
            if (HammerBool)
            {
                item.hammer = 300;
            }
            else
            {
                item.hammer = 0;
            }
        }

        public override void RightClick(Player player)
        {
            if (AAMod.instance.UserInterface != null)
            {
                Main.PlaySound(SoundID.MenuOpen);
                TerratoolUI.visible = true;
                AAMod.instance.UserInterface.SetState(AAMod.instance.TerratoolUI);
            }
            else
            {
                Main.PlaySound(SoundID.MenuClose);
                TerratoolUI.visible = false;
                AAMod.instance.UserInterface.SetState(null);
            }
        }
    }
}
