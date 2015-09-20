using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Utilities {
    public static Quaternion LookAt(Vector2 displacement) {
        return Quaternion.Euler(0, 0, -90 + Mathf.Rad2Deg * Mathf.Atan2(displacement.y, displacement.x));
    }
}