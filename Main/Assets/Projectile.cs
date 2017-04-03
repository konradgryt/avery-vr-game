using UnityEngine;
using System.Collections;

[System.Serializable]
public class Projectile : MonoBehaviour
{
    const float timeGap = 0.3f;
    float time = 0;
    bool isVibr = false;

    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= timeGap)
        {

            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            isVibr = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, 0.35f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player") && !isVibr)
        {
            isVibr = true;
            time = 0;
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
        }

        Spawner.GetInstance().Notify(go);
        Destroy(gameObject);
    }
}
