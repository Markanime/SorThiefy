using UnityEngine;
using System.Collections.Generic;
public static class UnityExtensions  {
    public static void LookAt2D(this Transform transform, Vector3 targetVector3)
    {
        float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(targetVector3);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);
    }

    public static T GetNearest<T>(this Transform transform, List<T> transforms)
    {
        T current = transforms[0];
        for (int i = 1; i < transforms.Count; i++)
        {
            var currentDistance = Vector2.Distance((current as Component).transform.position, transform.position);
            var newDistance = Vector2.Distance((transforms[i] as Component).transform.position, transform.position);
            if (currentDistance > newDistance)
            {
                current = transforms[i];
            }
        }
        return current;
    }
}
