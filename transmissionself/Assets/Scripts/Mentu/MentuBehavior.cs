using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MentuBehavior : MonoBehaviour
{

    //A boolean that flags whether there's a connected microphone  
    private bool micConnected = false;

    //The maximum and minimum available recording frequencies  
    private int minFreq;
    private int maxFreq;

    int lenthOfMic;
    //A handle to the attached AudioSource  
    public AudioSource goAudioSource;

    /// <summary>
    /// player's body
    /// </summary>
    public GameObject left;
    public GameObject rightPlayerInterection;
    public GameObject HeadPlayerInterection;

    /// <summary>
    /// Mentu's body
    /// </summary>
    public GameObject leftMentu;
    public GameObject rightMentu;
    public GameObject HeadMentu;


    public GameObject NoticeGestureRecording;//UI notice recording motion gesture
    bool recordingGesture;
    bool HaveRecordGesture;
    bool countdown;//Comparison of the length of the array and the current frame transmitted to the objects of the Mentus
    int curentFrame;//current frame transmitted to the objects of the Mentus

    float[,] positionLHand;


    Material m_Material;
    private double nextEventTime;
    float timeOfClip;
    float[] posX;
    float[] posY;
    float[] posZ;


    int b;//counter of frame for recording motion gesture

    // Use this for initialization
    void Start()
    {
        recordingGesture = false;
        HaveRecordGesture = false;
        float[,] positionLHand = new float[b, 3];
        curentFrame = 0;
        b = 1;//counter of frame for recording motion gesture
        NoticeGestureRecording.SetActive(false);//UI notice recording motion gesture
        m_Material = GetComponent<Renderer>().material;

        foreach (string shebei in Microphone.devices)
        {
            Debug.Log("Name: " + shebei);
        }
        //Check if there is at least one microphone connected  
        if (Microphone.devices.Length <= 0)
        {
            //Throw a warning message at the console if there isn't  
            Debug.LogWarning("Microphone not connected!");
        }
        else //At least one microphone is present  
        {
            //Set 'micConnected' to true  
            micConnected = true;

            //Get the default microphone recording capabilities  
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            //According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...  
            if (minFreq == 0 && maxFreq == 0)
            {
                //...meaning 44100 Hz can be used as the recording sampling rate  
                maxFreq = 44100;
            }

            //Get the attached AudioSource component  
            goAudioSource = this.GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //test = leftPlayerInterection.GetComponent<Transform>().position.x;
        //Debug.Log(test);
        if (recordingGesture == true)
        {

            //do
            //{


            //    float[,] positionLHand = new float[b, 3];
            //    positionLHand[b,0] = leftPlayerInterection.GetComponent<Transform>().position.x;
            //    Debug.Log("X: " + positionLHand[b, 0]);

            //    positionLHand[b,1] = leftPlayerInterection.GetComponent<Transform>().position.y;
            //    Debug.Log("Y: " + positionLHand[b, 1]);
            //    positionLHand[b,2] = leftPlayerInterection.GetComponent<Transform>().position.z;
            //    Debug.Log("Z: " + positionLHand[b, 2]);

            //    b++;
            //} while (recordingGesture == false);

            for (int i = b - 1; i < b; i++)
            {
                ArrayOfGesture(i);
            }
            b++;
            Debug.Log(b+"QQQQQQQQQQQQQQQQ");

        }/*
        else if (recordingGesture == false && HaveRecordGesture == true)
        {
            if (curentFrame == positionLHand.Length)
            {
                curentFrame = 0;
            }
            else { curentFrame++; }
            
            SendValueOfGesture();



        }*/



    }

    void ArrayOfGesture(int frame)
    {
        //float[,] positionLHand = new float[b, 3];
        //positionLHand[b, 0] = leftPlayerInterection.GetComponent<Transform>().position.x;
        //Debug.Log("X: " + positionLHand[b, 0]);

        //positionLHand[b, 1] = leftPlayerInterection.GetComponent<Transform>().position.y;
        //Debug.Log("Y: " + positionLHand[b, 1]);
        //positionLHand[b, 2] = leftPlayerInterection.GetComponent<Transform>().position.z;
        //Debug.Log("Z: " + positionLHand[b, 2]);

        //b++;
        
        Debug.Log(frame);
        //for (int i = b - 1; i < b; i++)
        //{
        //    posX[i] = leftPlayerInterection.GetComponent<Transform>().position.x;
        //    Debug.Log("X: " + posX[i] + " * " + i);
        positionLHand[frame, 0] = left.GetComponent<Transform>().position.x;
        Debug.Log("X: " + positionLHand[frame, 0] + " * " + frame);
        positionLHand[frame, 1] = left.GetComponent<Transform>().position.y;
        Debug.Log("Y: " + positionLHand[frame, 1] + " * " + frame);
        positionLHand[frame, 2] = left.GetComponent<Transform>().position.z;
        Debug.Log("Z: " + positionLHand[frame, 2] + " * " + frame);
        //}


        Debug.Log("eee");

    }

    void SendValueOfGesture()
    {

        Debug.Log("sss");
        for (int i = positionLHand.Length - curentFrame; i > 0; i--)
        {
            leftMentu.transform.position = new Vector3(positionLHand[i, 0], positionLHand[i, 1], positionLHand[i, 2]);
        }


    }



    private void OnTriggerEnter(Collider collider)
    {
        //If there is a microphone  
        if (micConnected)
        {
            //If the audio from any microphone isn't being captured  
            //when Player touch record-button, the controller's color change again to something new color.
            if (!Microphone.IsRecording(null))
            {
                goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);
                Debug.Log("Microphone is recording");
                // if ButtonDown start microphone.
                m_Material.color = Color.red;
            }
        }
        else // No microphone  
        {
            //Print a red "Microphone not connected!" message at the center of the screen  
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Microphone not connected!");
        }
        Debug.Log("Staying in Trigger");
        //leftPlayerInterection.SendMessage("MicrophoneStartRecord");
        //goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);
    }
    private void OnTriggerExit(Collider collider)
    {
        StartCoroutine(IStartingPlayingAudio());
        //    Microphone.End(null); //Stop the audio recording  

        //Debug.Log("sound is playing");
        //m_Material.color = Color.white;
        //PlaySound();
    }

    void PlaySound()
    {
        //this.goAudioSource.Play(); //Playback the recorded audio
        //Debug.Log(goAudioSource.time);
        //Debug.Log("sound is playing");
        //float timeOfClip;
        //timeOfClip = this.goAudioSource.clip.length;
        //Debug.Log("timeOfClip: "+timeOfClip);

    }

    /// <summary>
    /// Stop the audio recording  , play audioclip
    /// </summary>
    /// <returns></returns>
    IEnumerator IStartingPlayingAudio()
    {
        yield return new WaitForSeconds(1f);
        if (Microphone.IsRecording(null))
        {
            Microphone.End(null); //Stop the audio recording  

            Debug.Log("Microphone was stoped");
            m_Material.color = Color.white;
            //PlaySound();

        }
        else Debug.Log("Microphone not recording now");

        NoticeGestureRecording.SetActive(true);//UI notice recording motion gesture
        recordingGesture = true;
        yield return new WaitForSeconds(3);//time for recording motion gesture
        recordingGesture = false;
        NoticeGestureRecording.SetActive(false);//UI notice recording motion gesture
        HaveRecordGesture = true;//we have record gesture
        yield return new WaitForSeconds(0.5f);
        this.goAudioSource.Play(); //Play the recorded audio
        Debug.Log(goAudioSource.time);// curent time position
        nextEventTime = 0;
        Debug.Log("sound is playing");
        timeOfClip = this.goAudioSource.clip.length;// how many sekond there are in audioclip
        Debug.Log("timeOfClip: " + timeOfClip);
        StartCoroutine(IChangePlayingPosition());




    }
    /// <summary>
    /// repeated playing audioclip 
    /// </summary>
    /// <returns></returns>
    IEnumerator IChangePlayingPosition()
    {
        yield return new WaitForSeconds(timeOfClip - 16);
        goAudioSource.PlayScheduled(nextEventTime);//change audioclip playing position to the start position (0 sek)
        StartCoroutine(IChangePlayingPosition());// repeated playing audioclip 


    }

}
