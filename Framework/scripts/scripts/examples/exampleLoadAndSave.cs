using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleLoadAndSave : MonoBehaviour
{
    public saveObjects saveObjects;

    public int lives;
    public float idk;
    public Rigidbody rb;
    public Vector3 rbV;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        if (Input.GetKeyDown(KeyCode.H))
        {
            saveGame();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            loadGame();
        }
    }

    public void saveGame()
    {
        saveObjects.SavePosition("playerLocation", this.gameObject.transform);
        saveObjects.SaveInt("PlayerLives", "lives", lives);
        saveObjects.SaveFloat("Gravity", "G", idk);
        saveObjects.SaveVector3("velocity", "playersVelocity", rbV);
    }
    public void loadGame()
    {
        this.gameObject.transform.position = saveObjects.LoadPosition("playerLocation");
        lives = saveObjects.LoadInt("PlayerLives", "lives");
        idk = saveObjects.LoadFloat("idk", "floatValue");
        rb.velocity = saveObjects.LoadVector3("velocity", "playersVelocity");
    }
}
