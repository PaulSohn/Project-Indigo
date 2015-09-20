using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

public class Wall : MonoBehaviour {
    public int XSize;
    public int YSize;

    [Range(0f, 360f)]
    public float angle;

    Vector3 myX;
    Vector3 myY;

    BoxCollider2D box;

    void Awake() {
        //float COS = Mathf.Cos(angle * Mathf.Deg2Rad);
        //float SIN = Mathf.Sin(angle * Mathf.Deg2Rad);
        //myX = new Vector3(COS, SIN);
        //myY = new Vector3(-SIN, COS);

        // Sprite Settings
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject childPrefab = new GameObject();

        childPrefab.transform.position = transform.position;
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childSprite.sprite = spriteRenderer.sprite;
        GameObject child;
        Vector3 cursor = transform.position
            + new Vector3((-XSize + 1) * spriteRenderer.bounds.size.x / 2f, (-YSize + 1) * spriteRenderer.bounds.size.y / 2f);
        Vector3 cursor2;

        for (int i = 0; i < XSize; ++i) {
            cursor2 = cursor;
            for (int j = 0; j < YSize; ++j) {
                child = Instantiate(childPrefab) as GameObject;
                child.transform.position = cursor2;
                //child.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                child.transform.parent = transform;
                //cursor2 += spriteRenderer.bounds.size.y * myY;
                cursor2 += spriteRenderer.bounds.size.y * new Vector3(0, 1, 0);
            }
            cursor += spriteRenderer.bounds.size.x * new Vector3(1, 0, 0);
        }

        Destroy(childPrefab);

        // Collider Settings
        box = GetComponent<BoxCollider2D>();
        box.size = new Vector3(XSize * spriteRenderer.bounds.size.x, YSize * spriteRenderer.bounds.size.y);

        spriteRenderer.enabled = false;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void DrawRect(Color mycolor) {
        float COS = Mathf.Cos(angle * Mathf.Deg2Rad);
        float SIN = Mathf.Sin(angle * Mathf.Deg2Rad);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 S = new Vector3(XSize * spriteRenderer.bounds.size.x / 2f, YSize * spriteRenderer.bounds.size.y / 2f);
        //Rect R = new Rect(transform.position - S / 2f, S);

        Vector3 RU = new Vector3(COS * S.x + SIN * S.y, SIN * S.x - COS * S.y);
        Vector3 RD = new Vector3(COS * S.x - SIN * S.y, SIN * S.x + COS * S.y);

        Gizmos.color = mycolor;
        Gizmos.DrawLine(transform.position + RU, transform.position + RD);
        Gizmos.DrawLine(transform.position + RU, transform.position - RD);
        Gizmos.DrawLine(transform.position - RU, transform.position + RD);
        Gizmos.DrawLine(transform.position - RU, transform.position - RD);
    }

    void OnDrawGizmos() {
        if (Application.isPlaying) return;
        DrawRect(Color.cyan);
    }

    void OnDrawGizmosSelected() {
        if (Application.isPlaying) return;
        DrawRect(Color.blue);
    }
}
