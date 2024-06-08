namespace BlazorSignalRApp.Models;

public class WebCamOptions
{
    public int Width { get; set; } = 320;
    public string VideoID { get; set; }
    public string CanvasID { get; set; }
    public string Filter { get; set; } = null;
}



public class ConnectedUsers
{
    public List<string> Ids { get; set; }
}