using UnityEngine;
using System.Collections;

public class VersionControl : MonoBehaviour
{
    public string url = "http://www.nethersphere.co.za/dbtest/versionControl.php?key=1";

    [SerializeField]
    private float clientVersion = 0.01f;
    [SerializeField]
    private float serverVersion;

    void Start()
    {
        StartCoroutine(versionCheck());
    }

    IEnumerator versionCheck()
    {
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.text);

        if (www.text != null && www.text != "")
        {
            if (www.text != "Failed to get version")
            {
                serverVersion = float.Parse(www.text);
            }
            else
            {
                Debug.LogError("Server responded to versionCheck() but was not able to return the version");
            }
        }
        else
        {
            Debug.LogError("Server did not respond to versionCheck() call");
        }

        if (clientVersion != serverVersion)
        {
            Debug.LogError("Your version of this game does not match the current version");
        }
    }
}
