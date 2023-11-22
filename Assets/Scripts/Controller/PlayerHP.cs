using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float maxHp = 10;
    private float curHp = 10;

    void Start()
    {
        hpbar.value = (float) curHp / (float) maxHp;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            curHp -= 1;
        }
      
        HandleHp();
    }

    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, curHp / (float)maxHp, Time.deltaTime * 10);
    }

}
