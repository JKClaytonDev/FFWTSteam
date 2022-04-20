using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicHost : MonoBehaviour
{
    public float foundTime;
    public float nowTime;
    public AudioSource source;
    public AudioClip[] loud;
    public AudioClip[] quiet;
    public AudioClip[] transfers;
    public AudioClip startWithTrack;
    public string[] sceneOrder;
    string wasplaying;
    // Start is called before the first frame update
    void Start()
    {
        wasplaying = "transfer";
        source = GetComponent<AudioSource>();
        if (startWithTrack)
            source.PlayOneShot(startWithTrack);
        else
        source.PlayOneShot(quiet[Random.Range(0, quiet.Length - 1)]);
    }

    // Update is called once per frame
    void Update()
    {
        if (nowTime + 1 > Time.realtimeSinceStartup && wasplaying == "quiet") {
            source.Stop();
        }
        if (foundTime + 5 < Time.realtimeSinceStartup && wasplaying == "loud")
        {
            source.Stop();
        }
            if (!source.isPlaying)
        {
            if (foundTime+5 > Time.realtimeSinceStartup)
            {
                if (wasplaying == "transfer")
                {
                    wasplaying = "loud";
                    source.PlayOneShot(loud[Random.Range(0, quiet.Length - 1)]);
                }
                else
                {
                    wasplaying = "transfer";
                    source.PlayOneShot(transfers[Random.Range(0, quiet.Length - 1)]);
                }
            }
            else
            {

                    wasplaying = "quiet";
                    source.PlayOneShot(quiet[Random.Range(0, quiet.Length - 1)]);
            }

        }
    }
}
