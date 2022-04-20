using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public class CustomMapMaker : MonoBehaviour
{


    public GameObject[] prefabs;
    public char[] charPrefabs;
    public bool useData;

    

    public Vector3[] PositionInput;
    public Vector3[] RotationInput;
    public Vector3[] ScaleInput;
    public char[] PrefabInput;

    public String pos;
    public String rot;
   public String scl;
    public String pre;

    public String fullString;// = "-1.374414X-0.8481967Y2.455494Z-0.3645067X-0.7204889Y2.433939Z0.6519375X-0.8481967Y2.557558Z-0.4820854X-0.8481967Y-1.413494Z-1.317394X-0.714544Y1.426412Z-0.3544734X-0.4260125Y1.366474Z0.6471774X-0.6812739Y1.477234Z0.6500386X-0.8481967Y0.4478747Z-0.3684473X-0.7548525Y0.250568Z-1.341787X-0.8481967Y0.329258Z/12.20415X8.538605E-05Y31.8426Z29.74345X2.747152E-05Y2.899184Z19.85701X-4.084853E-06Y334.3722Z0X0Y0Z356.1915X-9.626212E-07Y39.04594Z358.1652X266.4541Y0.3456617Z2.93565X-1.709791E-06Y329.8893Z344.2798X-6.43038E-06Y337.9081Z332.459X1.384151E-06Y357.3143Z338.106X-6.624994E-05Y34.05312Z/1X-0.0504327Y1Z1X-0.0504327Y1Z1X-0.0504327Y1Z-3.367577X-0.0504327Y0.9465993Z1X-0.0504327Y1Z1X-0.0504327Y1Z1X-0.0504327Y1Z1X-0.0504327Y1Z1X-0.0504327Y1Z1X-0.0504327Y1Z/";
    public Vector3[] PositionOutput;
    public Vector3[] RotationOutput;
    public Vector3[] ScaleOutput;

    public GameObject cube;

    int ind;
    Vector3 storedValues;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Custom") == 1)
        {
            useData = true;
            fullString = PlayerPrefs.GetString("MapEditor");
        }
        pos = "A";
        rot = "B";
        scl = "K";
        Debug.Log(pos + rot + scl + "String " + fullString);
        int val = 0;
        String full = "";
        foreach (char c in fullString)
        {
            if (c == '/')
            {
                if (val == 0)
                    pos = full;
                if (val == 1)
                    rot = full;
                if (val == 2)
                    scl = full;
                full = "";
                val++;
            }
            else
                full += c;
        }
        Debug.Log(pos + rot + scl);
        if (!useData)
        compile();
        decompile();
        if (useData)
            makeMap();
    }

    public void compile()
    {
        pos = "";
        foreach (Vector3 v in PositionInput)
        {
            pos += v.x;
            pos += "X";
            pos += v.y;
            pos += "Y";
            pos += v.z;
            pos += "Z";
        }

        rot = "";
        foreach (Vector3 v in RotationInput)
        {
            rot += v.x;
            rot += "X";
            rot += v.y;
            rot += "Y";
            rot += v.z;
            rot += "Z";
        }

        scl = "";
        foreach (Vector3 v in ScaleInput)
        {
            scl += v.x;
            scl += "X";
            scl += v.y;
            scl += "Y";
            scl += v.z;
            scl += "Z";
        }
    }
    public void decompile()
    {
        PositionOutput = new Vector3[255];
        RotationOutput = new Vector3[255];
        ScaleOutput = new Vector3[255];
        //Position
        ind = 0;
        Vector3 value = new Vector3();
        char[] s = pos.ToCharArray();
        for (int i = 0; i < s.Length; i++)
        {
            String ks = "";
            for (int k = i; !char.IsLetter(s[i]) && i < s.Length; i++)
                ks += (s[i]);
            if (s[i] == 'X')
                value.x = (float)Convert.ToDouble(ks);
            if (s[i] == 'Y')
                value.y = (float)Convert.ToDouble(ks);
            if (s[i] == 'Z')
            {
                value.z = (float)Convert.ToDouble(ks);
                ks = "";
                if (ind < PositionOutput.Length)
                PositionOutput[ind] = value;
                ind++;
            }
        }

        //Rotation
        ind = 0;
        value = new Vector3();
        s = rot.ToCharArray();
        for (int i = 0; i < s.Length; i++)
        {
            String ks = "";
            for (int k = i; !char.IsLetter(s[i]) && i < s.Length; i++)
                ks += (s[i]);
            if (s[i] == 'X')
                value.x = (float)Convert.ToDouble(ks);
            if (s[i] == 'Y')
                value.y = (float)Convert.ToDouble(ks);
            if (s[i] == 'Z')
            {
                value.z = (float)Convert.ToDouble(ks);
                ks = "";
                if (ind < RotationOutput.Length)
                    RotationOutput[ind] = value;
                ind++;
            }
        }

        //Scale
        ind = 0;
        value = new Vector3();
        s = scl.ToCharArray();
        for (int i = 0; i < s.Length; i++)
        {
            String ks = "";
            for (int k = i; !char.IsLetter(s[i]) && i < s.Length; i++)
                ks += (s[i]);
            if (s[i] == 'X')
                value.x = (float)Convert.ToDouble(ks);
            if (s[i] == 'Y')
                value.y = (float)Convert.ToDouble(ks);
            if (s[i] == 'Z')
            {
                value.z = (float)Convert.ToDouble(ks);
                ks = "";
                if (ind < ScaleOutput.Length)
                    ScaleOutput[ind] = value;
                ind++;
            }
        }
    }

    public void makeMap()
    {
        String found = "";
        int spot = fullString.Length - 1;
        while (Array.IndexOf(charPrefabs,fullString.ToCharArray()[spot]) > -1)
        {
            found = fullString.ToCharArray()[spot] + found;
            spot--;
        }
        Debug.Log("LETTERS ARE " + found);
        for (int i = 0; i < ScaleOutput.Length; i++) {
            if (ScaleOutput[i] != new Vector3())
            {
                GameObject ci = Instantiate(prefabs[Array.IndexOf(charPrefabs, found[i])]);
                Debug.Log("CREATED PREFAB " + prefabs[Array.IndexOf(charPrefabs, found[i])].name);
                ci.transform.parent = null;
                ci.transform.position = PositionOutput[i];
                ci.transform.localEulerAngles = RotationOutput[i];
                ci.transform.localScale = ScaleOutput[i];
            }
        }
    }
    public void saveMap()
    {

        CubeMover[] c = FindObjectsOfType<CubeMover>();
        PositionInput = new Vector3[c.Length];
        RotationInput = new Vector3[c.Length];
        ScaleInput = new Vector3[c.Length];
        PrefabInput = new char[c.Length];
        int posi = 0;
        foreach (CubeMover k in c)
        {
            PositionInput[posi] = k.gameObject.transform.position;
            RotationInput[posi] = k.gameObject.transform.localEulerAngles;
            ScaleInput[posi] = k.gameObject.transform.localScale;
            
            PrefabInput[posi] = k.gameObject.GetComponent<CubeMover>().letter;
            posi++;
        }
        
        compile();
        String charString = "";
        foreach (char ch in PrefabInput)
            charString += ch;
        fullString = (pos + "/" + rot + "/" + scl + "/" + charString);
        pos = "";
        rot = "";
        scl = "";
        GUIUtility.systemCopyBuffer = (fullString);
    }
}
