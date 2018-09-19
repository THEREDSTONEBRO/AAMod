using System.IO;
using System.Linq;
using AAMod.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod
{
    public class AAPlayer : ModPlayer
    {
        //Minions
        public bool enderMinion = false;
        // Biome bools.
        public bool ZoneMire = false;
        public bool ZoneInferno = false;
        public bool ZoneVoid = false;
        public bool ZoneRisingSunPagoda = false;
        public bool ZoneRisingMoonLake = false;
        public bool VoidUnit = false;
        public bool SunAltar = false;
        public bool MoonAltar = false;
        // Armor bools.
        public bool steelSet;
        public bool leatherSet;
        public bool silkSet;
        public bool roseSet;
        public bool mushiumSet;
        public bool kindledSet;
        public bool depthSet;
        public bool impSet;
        public bool DynaskullSet;
        public bool fleshrendSet;
        public bool nightsSet;
        public bool deathlySet;
        public bool tribalSet;
        public bool trueHallow;
        public bool trueNights;
        public bool trueFlesh;
        public bool trueTribal;
        public bool trueDeathly;
        public bool trueDemon;
        public bool darkmatterSetMe;
        public bool darkmatterSetRa;
        public bool darkmatterSetMa;
        public bool darkmatterSetSu;
        public bool darkmatterSetTh;
        public bool akumaSet;
        public bool yamataSet;
        public bool zeroSet;
        public bool valkyrieSet;
        // Accessory bools.
        public bool clawsOfChaos;
        public bool demonGauntlet;
        public bool StormClaw;
        public bool dwarvenGauntlet;
        public bool InfinityGauntlet;
        public bool TrueInfinityGauntlet;
        public bool Power;
        public bool Reality;
        public bool Mind;
        public bool Time;
        public bool Soul;
        public bool Space;
        public bool death;
        //debuffs
        public bool infinityOverload = false;
        //buffs
        //Ints
        public int camoCounter;
        public const int CAMO_DELAY = 100;

        public override void ResetEffects()
        {
            clawsOfChaos = false;
            demonGauntlet = false;
            valkyrieSet = false;
            kindledSet = false;
            depthSet = false;
            fleshrendSet = false;
            enderMinion = false;
            infinityOverload = false;
            tribalSet = false;
            impSet = false;
            trueDemon = false;
            trueDeathly = false;
            DynaskullSet = false;
            zeroSet = false;
            darkmatterSetMe = false;
            darkmatterSetRa = false;
            darkmatterSetMa = false;
            darkmatterSetSu = false;
            darkmatterSetTh = false;
            StormClaw = false;
            dwarvenGauntlet = false;
            InfinityGauntlet = false;
            Power = false;
            Reality = false;
            Mind = false;
            Time = false;
            Soul = false;
            Space = false;
            TrueInfinityGauntlet = false;
        }

        public override void UpdateBiomes()
        {
            ZoneMire = (AAWorld.mireTiles > 100);
            ZoneInferno = (AAWorld.infernoTiles > 100);
            ZoneVoid = (AAWorld.voidTiles > 50);
        }

        public override void UpdateBiomeVisuals()
        {
            bool useInferno = ZoneInferno || SunAltar;
            player.ManageSpecialBiomeVisuals("AAMod:InfernoSky", useInferno);
            bool useMire = ZoneMire || MoonAltar;
            player.ManageSpecialBiomeVisuals("AAMod:MireSky", useMire);
            bool useVoid = ZoneVoid || VoidUnit;
            player.ManageSpecialBiomeVisuals("AAMod:VoidSky", useVoid);
        }

        public override bool CustomBiomesMatch(Player other)
        {
            AAPlayer modOther = other.GetModPlayer<AAPlayer>(mod);
            return (ZoneMire == modOther.ZoneMire && ZoneInferno == modOther.ZoneInferno && ZoneVoid == modOther.ZoneVoid);
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            AAPlayer modOther = other.GetModPlayer<AAPlayer>(mod);
            modOther.ZoneInferno = ZoneInferno;
            modOther.ZoneMire = ZoneMire;
            modOther.ZoneVoid = ZoneVoid;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            byte flags = 0;
            if (ZoneInferno)
                flags |= 1;
            if (ZoneMire)
                flags |= 2;
            if (ZoneVoid)
                flags |= 3;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            byte flags = reader.ReadByte();
            ZoneInferno = ((flags & 1) == 1);
            ZoneMire = ((flags & 2) == 2);
            ZoneVoid = ((flags & 3) == 3);
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (fleshrendSet && Main.rand.Next(2) == 0)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        Dust dust;
                        Vector2 position;
                        position.X = player.Center.X - 40;
                        position.Y = player.Center.Y - 40;
                        dust = Main.dust[Dust.NewDust(position, 80, 80, 108, 0f, 0f, 124, new Color(255, 50, 0), 1f)];
                    }
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        NPC target = Main.npc[i];
                        if (target.active && !target.dontTakeDamage && !target.friendly && target.immune[player.whoAmI] == 0)
                        {
                            player.ApplyDamageToNPC(target, 30, 0, 0, false); // target , damage, knockback, direction, crit
                        }

                    }
                }
            }
        }


        public override void GetWeaponKnockback(Item item, ref float knockback)
        {
            if (demonGauntlet == true)
            {
                if (item.melee)
                {
                    knockback += 2f;
                }
            }
            if (dwarvenGauntlet == true)
            {
                if (item.melee)
                {
                    knockback += 2f;
                }
            }
        }

        public void DrawItem(int i)
        {

            if (player.HeldItem.type == mod.ItemType("VoidStar"))
            {
                Vector2 vector25 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;
                if (player.direction != 1)
                {
                    vector25.X = (float)player.bodyFrame.Width - vector25.X;
                }
                if (player.gravDir != 1f)
                {
                    vector25.Y = (float)player.bodyFrame.Height - vector25.Y;
                }
                vector25 -= new Vector2((float)(player.bodyFrame.Width - player.width), (float)(player.bodyFrame.Height - 42)) / 2f;
                Vector2 position17 = player.RotatedRelativePoint(player.position + vector25, true) - player.velocity;
                for (int num277 = 0; num277 < 4; num277++)
                {
                    Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, 242, player.direction * 2, 0f, 150, new Color(110, 20, 0), 1.3f)];
                    dust.position = position17;
                    dust.velocity *= 0f;
                    dust.noGravity = true;
                    dust.fadeIn = 1f;
                    dust.velocity += player.velocity;
                    if (Main.rand.Next(2) == 0)
                    {
                        dust.position += Utils.RandomVector2(Main.rand, -4f, 4f);
                        dust.scale += Main.rand.NextFloat();
                        if (Main.rand.Next(2) == 0)
                        {
                            dust.customData = this;
                        }
                    }
                }
            }
        }

        public virtual float UseTimeMultiplier(Item item, Player player)
        {
            float multiplier = 1f;

            int useTime = item.useTime;

            int useAnimate = item.useAnimation;
            if (StormClaw == true)
            {
                if (item.autoReuse == false)
                {
                    multiplier *= 2f;
                }
            }

            while (useTime / multiplier < 1)
            {
                multiplier -= .1f;
            }

            while (useAnimate / multiplier < 2)
            {
                multiplier -= .1f;
            }

            return multiplier;
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (trueDeathly && player.FindBuffIndex(mod.BuffType("UnstableSoul")) == -1)
            {
                player.statLife = 100;
                player.HealEffect(20);
                player.immune = true;
                player.immuneTime = player.longInvince ? 180 : 120;
                Main.NewText("Your soul ripples", 51, 255, 255);
                player.AddBuff(mod.BuffType("UnstableSoul"), 18000);
                return false;
            }
            return true;
        }
        public override void clientClone(ModPlayer clientClone)
        {
            AAPlayer clone = clientClone as AAPlayer;
            // Here we would make a backup clone of values that are only correct on the local players Player instance.
            // Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
            // clone.someLocalVariable = someLocalVariable;
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Time)
            {
                player.respawnTimer = (int)(player.respawnTimer * .2);
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (InfinityGauntlet || TrueInfinityGauntlet)
            {
                if (AAMod.InfinityHotKey.JustPressed)
                {

                    Main.npc.Where(x => x.active && !x.townNPC && x.type != NPCID.TargetDummy && !x.boss).ToList().ForEach(x =>
                    {

                        Main.NewText("Perfectly Balanced, as all things should be");
                        if (death || TrueInfinityGauntlet)
                        {
                            player.ApplyDamageToNPC(x, damage: x.lifeMax, knockback: 0f, direction: 0, crit: true);
                            death = false;
                        }
                        else
                        {
                            death = true;
                        }
                    });
                }
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)

        {
            if (valkyrieSet && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 180);
                target.AddBuff(BuffID.Chilled, 180);
            }

            if (darkmatterSetMe && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180);
            }

            if (kindledSet && Main.rand.Next(2) == 0)
            {
                player.magmaStone = true;
            }

            if (clawsOfChaos)
            {
                player.ApplyDamageToNPC(target, 5, 0, 0, false);
            }

            if (demonGauntlet && Main.rand.Next(2) == 0)
            {
                if (WorldGen.crimson == false)
                {
                    target.AddBuff(BuffID.CursedInferno, 180);
                }
                if (WorldGen.crimson == true)
                {
                    target.AddBuff(BuffID.Ichor, 180);
                }
            }
            if (Power && Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("InfinityOverload"), 1000);
            }
            if (Time && Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 200; i++)
                {

                    target.AddBuff(BuffID.Chilled, 1200);
                }
            }

            if (zeroSet && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.WitheredArmor, 1000);
            }
        }

        public override void UpdateBadLifeRegen()
        {
            int before = player.lifeRegen;
            bool drain = false;

            if (infinityOverload)
            {
                drain = true;
                player.lifeRegen -= 60;
            }
            if (drain && before > 0)
            {
                player.lifeRegenTime = 0;
                player.lifeRegen -= before;
            }
        }

        public override void UpdateDead()
        {
            infinityOverload = false;
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (infinityOverload)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("InfinityOverloadB"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.3f;
                b *= 0.7f;
                fullBright = true;
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("InfinityOverloadR"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.7f;
                g *= 0.2f;
                b *= 0.2f;
                fullBright = true;
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("InfinityOverloadG"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.7f;
                b *= 0.1f;
                fullBright = true; if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("InfinityOverloadY"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.5f;
                g *= 0.5f;
                b *= 0.1f;
                fullBright = true; if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("InfinityOverloadP"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.6f;
                g *= 0.1f;
                b *= 0.6f;
                fullBright = true; if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("InfinityOverloadO"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.8f;
                g *= 0.5f;
                b *= 0.1f;
                fullBright = true;
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

            if (Power && proj.melee && Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("InfinityOverload"), 1000);
            }

            if (zeroSet && proj.melee && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.WitheredArmor, 1000);
            }

            if (zeroSet && proj.ranged && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.WitheredArmor, 1000);
            }

            if (Power && proj.ranged && Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("InfinityOverload"), 1000);
            }

            if (Power && proj.magic && Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("InfinityOverload"), 1000);
            }

            if (Power && proj.minion && Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("InfinityOverload"), 1000);
            }

            if (Power && proj.thrown && Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("InfinityOverload"), 1000);
            }

            if (Time && proj.melee && Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 200; i++)
                {
                    target.AddBuff(BuffID.Chilled, 180);
                }
            }

            if (Time && proj.ranged && Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 200; i++)
                {
                    target.AddBuff(BuffID.Chilled, 180);
                }
            }

            if (Time && proj.magic && Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 200; i++)
                {
                    target.AddBuff(BuffID.Chilled, 180);
                }
            }

            if (Time && proj.minion && Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 200; i++)
                {
                    target.AddBuff(BuffID.Chilled, 180);
                }
            }

            if (Time && proj.thrown && Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 200; i++)
                {
                    target.AddBuff(BuffID.Chilled, 180);
                }
            }

            if (DynaskullSet && proj.thrown && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Confused, 180);
            }

            if (valkyrieSet && proj.melee && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 180);
                target.AddBuff(BuffID.Chilled, 180);
            }

            if (valkyrieSet && proj.thrown && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 180);
                target.AddBuff(BuffID.Chilled, 180);
            }

            if (depthSet && proj.ranged && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Poisoned, 180);
            }

            if (impSet && proj.minion && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.OnFire, 180);
            }

            if (clawsOfChaos == true)
            {
                player.ApplyDamageToNPC(target, 5, 0, 0, false);
            }

            if (StormClaw == true)
            {
                player.ApplyDamageToNPC(target, 40, 0, 0, false);
            }

            if (trueDemon && proj.minion && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.ShadowFlame, 300);
            }

            if (darkmatterSetMe && proj.melee && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180);
            }

            if (darkmatterSetRa && proj.ranged && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180);
            }

            if (darkmatterSetMa && proj.magic && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180);
            }

            if (darkmatterSetSu && proj.minion && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180);
            }

            if (darkmatterSetTh && proj.thrown && Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180);
            }

            if (demonGauntlet && proj.melee && Main.rand.Next(2) == 0)
            {
                if (WorldGen.crimson == false)
                {
                    target.AddBuff(BuffID.CursedInferno, 180);
                }
                if (WorldGen.crimson == true)
                {
                    target.AddBuff(BuffID.Ichor, 180);
                }
            }

        }

        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            if (camoCounter > 0)
            {
                float camo = 1 - (.75f / CAMO_DELAY) * camoCounter;
                drawInfo.upperArmorColor = Color.Multiply(drawInfo.upperArmorColor, camo);
                drawInfo.middleArmorColor = Color.Multiply(drawInfo.middleArmorColor, camo);
                drawInfo.lowerArmorColor = Color.Multiply(drawInfo.lowerArmorColor, camo);
                camo *= camo;
                drawInfo.hairColor = Color.Multiply(drawInfo.hairColor, camo);
                drawInfo.eyeWhiteColor = Color.Multiply(drawInfo.eyeWhiteColor, camo);
                drawInfo.eyeColor = Color.Multiply(drawInfo.eyeColor, camo);
                drawInfo.faceColor = Color.Multiply(drawInfo.faceColor, camo);
                drawInfo.bodyColor = Color.Multiply(drawInfo.bodyColor, camo);
                drawInfo.legColor = Color.Multiply(drawInfo.legColor, camo);
                drawInfo.shirtColor = Color.Multiply(drawInfo.shirtColor, camo);
                drawInfo.underShirtColor = Color.Multiply(drawInfo.underShirtColor, camo);
                drawInfo.pantsColor = Color.Multiply(drawInfo.pantsColor, camo);
                drawInfo.shoeColor = Color.Multiply(drawInfo.shoeColor, camo);
                drawInfo.headGlowMaskColor = Color.Multiply(drawInfo.headGlowMaskColor, camo);
                drawInfo.bodyGlowMaskColor = Color.Multiply(drawInfo.bodyGlowMaskColor, camo);
                drawInfo.armGlowMaskColor = Color.Multiply(drawInfo.armGlowMaskColor, camo);
                drawInfo.legGlowMaskColor = Color.Multiply(drawInfo.legGlowMaskColor, camo);
            }
        }


        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneMire)
            {
                return mod.GetTexture("Map/MireMap");
            }
            if (ZoneInferno)
            {
                return mod.GetTexture("Map/InfernoMap");
            }
            if (ZoneVoid)
            {
                return mod.GetTexture("Map/VoidMap");
            }
            return null;
        }
    }
}
