using System.Net.Http.Headers;

class YouTrackProblemHandler : IProblemHandler
{
    public string Name => "youtrack";//TODO: implement
    static readonly HttpClient client = new HttpClient();

    // TODO: implement
    public void HandleProblem(string description/*, string[] args*/)
    {
        string url = "https://cmiag.myjetbrains.com/youtrack/api/issues?q=%23%7BScrum%20Team%201%7D%20%23Feature%20%23%7BIn%20Bearbeitung%7D%20hat:%20-%7Bvcs%20%C3%84nderungen%7D%20-%7BSupport%20und%20Unterst%C3%BCtzung%7D%20";
        // Variante A (funktional)
        HttpResponseMessage responseA = client.GetAsync(url).GetAwaiter().GetResult();

        // Variante B (objekt-orientiert)
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization= AuthenticationHeaderValue.Parse("Bearer perm:xyz");

        HttpResponseMessage responseB = client.SendAsync(request).GetAwaiter().GetResult();

        var response = responseB;
        response.EnsureSuccessStatusCode();
        string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        Console.WriteLine(responseBody);
    }
}
