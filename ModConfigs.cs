using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace UpgraderPlus
{
    public class Client : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Core Features")]
        [Label("Upgrades also increase crit damage - See Known Bugs")]
        [Tooltip("Stacks with crit rollover. Default: Disabled - Will default to Enabled in 1.4")]
        [DefaultValue(false)]
            public bool doCritDamage;
        [Label("Items autofire at level threshold")]
        [Tooltip("Upgraded items auto-reuse at & above configurable level.\nDefault: Disabled for Authentic modded experience but Recommended QoL.")]
        [DefaultValue(false)]
            public bool setReuse;
        [Label("Allow refunding Levels")]
        [Tooltip("Default: Enabled")]
        [DefaultValue(true)]
            public bool doClientRefunds;

        [Header("Tune Features")]
        [Label("+Knockback Effectiveness")]
        [Tooltip("Change the power of Knockback upgrades by X%. Default: 100%")]
        [Increment(5)]
        [Range(0, 200)]
        [DefaultValue(100)]
        [Slider]
            public int knockbackMulti;
        [Label("+Velocity Effectiveness")]
        [Tooltip("Change the power of Velocity upgrades by X%. Default: 100%")]
        [Increment(5)]
        [Range(0, 200)]
        [DefaultValue(100)]
        [Slider]
            public int velocityMulti;
        [Label("+Wing Speed Effectiveness")]
        [Tooltip("Change the power of Wing upgrades by X%. Default: 100%")]
        [Increment(5)]
        [Range(0, 200)]
        [DefaultValue(100)]
        [Slider]
            public int wingMulti;

        [Header("Disable Features")]
        [Label("Weapon size upgrades")]
        [Tooltip("Default: Enabled")]
        [DefaultValue(true)]
            public bool doSizeUpgrade;
        [Label("Weapon knockback upgrades")]
        [Tooltip("Default: Enabled")]
        [DefaultValue(true)]
            public bool doKBUpgrade;
        [Label("Wing speed upgrades")]
        [Tooltip("Default: Enabled")]
        [DefaultValue(true)]
            public bool doWingUpgrade;

        [Header("Debug")]
        [Label("Crit Rollover: Say in chat what a projectile thinks its crit is")]
        [DefaultValue(false)]
            public bool doDebug;
        [Header("See next page for more options")]
        [Tooltip("Default: Enabled")]
            public bool ThisOptionDoesNothingButItdBeFunnyIfItSecretlyRecordedWhoActivatesItInSomeSortOfMassSocialExperimentTooBadItsJustAHeader;

        public override void OnChanged()
        {
            Levelhandler.doCritDamage = doCritDamage;
            Levelhandler.setReuse = setReuse;
            Levelhandler.doClientRefunds = doClientRefunds;

            Levelhandler.velMulti = velocityMulti;
            Levelhandler.KBMulti = knockbackMulti;
            Levelhandler.wingMulti = wingMulti;
            Levelhandler.doWeaponSize = doSizeUpgrade;
            Levelhandler.doKnockback = doKBUpgrade;
            Levelhandler.doWingUpgrade = doWingUpgrade;

            Levelhandler.doDebug = doDebug;
        }
    }
    public class Server : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Core Features")]
        [Label("Change maximum upgrade cap.")]
        [Tooltip("Default: 40")]
        [Increment(5)]
        [Range(20, 255)]
        [DefaultValue(40)]
            public int tierCap;

        [Label("Stat Balance")]
        [Tooltip("0. Overpowered\n1. Default\n2. Underpowered - Some stat's don't apply")]
        [Range(0, 2)]
        [DefaultValue(1)]
        [Slider]
            public int statFormulaModel;

        [Label("Cap upgrades at 20 until hardmode?")]
        [Tooltip("Default: Enabled - Recommended Enabled")]
        [DefaultValue(true)]
            public bool doHardmodeCaps;
        [Label("Let players refund Levels")]
        [Tooltip("Serverside Override - Default: Enabled")]
        [DefaultValue(true)]
            public bool doServerRefunds;

        [Header("Tune Features")]
        [Label("Autofire Threshold")]
        [Tooltip("Change the level force autofire applies at if enabled - Default: 20\n0 makes all items autofire - 256 disables it for all players")]
        [Increment(5)]
        [Range(0, 256)]
        [DefaultValue(20)]
            public int reuseLevel;

        [Header("Fun Jank")]
        [Label("Crit chance past 100% rolls into additional crits")]
        [Tooltip("E.G: 130% crit = Default crit with a 30% chance of doing 4x. Default: Disabled")]
        [DefaultValue(false)]
            public bool critRollover;
        [Label("Slap levels on any non-stackable")]
        [Tooltip("High Velocity Wire Cutters? 4x speed Clemenator? Sure, why not. Default: Disabled")]
        [DefaultValue(false)]
            public bool anythingLevels;

        public override void OnChanged()
        {
            Levelhandler.formula = statFormulaModel;
            Levelhandler.tierCap = tierCap;
            Levelhandler.doHardmodeCap = doHardmodeCaps;
            Levelhandler.doServerRefunds = doServerRefunds;

            Levelhandler.critRollover = critRollover;
            Levelhandler.reuseLevel = reuseLevel;
            Levelhandler.anythingLevels = anythingLevels;
        }
    }

}
