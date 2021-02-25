using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLvlPanel : MonoBehaviour
{
    [SerializeField]private endlvl_2 endlvlItem;
    private void changeLVL()
    {
        endlvlItem.changeLVL();
    }
}
