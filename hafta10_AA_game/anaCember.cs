using System;
using UnityEngine;
using UnityEngine.UI;

public class anacember : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject altCember;

    public GameObject DonenCember;

    public GameObject oyunYoneticisi;

    public int atisSayisi = 8;
    void Start()
    {
        oyunYoneticisi = GameObject.FindGameObjectWithTag("oyunYoneticisi");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(altCember, transform.position, transform.rotation);

            for (int i = 0; i < transform.childCount; i++)
            {
                // her atýþ yapýldýðýnda sayýlarý 1 eksiltiyoruz..
                int sayi = Convert.ToInt32(transform.GetChild(i).GetComponentInChildren<Text>().text);
                sayi--;
                if (sayi > 0)
                {
                    transform.GetChild(i).GetComponentInChildren<Text>().text = sayi.ToString();
                }
                else
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }

            atisSayisi--;
            if (atisSayisi == 8)
            {
                oyunYoneticisi.transform.GetComponent<oyunYoneticisi>().oyunKazandi();
            }
        }
    }
}