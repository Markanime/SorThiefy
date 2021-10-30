using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Touchable : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckGameObject(collision.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        CheckGameObject(collider.gameObject);
    }

    void CheckGameObject(GameObject gameObject)
    {
        var nun = gameObject.GetComponent<NunController>();
        if (nun)
        {
            ReplyNun(nun);
        }
    }

    protected virtual void ReplyNun(NunController nun)
    {

    }
}
