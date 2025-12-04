using UnityEngine;

public class oyunYoneticisi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject anaCember;
    GameObject DonenCember;
    public Animator animator;
    void Start()
    {
        anaCember = GameObject.FindGameObjectWithTag("anaCember");
        DonenCember = GameObject.FindGameObjectWithTag("DonenCember");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OyunBitti()
    {
        DonenCember.GetComponent<DonenCemberKod>().enabled = false;
        anaCember.GetComponent<DonenCemberKod>().enabled = false;
        animator.SetTrigger("oyunbitti");
    }
    public void oyunKazandi()
    {
        Debug.Log("Oyun Kazandý");
    }
}
