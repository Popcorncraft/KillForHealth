using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using System.ComponentModel;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using KillForHealth;

namespace KillForHealth.NPCs
{
    public class KFHPGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void OnKill(NPC npc)
	    {
            Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
            if (player.statLifeMax > 499)
            {
                if (npc.friendly == true || npc.type == NPCID.Bunny || npc.type == NPCID.Bird || npc.type == NPCID.BirdBlue || npc.type == NPCID.BirdRed || npc.type == NPCID.Squirrel || npc.type == NPCID.Mouse || npc.type == NPCID.BunnySlimed || npc.type == NPCID.Buggy || npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2 || npc.type == NPCID.Scorpion || npc.type == NPCID.ScorpionBlack || npc.type == NPCID.EnchantedNightcrawler || npc.type == NPCID.Grubby || npc.type == NPCID.Sluggy || npc.type == NPCID.Firefly || npc.type == NPCID.Frog || npc.type == NPCID.Goldfish || npc.type == NPCID.GoldfishWalker || npc.type == NPCID.GlowingSnail || npc.type == NPCID.Grasshopper || npc.type == NPCID.LightningBug || npc.type == NPCID.Penguin || npc.type == NPCID.PenguinBlack || npc.type == NPCID.Snail || npc.type == NPCID.Worm || npc.type == NPCID.Butterfly || npc.type == NPCID.GoldBird || npc.type == NPCID.GoldBunny || npc.type == NPCID.GoldButterfly || npc.type == NPCID.GoldFrog || npc.type == NPCID.GoldGrasshopper || npc.type == NPCID.GoldMouse || npc.type == NPCID.GoldWorm || npc.type == NPCID.SquirrelGold || npc.type == NPCID.TruffleWorm || npc.type == NPCID.TruffleWormDigger)
                {
                    player.statLifeMax2 += GetInstance<KillForHealthConfig>().hpGainedFriendly;
                    player.statLife += GetInstance<KillForHealthConfig>().hpGainedFriendly;
                    if (Main.myPlayer == player.whoAmI)
                    {
                        player.HealEffect(GetInstance<KillForHealthConfig>().hpGainedFriendly, true);
                    }
                    player.GetModPlayer<ExamplePlayer>().extraLife += GetInstance<KillForHealthConfig>().hpGainedFriendly;
                }
                else if (npc.boss == true) 
                {
                    player.statLifeMax2 += GetInstance<KillForHealthConfig>().hpGainedBoss;
                    player.statLife += GetInstance<KillForHealthConfig>().hpGainedBoss;
                    if (Main.myPlayer == player.whoAmI)
                    {
                        player.HealEffect(GetInstance<KillForHealthConfig>().hpGainedBoss, true);
                    }
                    player.GetModPlayer<ExamplePlayer>().extraLife += GetInstance<KillForHealthConfig>().hpGainedBoss;
                }
                else if (npc.friendly == false)
                {
                    player.statLifeMax2 += GetInstance<KillForHealthConfig>().hpGained;
                    player.statLife += GetInstance<KillForHealthConfig>().hpGained;
                    if (Main.myPlayer == player.whoAmI)
                    {
                        player.HealEffect(GetInstance<KillForHealthConfig>().hpGained, true);
                    }
                    player.GetModPlayer<ExamplePlayer>().extraLife += GetInstance<KillForHealthConfig>().hpGained;
                }
            }
        }
    }
}