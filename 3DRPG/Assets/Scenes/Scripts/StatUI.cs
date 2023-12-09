using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatUI : MonoBehaviour
{
    public Slider healthBarSlider;
    public float decreaseSpeed = 2.0f;    // 체력바 줄어드는 속도
    public float knockbackForce = 5.0f;    // 뒤로 밀리는 힘


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster1" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= 10;

            healthBarSlider.value = Mathf.Lerp(healthBarSlider.value, healthBarSlider.value, Time.deltaTime * decreaseSpeed);

            Debug.Log("현재 체력 : " + healthBarSlider.value);


        }
        else
        {
            // 체력 0일 때
        }
    }
}
