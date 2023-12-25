using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour
{
    // The base URL of the API
    public string ApiUrl = "https://goldygamestudio.com/apiDemo/apiDemo.php";
    public string ApiUrlAuth = "https://goldygamestudio.com/apiDemo/apiDemoAuth.php";
    public string ApiUrlFormData = "https://goldygamestudio.com/apiDemo/apiDemoFormData.php";
    private const string authToken = "your_secret_token";

    // Start is called before the first frame update
    void Start()
    {
        // Initiates a GET request when the script starts
        StartCoroutine(GetRequest(ApiUrl));

        // Initiates a POST request with a JSON body when the script starts
        StartCoroutine(PostRequest(ApiUrl, "{ \"key\": \"value\" }"));

        // Initiates a PUT request with a JSON body when the script starts
        StartCoroutine(PutRequest(ApiUrl, "{ \"key\": \"value\" }"));

        // Initiates another POST request with data from a custom class
        MyData myData = new MyData { key = "customKey", value = "customValue" };
        StartCoroutine(PostRequestWithCustomClass(ApiUrl, myData));

        // Initiates another GET request with Authorization
        StartCoroutine(GetRequestWithAuthorization(ApiUrlAuth, authToken));

        // Initiates a POST request with a Form Data
        StartCoroutine(PostRequestFormData(ApiUrlFormData));
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

    // Coroutine for handling a POST request with data from a custom class
    IEnumerator PostRequestWithCustomClass(string url, MyData data)
    {
        // Convert the custom class to JSON
        string jsonBody = JsonUtility.ToJson(data);

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


    // Coroutine for handling a GET request with Authorization
    IEnumerator GetRequestWithAuthorization(string url, string authToken)
    {
        // Using UnityWebRequest for a GET request
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Set the authorization header
            webRequest.SetRequestHeader("Authorization", authToken);

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

    // Coroutine for handling a POST request with Form Data
    IEnumerator PostRequestFormData(string url)
    {
        // Step 1: Create a new instance of WWWForm to prepare form data
        WWWForm form = new WWWForm();

        // Step 2: Add form fields (key-value pairs) to the form
        form.AddField("username", "JohnDoe");
        form.AddField("score", 100);

        // Step 3: Create a UnityWebRequest for a POST request to the specified API URL
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        // Step 4: Send the UnityWebRequest and wait for the request to complete
        yield return www.SendWebRequest();

        // Step 5: Check if the request was successful or resulted in an error
        if (www.result == UnityWebRequest.Result.Success)
        {
            // Step 6: Log success messages and server response if successful
            Debug.Log("Form upload complete!");
            Debug.Log("Server response: " + www.downloadHandler.text);
        }
        else
        {
            // Step 7: Log an error message if the request encountered an error
            Debug.LogError("Form upload error: " + www.error);
        }
    }
}

[System.Serializable]
public class MyData
{
    public string key;
    public string value;
}