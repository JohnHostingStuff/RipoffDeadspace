using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // This script stores player inventory (...that's it for now)

    public enum Item {None, Crowbar, Bone};
    public Item currentItem;

    // Start is called before the first frame update
    void Start()
    {
        currentItem = Item.None;
    }
}
