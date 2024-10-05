using HeThongQuanLy.Models;

namespace HeThongQuanLy;

public class Constant
{
    public const string API_BASE_URL = "http://localhost:5095/";
    public static string? Current_user { get; set; } = null;

    public static User? User { get; set; }
}
