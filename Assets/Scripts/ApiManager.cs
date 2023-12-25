using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour
{
    // The base URL of the API
    public string ApiUrl = "https://goldygamestudio.com/apiDemo/apiDemo.php";

    // Start is called before the first frame update
    void Start()
    {
        // Initiates a GET request when the script starts
        StartCoroutine(GetRequest(ApiUrl));

        // Initiates a POST request with a JSON body when the script starts
        StartCoroutine(PostRequest(ApiUrl, "{ \"key\": \"value\" }"));

        // Initiates a PUT request with a JSON body when the script starts
        StartCoroutine(PutRequest(ApiUrl, "{ \"key\": \"value\" }"));
    }

    // Coroutine for handling a GET request
    IEnumerator GetRequest(string url)
    {
        // Using UnityWebRequest for a GET request
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Sending the request and waiting for a response
            yield return webRequest.SendWebRequest();

            // Checking if the request was successful or resulted in an error
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                // Logging the response text if successful
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }

    // Coroutine for handling a POST request with a JSON body
    IEnumerator PostRequest(string url, string jsonBody)
    {
        // Using UnityWebRequest for a POST request
        using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
        {
            // Setting up the request with a JSON body
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Sending the request and waiting for a response
            yield return webRequest.SendWebRequest();

            // Checking if the request was successful or resulted in an error
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                // Logging the response text if successful
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }

    // Coroutine for handling a PUT request with a JSON body
    IEnumerator PutRequest(string url, string jsonBody)
    {
        // Using UnityWebRequest for a PUT request
        using (UnityWebRequest webRequest = new UnityWebRequest(url, "PUT"))
        {
            // Setting up the request with a JSON body
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Sending the request and waiting for a response
            yield return webRequest.SendWebRequest();

            // Checking if the request was successful or resulted in an error
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                // Logging the response text if successful
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }
}
