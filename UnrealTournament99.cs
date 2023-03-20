using System;
using System.Collections.Generic;
using CrowdControl.Common;
using CrowdControl.Games.Packs;
using ConnectorType = CrowdControl.Common.ConnectorType;

public class UnrealTournament99 : SimpleTCPPack
{
    public override string Host => "0.0.0.0";

    public override ushort Port => 43384;

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
        new Effect("Go Third-Person", "third_person"),
        new Effect("Full Fat Tournament", "full_fat"),
        new Effect("Just Skin and Bones", "skin_and_bones"),
        new Effect("Gotta Go Fast (60 Seconds)", "gotta_go_fast"),
        new Effect("Gotta Go Slow (15 Seconds)", "gotta_go_slow"),
        new Effect("Swap Two Players Positions", "swap_player_position"),
        new Effect("Nudge All Players", "nudge"),
        new Effect("Ice Physics", "ice_physics"),
        new Effect("Low Gravity", "low_grav"),
        new Effect("Flood the Arena (20 Seconds)", "flood"),
        new Effect("Slow First Place Player", "first_place_slow"),
        new Effect("Spawn an Attacking Bot (One Death)", "spawn_a_bot_attack"),
        new Effect("Spawn a Defending Bot (One Death)", "spawn_a_bot_defend"),
        
        ////////////////////////////////////////////////////////////////
        
        //new Effect("Health and Armor","health",ItemKind.Folder),
        new Effect("Full Heal", "full_heal") { Category = "Health & Ammo" },
        new Effect("Shield Belts for All", "full_armour") { Category = "Health & Ammo" },
        new Effect("Give Health", "give_health")
        {
            Quantity = 200,
            Category = "Health & Ammo"
        },
        new Effect("Sudden Death", "sudden_death") { Category = "Health & Ammo" },
        new Effect("Thanos Snap", "thanos") { Category = "Health & Ammo" },
        new Effect("Vampiric Attacks", "vampire_mode") { Category = "Health & Ammo" },
        new Effect("Give Shield Belt to Last Place", "last_place_shield") { Category = "Health & Ammo" },
        new Effect("Blue (Redeemer) Shell", "blue_redeemer_shell") { Category = "Health & Ammo" },
        
        /////////////////////////////////////////////////////////////////
        
        //new Effect("Weapons and Damage","weapons",ItemKind.Folder),
        new Effect("Give Weapon to All", "give_weapon")
        {
            Parameters = weaponList,
            Category = "Weapons & Damage"
        }, //Needs to use a weapons list
        new Effect("Give Instagib Rifles to All", "give_instagib") { Category = "Weapons & Damage" },
        new Effect("Give Redeemers to All", "give_redeemer") { Category = "Weapons & Damage" },
        new Effect("Force Everybody to Use Weapon", "force_weapon_use")
        {
            Parameters = weaponList,
            Category = "Weapons & Damage"
        }, //Needs to use a weapons list
        new Effect("Force All Players to use Instagib Rifle", "force_instagib") { Category = "Weapons & Damage" },
        new Effect("Force All Players to use Redeemers", "force_redeemer") { Category = "Weapons & Damage" },
        new Effect("Give Ammo", "give_ammo")
        {
            Quantity = 10,
            Parameters = ammoList,
            Category = "Weapons & Damage"
        },
        new Effect("Remove All Ammo", "no_ammo") { Category = "Weapons & Damage" },
        new Effect("Bonus Damage for All", "bonus_dmg") { Category = "Weapons & Damage" },
        new Effect("Melee Only! (60 seconds)", "melee_only") { Category = "Weapons & Damage" },
        new Effect("Bonus Damage for Last Place", "last_place_bonus_dmg") { Category = "Weapons & Damage" },
        new Effect("All Players Drop Current Weapon", "drop_selected_item") { Category = "Weapons & Damage" }
    };
}
