using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    public int exp;

    public int hp;
    public int mp;
    public int spd;
    public int aspd;
    public int intel;

    public float[] position;

    public GameData(GameManager gm) {

        level = gm.level;
        exp = gm.exp;
        hp = gm.hp;
        mp = gm.mp;
        spd = gm.spd;
        aspd = gm.aspd; 
        intel = gm.intel;

        position = new float[2];
        position[0] = gm.lastCheckPointPos.x;
        position[1] = gm.lastCheckPointPos.y;
    }
 
}
