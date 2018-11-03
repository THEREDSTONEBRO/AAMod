using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items;

namespace CalamityMod.Items.Weapons 
{
	public class YharimsCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yharim's Crystal");
			Tooltip.SetDefault("Fires a beam of complete destruction\n" +
	        	"Only those that are worthy can use this item before Yharon is defeated");
		}

	    public override void SetDefaults()
	    {
	        item.damage = 250;
	        item.magic = true;
	        item.mana = 125;
	        item.width = 16;
	        item.height = 16;
	        item.useTime = 10;
	        item.useAnimation = 10;
	        item.reuseDelay = 5;
	        item.useStyle = 5;
	        item.UseSound = SoundID.Item13;
	        item.noMelee = true;
	        item.noUseGraphic = true;
			item.channel = true;
	        item.knockBack = 0f;
	        item.value = 100000000;
	        item.shoot = mod.ProjectileType("YharimsCrystal");
	        item.shootSpeed = 30f;
	    }
	    
	    public override void ModifyTooltips(List<TooltipLine> list)
	    {
	        foreach (TooltipLine line2 in list)
	        {
	            if (line2.mod == "Terraria" && line2.Name == "ItemName")
	            {
	                line2.overrideColor = new Color(255, Main.DiscoG, 53);
	            }
	        }
	    }
	    
	    public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
	    	bool playerName = 
	    		player.name == "Fabsol" ||
	    		player.name == "Ziggums" || 
	    		player.name == "Poly" || 
	    		player.name == "Zach" || 
	    		player.name == "Grox" || 
	    		player.name == "Jenosis" || 
	    		player.name == "DM DOKURO" || 
	    		player.name == "Danny" || 
	    		player.name == "Phoenix" || 
	    		player.name == "Vlad" || 
	    		player.name == "Khaelis" || 
	    		player.name == "Purple Necromancer" || 
	    		player.name == "Spoopyro" || 
	    		player.name == "Svante" || 
	    		player.name == "Puff" || 
	    		player.name == "Echo" || 
	    		player.name == "Testdude";
	    	bool yharon = CalamityWorld.downedYharon;
	    	if (playerName || yharon)
	    	{
	    		Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("YharimsCrystal"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
	    		return false;
	    	}
	    	else
	    	{
	    		Projectile.NewProjectile(position.X, position.Y, 0f, 0f, 29, 0, 0f, player.whoAmI, 0.0f, 0.0f);
	    		return false;
	    	}
		}
	}
}