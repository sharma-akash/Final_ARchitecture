using UnityEngine;
using Vuforia;
using System.Collections;
// class to take action when image target is recognized
    public class Recognition_target : MonoBehaviour, ITrackableEventHandler
    {
        private TrackableBehaviour mTrackableBehaviour;
        public Transform myModelPrefab;
        public Sensor current = GameObject.Find("SensorController").GetComponent<SensorController>().ActiveSensorObject;
        public SensorController sens_controller = GameObject.Find("SensorController").GetComponent<SensorController>();

    // Use this for initialization
    void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }
        // Update is called once per frame
        void Update()
        {
        Debug.Log(current.SensorID);
            
        }
        public void OnTrackableStateChanged(
          TrackableBehaviour.Status previousStatus,
          TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
        }
        private void OnTrackingFound()
        {
        if (myModelPrefab != null) { 
            Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
            myModelTrf.parent = mTrackableBehaviour.transform;
            myModelTrf.localPosition = new Vector3(0f, -0f, 0f);
            myModelTrf.localRotation = Quaternion.LookRotation(Camera.current.transform.forward);
            myModelTrf.localScale = new Vector3(1f, 1f, 1f);
            myModelTrf.gameObject.active = true;
            Debug.Log("Recognized!");
    }
    }
    }
