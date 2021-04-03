using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Code
{
    internal sealed class Radar : MonoBehaviour, IController, IRun
    {
        private Transform _playerTransform;
        private Transform __miniMapCameraTransform;
        private readonly float _mapScale = 2;
        private Camera _miniMapCamera;
        public static List<RadarObject> RadarObjects = new List<RadarObject>();

        public Radar(Transform playerTransform, Camera miniMapCamera)
        {
            _playerTransform = playerTransform;
            __miniMapCameraTransform = _miniMapCamera.GetComponent<Transform>();
            __miniMapCameraTransform = _playerTransform;
        }

        public static void RegisterRadarObject(GameObject o, Image i)
        {
            Image image = Instantiate(i);
            RadarObjects.Add(new RadarObject { Owner = o, Icon = image });
        }
		
        public static void RemoveRadarObject(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject t in RadarObjects)
            {
                if (t.Owner == o)
                {
                    Destroy(t.Icon);
                    continue;
                }
                newList.Add(t);
            }
            RadarObjects.RemoveRange(0, RadarObjects.Count);
            RadarObjects.AddRange(newList);
        }
		
        private void DrawRadarDots()
        {
            foreach (RadarObject radObject in RadarObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position -
                                    _playerTransform.position);
                float distToObject = Vector3.Distance(_playerTransform.position,
                    radObject.Owner.transform.position) * _mapScale;
                float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg -
                               270 - _playerTransform.eulerAngles.y;
                radarPos.x = distToObject* Mathf.Cos(deltay* Mathf.Deg2Rad) * -1;
                radarPos.z = distToObject* Mathf.Sin(deltay* Mathf.Deg2Rad);
                radObject.Icon.transform.SetParent(transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x,
                    radarPos.z, 0) + transform.position;
            }
        }
        
        public void Run(float deltaTime)
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
        
        public sealed class RadarObject
        {
            public Image Icon;
            public GameObject Owner;
        }
    }
}