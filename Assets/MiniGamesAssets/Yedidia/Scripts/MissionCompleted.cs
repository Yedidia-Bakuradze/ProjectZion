using System;
using MiniGamesAssets.Yedidia.Scripts;
using UnityEngine;

public class MissionCompleted : MonoBehaviour
{
    [SerializeField] private GameObject MissionPressBtnMsg;


    private void Awake()
    {
        Hide();
    }

    private void Start()
    {
        MissionPlate.Instance.OnShowPressBtnMsg += InstanceOnOnShowPressBtnMsg;
        MissionPlate.Instance.OnHidePressBtnMsg += InstanceOnOnHidePressBtnMsg;
    }

    private void InstanceOnOnHidePressBtnMsg(object sender, EventArgs e)
    {
        Hide();
    }

    private void InstanceOnOnShowPressBtnMsg(object sender, EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        MissionPressBtnMsg.gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        MissionPressBtnMsg.gameObject.SetActive(false);
    }
    
}
