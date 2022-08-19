using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterInfo : MonoBehaviour
{
    public string[] traits = new string[] { "", "", "" }; // List of current traits
    public string playerName; // holds inputted player name
    public bool pushing;      // true if player is currently pushing a capsule
    public bool squeezing;    // true if player is currently squeezing
    private string traitName; // name of trait to delete

    /// Purpose: returns true if player has inputed trait and false otherwise.
    /// Input is a string that utilizes universal naming conventions:
    /// Push Trait: "Push"
    /// Squeeze Trait: "Squeeze"
    /// Shield Trait: "CellWall"
    /// 
    /// Examples w/ {"Squeeze", "Push", ""}:
    ///     - HasTrait("Push") = true;
    ///     - HasTrait("CellWall") = false;
    public bool HasTrait(string trait)
    {
        for (int i = 0; i < 3; i++) if (traits[i] == trait) return true;
        return false;
    }

    /// Purpose: returns index of first empty slot in traits dock
    /// Example w/ {"Squeeze", "Push", ""}:
    ///     - FirstEmpty() = 2;
    public int FirstEmpty()
    {
        for (int i = 0; i < 3; i++) if (traits[i] == "") return i;
        return -1; //trait list full
    }

    /// Purpose: Adds a trait to the player's list of traits
    /// Input utilizes aforementioned naming conventions
    /// Example w/ {"Squeeze", "Push", ""}:
    ///     - AddTrait("CellWall") makes traits = {"Squeeze", "Push", "CellWall"}:
    public void AddTrait(string trait)
    {
        traits[FirstEmpty()] = trait;
    }

    /// Purpose: drop trait functionality by deleting trait from active trait list
    /// Input utilizes naming convention:
    ///     - DeleteTrait("cellWall") = Drops "CellWall" trait
    ///     - DeleteTrait("BlockPushIcon") = Drops "Push" trait
    public void DeleteTrait(string trait)
    {
        if (trait == "cellWall") traitName = "CellWall";
        else if (trait == "BlockPushIcon") traitName = "Push";
        traits[Array.IndexOf(traits, traitName)] = ""; //sets trait to empty
    }

    private void Start()
    {
        traits[0] = "Squeeze";
    }
}
