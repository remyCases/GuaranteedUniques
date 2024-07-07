// Copyright (C)
// See LICENSE file for extended copyright information.
// This file is part of the repository from https://github.com/remyCases/GuaranteedUniques.

using ModShardLauncher;
using ModShardLauncher.Mods;

namespace GuaranteedUniques;
public class GuaranteedUniques : Mod
{
    public override string Author => "zizani";
    public override string Name => "GuaranteedUniques";
    public override string Description => "A more reliable way to farm unique weapons and armors.";
    public override string Version => "1.1.0";
    public override string TargetVersion => "0.8.2.10";

    public override void PatchMod()
    {
        Msl.AddCreditDisclaimerRoom(Name, Author);

        Dictionary<string, string[]> map_items = new()
        {
            { "W_Light", new string[] { "Relict Shield" } },
            { "W_Medium", new string[] { "Crow Heater Shield", "Joust Shield", "Uroboros Shield" } },
            { "W_Heavy", new string[] { "Guardian Shield", "Sun Shield" } },
            { "Head_Light", new string[] { "Hired Blade Cowl" } },
            { "Head_Medium", new string[] { "Decorated Barbute" } },
            { "Head_Heavy", new string[] { "Joust Topfhelm", "Joust Bascinet", "Pigfaced Bascinet", "Decorated Sallet", "Mastercrafted Sallet" } },
            { "Head_Magic", new string[] { "Hermit Circlet" } },
            { "Chest_Light", new string[] { "Royal Ranger Gambeson" } },
            { "Chest_Heavy", new string[] { "Joust Armor", "Ceremonial Cuirass", "Vagabond Knight Armor" } },
            { "Chest_Magic", new string[] { "Druid Robe" } },
            { "Legs_Medium", new string[] { "Engraved Boots" } },
            { "Legs_Heavy", new string[] { "Sardar Boots" } },
            { "Ring_Light", new string[] { "Hermit Ring" } },
            { "Back_Light", new string[] { "Azure Cape", "Occult Cloak" } },
            { "sword", new string[] { "Fancy Sword", "Engraved Sword", "Jarl Blade", "Royal Sword", "Relict Blade", "Guard Broadsword", "Decorated Saber", "Ancient Scimitar" } },
            { "axe", new string[] { "Gilded Axe", "Feudal Axe" } },
            { "mace", new string[] { "Decorated Flanged Mace", "Decorated Warhammer" } },
            { "dagger", new string[] { "Decorated Dagger" } },
            { "2hsword", new string[] { "Ornate Greatsword", "Espadon" } },
            { "spear", new string[] { "Faceless Spear" } },
            { "2haxe", new string[] { "Decorated Voulge", "Ornate Longaxe" } },
            { "2hmace", new string[] { "Exquisite Grandmace", "Relict Polehammer" } },
            { "bow", new string[] { "Decorated Longbow", "Relic Bow" } },
            { "crossbow", new string[] { "Guard Crossbow" } },
            { "2hStaff", new string[] { "Hermit Staff", "Necromancer Staff", "Vampiric Staff", "Orient Staff", "Relict Staff" } },
        };

        Dictionary<string, string[]> enemies_loot = new()
        {
            { "o_bandit_huntmaster", new string[] { "crossbow" } },
            { "o_bandit_freak", new string[] { "dagger", "Head_Light" } },
            { "o_bandit_paymaster", new string[] { "2hsword", "Head_Light", "Chest_Light", "Back_Light" } },
            { "o_bandit_ringleader_shield", new string[] { "sword", "Head_Medium", "Chest_Light", "Legs_Medium", "W_Medium" } },
            { "o_bandit_ringleader_2hsword", new string[] { "2hsword", "Head_Medium", "Chest_Light", "Legs_Medium" } },
            { "o_bandit_raubritter_2hsword", new string[] { "2hsword", "Head_Heavy", "Chest_Heavy", "Legs_Heavy" } },
            { "o_bandit_raubritter_2hmace", new string[] { "2hmace", "Head_Heavy", "Chest_Heavy", "Legs_Heavy" } },
            { "o_bandit_raubritter_flail", new string[] { "mace", "Head_Heavy", "Chest_Heavy", "Legs_Heavy", "W_Medium" } },
            { "o_skeleton_guardianSword", new string[] { "sword", "Head_Heavy", "Chest_Heavy", "Legs_Heavy", "W_Light" } },
            { "o_skeleton_guardianMace", new string[] { "mace", "Head_Heavy", "Chest_Heavy", "Legs_Heavy", "W_Heavy" } },
            { "o_skeleton_guardianSpear", new string[] { "spear", "Head_Heavy", "Chest_Heavy", "Legs_Heavy" } },
            { "o_skeleton_guardianAxe", new string[] { "2haxe", "Head_Heavy", "Chest_Heavy", "Legs_Heavy" } },
            { "o_revenant", new string[] { "2hsword", "Head_Medium", "Chest_Heavy", "Legs_Medium" } },
            { "o_necromancer_wraithbinder", new string[] { "2hStaff", "Head_Magic", "Chest_Magic", "Ring_Light", } },
            { "o_ghast_elder", new string[] { "2hStaff", "Head_Magic", "Chest_Magic", "Ring_Light", } },
            { "o_proselyte_brander", new string[] { "Head_Heavy" } },
            { "o_proselyte_wormbearer", new string[] { "Ring_Light", } },
            { "o_proselyte_anmara", new string[] { "axe", "bow", "Ring_Light", "Back_Light" } },
            { "o_proselyte_juggernaut", new string[] { "2hmace", "Head_Medium", "Chest_Heavy", } },
        };

        foreach (KeyValuePair<string, string[]> entry in enemies_loot)
        {
            string[] loot = entry.Value.SelectMany(x => map_items[x]).ToArray();
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
                    listItems: loot,
                    listRarity: Enumerable.Repeat(6, loot.Length).ToArray(),
                    listDurability: Enumerable.Repeat(100, loot.Length).ToArray(),
                    listWeight: Enumerable.Repeat(1, loot.Length).ToArray()
                )
            );

            Msl.AddReferenceTable(
                nameObject: entry.Key,
                table: entry.Key
            );
        }
    }
}
