using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform A;
    public Transform B;

    public AudioClip bossLaught;
    public AudioClip laserSound;

    public Transform laser;
    public float laserTime;

    public Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = A.position;
        BossLaught();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            return;
        }


        laserTime += Time.deltaTime;
        if (laserTime > 6f)
        {
            laserTime = 0;

            laser.gameObject.SetActive(false);
            laser.GetChild(0).GetComponent<TrailRenderer>().Clear();
            laser.position = transform.position;
            laser.gameObject.SetActive(true);

            GetComponent<AudioSource>().PlayOneShot(laserSound, 0.5f);
        }

        if (transform.position == A.position)
        {
            targetPosition = B.position;
        }

        if (transform.position == B.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
    }

    private void BossLaught()
    {
        Invoke("BossLaugh", 15);
        GetComponent<AudioSource>().PlayOneShot(bossLaught);
    }

}
