using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamManager : MonoBehaviour
{
    
    #region Singleton
    public static CamManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    
    public CinemachineBrain CineBrain;
    public List<CinemachineVirtualCamera> Cams;
 
    void DisableAll()
    {
        foreach (var cam in Cams)
        {
            cam.gameObject.SetActive(false);
        }
    }
    public void SwitchCam()
    {
        if (CineBrain.ActiveVirtualCamera.Name == "MainVirtual")
        {
            DisableAll();
            Cams[1].gameObject.SetActive(true);
        }
        else
        {
            DisableAll();
            Cams[0].gameObject.SetActive(true);
        }
       
    }
}
