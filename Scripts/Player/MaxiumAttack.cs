using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaxiumAttack : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;

    // Start is called before the first frame update

    private void Start()
    {
        SoundManager.Instance.PlayerDeadSound();
    }
}
