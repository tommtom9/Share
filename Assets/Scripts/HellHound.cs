using UnityEngine;

public class HellHound : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        target = GameObject.Find("Target").transform;
    }
}