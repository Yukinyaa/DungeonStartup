using UnityEngine;
using System.Collections;

public class MobIsKilCheat : AbstractCheatCode
{

    protected override void OnActivateCheat()
    {
        var mobs = FindObjectsOfType<Monster>();
        foreach (var mob in mobs)
            mob.TakeDamage(int.MaxValue);


    }


    void Awake()
    {
        cheatCode = new KeyCode[] {
            KeyCode.M,
            KeyCode.O,
            KeyCode.B,
            KeyCode.I,
            KeyCode.S,
            KeyCode.K,
            KeyCode.I,
            KeyCode.L
        };
    }
}
