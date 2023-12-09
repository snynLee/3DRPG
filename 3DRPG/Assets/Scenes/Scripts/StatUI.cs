using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatUI : MonoBehaviour
{
    public Slider healthBarSlider;
    public float decreaseSpeed = 2.0f;    // ü�¹� �پ��� �ӵ�
    public float knockbackForce = 5.0f;    // �ڷ� �и��� ��


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

            Debug.Log("���� ü�� : " + healthBarSlider.value);


        }
        else
        {
            // ü�� 0�� ��
        }
    }
}
