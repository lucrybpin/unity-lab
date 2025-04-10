using System;
using UnityEngine;

public partial class TopDownPointAndClick_GameController
{
    [Serializable]
    public struct ClickData
    {
        public Vector3 WorldPosition;
        public TopDownPointAndClick_Interactable Interactable;
    }
}
