using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public AudioSource AS;

    private int FrameCounter = 0;

    private const uint ArraySize = 64;
    private const uint DSPsize = 8;
    private float[] Arr = new float[ArraySize];

    public float[] DSP = new float[DSPsize];
    public bool[] SpawnArray = new bool[DSPsize];
    public float[] m_ThresholdValues = new float[DSPsize];
	// Update is called once per frame
	TrapSpawner trapSpawner;
	void Start()
	{
		trapSpawner = FindObjectOfType<TrapSpawner>();
	}

	void Update ()
    {
        FrameCounter++;
        if (FrameCounter > 2) //only update every 2 frames
        {
            AS.GetSpectrumData(Arr, 0, FFTWindow.BlackmanHarris); //Pass the spectrum data to the Array (Arr)
            FrameCounter = 0;
        }

        //Get the average of every 8 values in the Spectrum Array
        int DSPwidth = (int)(ArraySize / DSPsize); 
        for(int d = 0; d < DSPsize; ++d)
        {
            for(int w = 0; w < DSPwidth; ++w)
            {
                DSP[d] += Arr[w * d]; //Sum values
            }
            DSP[d] /= DSPsize; //Get average
        }

        //print debug info
        for(int i = 0; i < DSP.Length; ++i)
        {
            SpawnArray[i] = false;
            if(DSP[i] > m_ThresholdValues[i])
            {
                Debug.DrawLine(new Vector3(i,          0, 0),
                               new Vector3(i, DSP[i] * 4, 0),
                               Color.red);

                //If a value is over threshold, spawn relevant instrument
                SpawnArray[i] = true;
            }
            else
            {
                Debug.DrawLine(new Vector3(i, 0, 0),
                               new Vector3(i, DSP[i] * 4, 0),
                               Color.green);
            }
        }
		for (int i = 0; i < DSPsize; i++)
		{ trapSpawner.m_spawnTrapsBool[i] = SpawnArray[i]; }
        
	}
}
