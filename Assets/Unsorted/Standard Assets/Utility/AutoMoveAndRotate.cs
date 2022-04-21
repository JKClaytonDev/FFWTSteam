using System;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace UnityStandardAssets.Utility
{
    public class AutoMoveAndRotate : MonoBehaviour
    {
        GameObject cube;
        public Vector3andSpace moveUnitsPerSecond;
        public Vector3andSpace rotateDegreesPerSecond;
        public bool ignoreTimescale;
        private float m_LastRealTime;   Vector3 lastCubePos;

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<AutoMoveAndRotate>())
                return;
            if (name.Contains("Cube") || name.Contains("Platform"))
            {
                if (col.gameObject.name.Contains("Player") || col.gameObject.transform.parent.name.Contains("Player"))
                {
                    cube.transform.position = GameObject.Find("Player").transform.position;
                    lastCubePos = cube.transform.position;
                }
                else
                    col.transform.parent = transform;
            }
            
            
        }private void OnCollisionStay(Collision col)
        {
            if (col.gameObject.GetComponent<AutoMoveAndRotate>())
                return;
            if (name.Contains("Cube") || name.Contains("Platform"))
            {
                if (col.gameObject.name.Contains("Player") || col.gameObject.transform.parent.name.Contains("Player"))
                {
                    if (lastCubePos != new Vector3())
                    {
                        GameObject.Find("Player").transform.position += cube.transform.position - lastCubePos;
                    }
                    lastCubePos = cube.transform.position;
                }
            }    
            
            
        }
        private void OnCollisionExit(Collision col)
        {
            if (col.gameObject.GetComponent<AutoMoveAndRotate>())
                return;
            if (name.Contains("Cube") || name.Contains("Platform"))
            {
                if (col.gameObject.name.Contains("Player") || col.gameObject.transform.parent.name.Contains("Player"))
                {
                    return;
                }
                else
                    col.transform.parent = null;
            }
        }
        private void Start()
        {
            cube = new GameObject();
            cube.transform.parent = transform;
            cube.transform.position = transform.position;
            m_LastRealTime = Time.realtimeSinceStartup;
        }


        // Update is called once per frame
        private void Update()
        {
            float deltaTime = Time.deltaTime;
            if (ignoreTimescale)
            {
                deltaTime = (Time.realtimeSinceStartup - m_LastRealTime);
                m_LastRealTime = Time.realtimeSinceStartup;
            }
            transform.Translate(moveUnitsPerSecond.value*deltaTime, moveUnitsPerSecond.space);
            transform.Rotate(rotateDegreesPerSecond.value*deltaTime, moveUnitsPerSecond.space);
        }


        [Serializable]
        public class Vector3andSpace
        {
            public Vector3 value;
            public Space space = Space.Self;
        }
    }
}
