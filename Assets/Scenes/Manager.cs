using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Manager : MonoBehaviour
{
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Tlacitkos()
    {
        SceneManager.LoadScene("Robo");
        Time.timeScale = 1f;
        Chod.pocet += 2;
        Chod.count += 1;
        Chod.skore = 0;
       
    }
}
