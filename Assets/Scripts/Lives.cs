using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public List<GameObject> lifeImages;
    public void SetLives(int life)
    {
        foreach (GameObject obj in lifeImages)
        {
            obj.SetActive(false);
        }

        for (int i = 0; i < life; i++)
        {
            lifeImages[i].SetActive(true);
        }
    }


}
