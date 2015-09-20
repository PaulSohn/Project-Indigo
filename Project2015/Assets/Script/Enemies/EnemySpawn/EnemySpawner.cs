using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public RushOption rushOption;
    public Transform entityParent;

    public Enemy[] enemyList;

    float activationTime;

    Dictionary<string, Enemy> enemyMap = new Dictionary<string, Enemy>();
    SortedList<RushInfo, bool> rushHeap = new SortedList<RushInfo, bool>(); //bool값은 의미없음. 어째서 SortedSet는 이렇게 늦게 나온 것일까.

    void Awake() {
        foreach(Enemy E in enemyList) {
            enemyMap.Add(E.transform.name, E);
        }
        foreach(RushInfo ri in rushOption.rushInfo) {
            rushHeap.Add(ri, false);
        }
        activationTime = Time.time;
    }

    void Update() {
        while (rushHeap.Count != 0) {
            RushInfo miri = rushHeap.Keys[0]; //most important rush info
            if (miri.start > Time.time - activationTime) break;

            rushHeap.RemoveAt(0);

            Enemy newEnemy = (Enemy)Instantiate(enemyMap[miri.enemyName], miri.position, Quaternion.identity);
            newEnemy.transform.parent = entityParent;

            RushInfo ri = miri.Next();
            if (ri.count != 0) {
                rushHeap.Add(ri, false);
            }
        }
    }

}
