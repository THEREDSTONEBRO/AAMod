using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace AAMod.Items.Armor.GoblinSlayer
{
    [AutoloadEquip(EquipType.Head)]
	public class GoblinSlayerHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Slayer's Helm");
			Tooltip.SetDefault(@"An immense hatred of Goblinkind haunts this helm");

		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.value = Item.sellPrice (0, 0, 5, 0);
			item.rare = 3;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GoblinSlayerChest") && legs.type == mod.ItemType("GoblinSlayerGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = @"500% increased damage and knockback to goblins
80% damage resistance from goblins
'I hunt goblins or nothing.'";
            player.GetModPlayer<AAPlayer>(mod).goblinSlayer = true;
                Color newColor = Main.hslToRgb(Main.rgbToHsl(player.eyeColor).X, 1f, 0.5f);
                int num88 = (player.direction == 1) ? 0 : -4;
                int num89 = (player.gravDir == 1f) ? player.height : 0;
                for (int num90 = 0; num90 < 2; num90++)
                {
                    Dust dust10 = Main.dust[Dust.NewDust(player.position, player.width, player.height, 182, player.velocity.X, player.velocity.Y, 127, newColor, 1f)];
                    dust10.noGravity = true;
                    dust10.fadeIn = 1f;
                    dust10.scale = 1f;
                    dust10.noLight = true;
                    if (num90 == 0)
                    {
                        dust10.position = new Vector2(player.position.X + (float)num88, player.position.Y + (float)num89);
                        dust10.velocity.X = dust10.velocity.X * 1f - 2f - player.velocity.X * 0.3f;
                        dust10.velocity.Y = dust10.velocity.Y * 1f + 2f * player.gravDir - player.velocity.Y * 0.3f;
                    }
                    else if (num90 == 1)
                    {
                        dust10.position = new Vector2(player.position.X + (float)player.width + (float)num88, player.position.Y + (float)num89);
                        dust10.velocity.X = dust10.velocity.X * 1f + 2f - player.velocity.X * 0.3f;
                        dust10.velocity.Y = dust10.velocity.Y * 1f + 2f * player.gravDir - player.velocity.Y * 0.3f;
                    }
                    Dust dust11 = Dust.CloneDust(dust10);
                    dust11.scale *= 0.65f;
                    dust11.fadeIn *= 0.65f;
                    dust11.color = new Color(255, 255, 255, 255);
                    dust10.noLight = true;
                    dust10.shader = GameShaders.Armor.GetSecondaryShader(player.cWings, player);
                }
        }
	}
}