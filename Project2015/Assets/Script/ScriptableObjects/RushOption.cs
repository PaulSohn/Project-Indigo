using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[System.Serializable]
public class RushInfo : IComparable<RushInfo> {
    static uint tick = 0;

    public uint id { get; private set; }
    public string enemyName;
    public float start = 3f;
    public float period = 2f;
    public int count = 1;
    public Vector2 position = new Vector2(0, 0);

    RushInfo(string enemyName, float start, float period, int count, Vector2 position)
    {
        this.id = tick++;
        this.enemyName = enemyName;
        this.start = start;
        this.period = period;
        this.count = count;
        this.position = position;
    }

    public RushInfo Next() {
        return new RushInfo(enemyName, start + period, period, count - 1, position);
    }

    public int CompareTo(RushInfo other) {
        int res = start.CompareTo(other.start);
        return res == 0 ? id.CompareTo(other.id) : res;
    }
}

public class RushOption : ScriptableObject {
    public RushInfo[] rushInfo;

    [MenuItem("Assets/Create/Rush Option")]
    public static void CreateRushOption() {
        CreateScriptableObjects.CreateAsset<RushOption>();
    }
}
