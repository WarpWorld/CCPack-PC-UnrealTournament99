using System;
using CrowdControl.Common;
using CrowdControl.Games.Packs;
using ConnectorType = CrowdControl.Common.ConnectorType;

public class UnrealTournament99 : SimpleTCPPack
{
    public override string Host => "0.0.0.0";

    public override ushort Port => 43384;

    public override ISimpleTCPPack.MessageFormat MessageFormat => ISimpleTCPPack.MessageFormat.CrowdControlLegacy;

    public UnrealTournament99(UserRecord player, Func<CrowdControlBlock, bool> responseHandler, Action<object> statusUpdateHandler) : base(player, responseHandler, statusUpdateHandler) { }

    public override Game Game { get; } = new(131, "Unreal Tournament 99", "UnrealTournament99", "PC", ConnectorType.SimpleTCPConnector);

    //Weapon list
    private static readonly ParameterDef weaponList = new("Weapons", "weapons",
        new Parameter("Translocator", "translocator"),
        new Parameter("Ripper", "ripper"),
        new Parameter("BioRifle", "biorifle"),
        new Parameter("Flak Cannon", "flakcannon"),
        new Parameter("Sniper Rifle", "sniperrifle"),
        new Parameter("Shock Rifle", "shockrifle"),
        new Parameter("Pulse Rifle", "pulsegun"),
        new Parameter("Minigun", "minigun"),
        new Parameter("Rocket Launcher", "rocketlauncher")
    );

    //Ammo List
    private static readonly ParameterDef ammoList = new("Ammo", "ammo",
        new Parameter("Flak Ammo", "flakammo"),
        new Parameter("BioRifle Goo", "bioammo"),
        new Parameter("Redeemer Missile", "warheadammo"),
        new Parameter("Pulse Rifle Ammo", "pammo"),
        new Parameter("Shock Rifle Core", "shockcore"),
        new Parameter("Ripper Blades", "bladehopper"),
        new Parameter("Rockets", "rocketpack"),
        new Parameter("Sniper Ammo", "bulletbox"),
        new Parameter("Minigun/Enforcer Ammo", "miniammo")
    );

    public override EffectList Effects { get; } = new Effect[]
    {
        //General Effects
        new("Go Third-Person", "third_person"),
        new("Full Fat Tournament", "full_fat"),
        new("Just Skin and Bones", "skin_and_bones"),
        new("Gotta Go Fast (60 Seconds)", "gotta_go_fast"),
        new("Gotta Go Slow (15 Seconds)", "gotta_go_slow"),
        new("Swap Two Players Positions", "swap_player_position"),
        new("Nudge All Players", "nudge"),
        new("Ice Physics", "ice_physics"),
        new("Low Gravity", "low_grav"),
        new("Flood the Arena (20 Seconds)", "flood"),
        new("Slow First Place Player", "first_place_slow"),
        new("Spawn an Attacking Bot (One Death)", "spawn_a_bot_attack"),
        new("Spawn a Defending Bot (One Death)", "spawn_a_bot_defend"),
        
        ////////////////////////////////////////////////////////////////
        
        //new Effect("Health and Armor","health",ItemKind.Folder),
        new("Full Heal", "full_heal") { Category = "Health & Ammo" },
        new("Shield Belts for All", "full_armour") { Category = "Health & Ammo" },
        new("Give Health", "give_health")
        {
            Quantity = 200,
            Category = "Health & Ammo"
        },
        new("Sudden Death", "sudden_death") { Category = "Health & Ammo" },
        new("Thanos Snap", "thanos") { Category = "Health & Ammo" },
        new("Vampiric Attacks", "vampire_mode") { Category = "Health & Ammo" },
        new("Give Shield Belt to Last Place", "last_place_shield") { Category = "Health & Ammo" },
        new("Blue (Redeemer) Shell", "blue_redeemer_shell") { Category = "Health & Ammo" },
        
        /////////////////////////////////////////////////////////////////
        
        //new Effect("Weapons and Damage","weapons",ItemKind.Folder),
        new("Give Weapon to All", "give_weapon")
        {
            Parameters = weaponList,
            Category = "Weapons & Damage"
        }, //Needs to use a weapons list
        new("Give Instagib Rifles to All", "give_instagib") { Category = "Weapons & Damage" },
        new("Give Redeemers to All", "give_redeemer") { Category = "Weapons & Damage" },
        new("Force Everybody to Use Weapon", "force_weapon_use")
        {
            Parameters = weaponList,
            Category = "Weapons & Damage"
        }, //Needs to use a weapons list
        new("Force All Players to use Instagib Rifle", "force_instagib") { Category = "Weapons & Damage" },
        new("Force All Players to use Redeemers", "force_redeemer") { Category = "Weapons & Damage" },
        new("Give Ammo", "give_ammo")
        {
            Quantity = 10,
            Parameters = ammoList,
            Category = "Weapons & Damage"
        },
        new("Remove All Ammo", "no_ammo") { Category = "Weapons & Damage" },
        new("Bonus Damage for All", "bonus_dmg") { Category = "Weapons & Damage" },
        new("Melee Only! (60 seconds)", "melee_only") { Category = "Weapons & Damage" },
        new("Bonus Damage for Last Place", "last_place_bonus_dmg") { Category = "Weapons & Damage" },
        new("All Players Drop Current Weapon", "drop_selected_item") { Category = "Weapons & Damage" }
    };
}
