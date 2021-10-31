using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitChurch : Touchable {
    protected override void ReplyNun(NunController nun)
    {
        Debug.Log("Exit Level");
        gameObject.SetActive(false);
        ServiceLocator.GetService<LevelService>().NextLevel(nun.GetComponent<NunScore>().GetScore());
    }
}
