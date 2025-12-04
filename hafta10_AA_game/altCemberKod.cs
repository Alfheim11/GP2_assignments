using UnityEngine;

public class altCemberKod : MonoBehaviour
{
    Rigidbody2D rigibody_;
    public int hiz;

    bool carptiMi = false;

    GameObject oyunYoneticisi;
    void Start()
    {
        rigibody_ = GetComponent<Rigidbody2D>();
        oyunYoneticisi = GameObject.FindGameObjectWithTag("oyunYoneticisi");
    }

    void FixedUpdate()
    {
        if (!carptiMi)
        {
           rigibody_.MovePosition(rigibody_.position * Vector2.up * hiz * Time.deltaTime);
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DonenCember"))
        {
            carptiMi = true;


            transform.SetParent(other.transform);

 
            rigibody_.linearVelocity = Vector2.zero;

            rigibody_.bodyType = RigidbodyType2D.Kinematic;
        }
        if (other.gameObject.CompareTag("altCember"))
        {
           oyunYoneticisi.GetComponent<oyunYoneticisi>().OyunBitti();
        }
    }
}

