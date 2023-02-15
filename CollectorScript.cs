using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    public int hay;
    public int pump;
    public int sla;
    public int graan;
    public Text hayText;
    public Text pumpText;
    public Text slaText;

    public int food1;
    public int food2;
    public Text food1Text;
    public Text food2Text;

    public int food1UI;
    public int food2UI;
    public Text food1TextUI;
    public Text food2TextUI;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hay"))
        {
            if (hay < 3)
            {
                hay++;
                StartCoroutine(DeactivateAndReappear(other.gameObject, 15f));
            }
        }
        else if (other.gameObject.CompareTag("Pumpkin"))
        {
            if (pump < 3)
            {
                pump++;
                StartCoroutine(DeactivateAndReappear(other.gameObject, 15f));
            }
        }
        else if (other.gameObject.CompareTag("Sla"))
        {
            if (sla < 3)
            {
                sla++;
                StartCoroutine(DeactivateAndReappear(other.gameObject, 15f));
            }
        }
        else if (other.gameObject.CompareTag("ShopFood1"))
        {
            if (hay >= 3 && pump >= 3)
            {
                hay -= 3;
                pump -= 3;
                food1++;
            }
        }
        else if (other.gameObject.CompareTag("ShopFood2"))
        {
            if (hay >= 3 && sla >= 3)
            {
                hay -= 3;
                sla -= 3;
                food2++;
            }
        }
        else if (other.gameObject.CompareTag("Food1"))
        {
            if (food1 >= 1)
            {
                food1UI++;
                food1 -= 1;
            }
        }
        else if (other.gameObject.CompareTag("Food2"))
        {
            if (food2 >= 1)
            {
                food2UI++;
                food2 -= 1;
            }
        }
    }

    private IEnumerator DeactivateAndReappear(GameObject obj, float seconds)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
    }

    private void Update()
    {
        hayText.text = hay.ToString();
        pumpText.text = pump.ToString();
        slaText.text = sla.ToString();

        food1Text.text = food1.ToString();
        food2Text.text = food2.ToString();

        food1TextUI.text = food1UI.ToString();
        food2TextUI.text = food2UI.ToString();
    }
}