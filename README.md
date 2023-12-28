
# Unity API Demo

This Unity project demonstrates how to make API calls using UnityWebRequest. The project includes examples of GET, POST, and PUT requests with different data formats.

## Getting Started

### Prerequisites

- [Unity](https://unity.com/) installed on your machine.

### Clone the Repository

```bash
git clone https://github.com/riken96/API_Unity.git
cd API_Unity
```

## Usage

1. Open the Unity project in the Unity Editor.
2. Open the `ApiManager` script in the Editor.
3. Modify the `ApiUrl`, `ApiUrlAuth`, and `ApiUrlFormData` variables with your API endpoints.
4. Replace the `authToken` variable with your actual authentication token.

## Examples

### GET Request

```csharp
StartCoroutine(GetRequest(ApiUrl));
```

### POST Request with JSON Body

```csharp
StartCoroutine(PostRequest(ApiUrl, "{ \"key\": \"value\" }"));
```

### PUT Request with JSON Body

```csharp
StartCoroutine(PutRequest(ApiUrl, "{ \"key\": \"value\" }"));
```

### POST Request with Custom Class

```csharp
MyData myData = new MyData { key = "customKey", value = "customValue" };
StartCoroutine(PostRequestWithCustomClass(ApiUrl, myData));
```

### GET Request with Authorization

```csharp
StartCoroutine(GetRequestWithAuthorization(ApiUrlAuth, authToken));
```

### POST Request with Form Data

```csharp
StartCoroutine(PostRequestFormData(ApiUrlFormData));
```

## Contributing

Contributions are welcome! If you find a bug or have a suggestion, please [open an issue](https://github.com/riken96/API_Unity/issues).


