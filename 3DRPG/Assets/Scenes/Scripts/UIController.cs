using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float MaxHp = 100;
    public float currentHp = 100;
    float decreaseHp;

    // Start is called before the first frame update
    void Start()
    {
        decreaseHp = (float)currentHp / (float)MaxHp;

    }

    private void Update()
    {
        decreaseHp = (float)currentHp / (float)MaxHp;
        HandleHp();
    }

    public void HandleHp()
    {
        this.GetComponent<Slider>().value = Mathf.Lerp(this.GetComponent<Slider>().value, decreaseHp, Time.deltaTime * 10);
    }

    public void Damage(int n)
    {
        currentHp -= n;
        if (currentHp <= 0)
        {
            currentHp = 0;
        }
    }
}
