using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskShowPartical : MonoBehaviour
{
    [SerializeField] GameObject Partical;
    public void ShowParticle() 
    {
        Partical.SetActive(true);
        StartCoroutine(HidePartical());
    }
    IEnumerator HidePartical() 
    {
        yield return new WaitForSeconds(3.5f);
        Partical.SetActive(false);
    }
}
