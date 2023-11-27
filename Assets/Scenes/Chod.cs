using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class Chod : MonoBehaviour
{
    [SerializeField]
    public static int pocet = 2;

    public static int count = 1;
   

    float speed = 2.5f;

    public static int skore = 0;//skore je pro levely

    public static int points;// points jsou pro battle pass
    [Header("Player")]
    public GameObject hrac;

    [Header("Kostièky")]
    public GameObject prek;
    public GameObject papani;
    public GameObject boost;
    public GameObject hajzl;

    // Start is called before the first frame update
    public GameObject screen;
   
    void Start()
    {
        Papat();
        Hajzl();
    }

    // Update is called once per frame
    void Update()
    {
        hrac.transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
            Prek();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hrana")
            Pohyb();

        if (collision.gameObject.tag == "Hajzl")
        {
            Destroy(collision.gameObject);
            Pohyb();

        }
        if (collision.gameObject.tag == "Boost")
        {
            Destroy(collision.gameObject);
            Boost();
        }
        if(collision.gameObject.tag == "Papani")
        {
            skore ++;
            points++;
            
           
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Dom" && skore == pocet)
        {
            Time.timeScale = 0f;
            screen.SetActive(true);
            
        }
        if (collision.gameObject.tag == "Dom" && skore != pocet)
        {
            Debug.LogError("Papej dal");
        }
    }
  
    public void Pohyb()
    {
        for (int i = 0; i < 20; i++)
        {
            hrac.transform.position -= transform.forward * speed * Time.deltaTime;
        }
        Time.timeScale = 0f;
        hrac.transform.Rotate(new Vector3(0f, 90f, 0f));
        Time.timeScale = 1f;
    }
    public void Prek()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            Vector3 worldPos = hit.point;
            worldPos.y = 0;

            var k = Instantiate(prek, worldPos, Quaternion.identity);

            Destroy(k.gameObject, 3f);
        }
    }
    public void Hajzl()
    {
        for (int i = 0; i < count; i++)
        {
            var position = new Vector3(Random.Range(-7.0f, 7.0f), 0, Random.Range(-7.0f, 7.0f));
            Instantiate(hajzl, position, Quaternion.identity);
            var pos = new Vector3(Random.Range(-7.0f, 7.0f), 0, Random.Range(-7.0f, 7.0f));
            Instantiate(boost, pos, Quaternion.identity);

        }

    }
    public void Boost()
    {
        speed = 5f;
        StartCoroutine(Timer());
    }
    public void Papat()
    {
        for(int i = 0; i < pocet; i++)
        {
            var position = new Vector3(Random.Range(-7.0f, 7.0f), 0, Random.Range(-7.0f, 7.0f));
            Instantiate(papani, position, Quaternion.identity);
           
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        speed = 2.5f;
    }
}


