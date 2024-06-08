// Copyright (C)
// See LICENSE file for extended copyright information.
// This file is part of the repository from .

using ModShardLauncher;
using ModShardLauncher.Mods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuaranteedUniques;
public class GuaranteedUniques : Mod
{
    public override string Author => "zizani";
    public override string Name => "GuaranteedUniques";
    public override string Description => "I've heard that some powerful enemies own unique gears. Defeat them and claim these !";
    public override string Version => "0.1.0.0";
    public override string TargetVersion => "0.8.2.10";

    public override void PatchMod()
    {
        Dictionary<string, (string, string[])> map_items = new()
        {
            { "W_Light", ("o_skeleton_guardianSword", new string[] { "Relict Shield" }) },
            { "W_Medium", ("o_bandit_ringleader_shield", new string[] { "Crow Heater Shield", "Joust Shield", "Uroboros Shield" }) },
            { "W_Heavy", ("o_skeleton_guardianMace", new string[] { "Guardian Shield", "Sun Shield" }) },
            { "Head_Light", ("o_bandit_paymaster", new string[] { "Hired Blade Cowl" }) },
            { "Head_Medium", ("o_bandit_ringleader_2hsword", new string[] { "Decorated Barbute" }) },
            { "Head_Heavy", ("o_proselyte_brander", new string[] { "Joust Topfhelm", "Joust Bascinet", "Pigfaced Bascinet", "Decorated Sallet", "Mastercrafted Sallet" }) },
            { "Head_Magic", ("o_necromancer_wraithbinder", new string[] { "Hermit Circlet" }) },
            { "Chest_Light", ("o_bandit_magehunter", new string[] { "Royal Ranger Gambeson" }) },
            { "Chest_Heavy", ("o_proselyte_juggernaut", new string[] { "Joust Armor", "Ceremonial Cuirass", "Vagabond Knight Armor" }) },
            { "Chest_Magic", ("o_ghast_elder", new string[] { "Druid Robe" }) },
            { "Legs_Medium", ("o_revenant", new string[] { "Engraved Boots" }) },
            { "Legs_Heavy", ("", new string[] { "Sardar Boots" }) },
            { "Ring_Light", ("o_proselyte_wormbearer", new string[] { "Hermit Ring" }) },
            { "Back_Light", ("o_proselyte_anmara", new string[] { "Azure Cape", "Occult Cloak" }) },
            { "sword", ("o_bandit_duelist", new string[] { "Fancy Sword", "Engraved Sword", "Jarl Blade", "Royal Sword", "Relict Blade", "Guard Broadsword", "Decorated Saber", "Ancient Scimitar" }) },
            { "axe", ("", new string[] { "Gilded Axe", "Feudal Axe" }) },
            { "mace", ("o_bandit_raubritter_flail", new string[] { "Decorated Flanged Mace", "Decorated Warhammer" }) },
            { "dagger", ("o_bandit_freak", new string[] { "Decorated Dagger" }) },
            { "2hsword", ("o_bandit_raubritter_2hsword", new string[] { "Ornate Greatsword", "Espadon" }) },
            { "spear", ("o_skeleton_guardianSpear", new string[] { "Faceless Spear" }) },
            { "2haxe", ("o_skeleton_guardianAxe", new string[] { "Decorated Voulge", "Ornate Longaxe" }) },
            { "2hmace", ("o_bandit_raubritter_2hmace", new string[] { "Exquisite Grandmace", "Relict Polehammer" }) },
            { "bow", ("o_bandit_longbowman", new string[] { "Decorated Longbow", "Relic Bow" }) },
            { "crossbow", ("o_bandit_huntmaster", new string[] { "Guard Crossbow" }) },
            { "2hStaff", ("o_bandit_warlock", new string[] { "Hermit Staff", "Necromancer Staff", "Vampiric Staff", "Orient Staff", "Relict Staff" }) },
        };

        foreach (KeyValuePair<string, (string, string[])> entry in map_items)
        {
            if (entry.Value.Item1 == "") continue;
            Msl.AddLootTable(
                lootTableID: entry.Key,
                guaranteedItems: new ItemsTable(
                    listItems: Array.Empty<string>(),
                    listRarity: Array.Empty<int>(),
                    listDurability: Array.Empty<int>()
                ),
                randomLootMin: 1,
                randomLootMax: 1,
                emptyWeight: 0,
                randomItemsTable: new RandomItemsTable(
                    listItems: entry.Value.Item2,
                    listRarity: Enumerable.Repeat(6, entry.Value.Item2.Length).ToArray(),
                    listDurability: Enumerable.Repeat(100, entry.Value.Item2.Length).ToArray(),
                    listWeight: Enumerable.Repeat(1, entry.Value.Item2.Length).ToArray()
                )
            );

            Msl.AddReferenceTable(
                nameObject: entry.Value.Item1,
                table: entry.Key
            );
        }
    }
}
