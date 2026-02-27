using System.Globalization;
using System.Text.Json;
using CW10B.Repository;

namespace CW10B.Extensions;

public static class RepositoryExtemsions
{
    public static void CreateBackUp(this ProductRepository repository)
    {
        PersianCalendar calendar = new PersianCalendar();
        string fileName = calendar.GetYear(DateTime.Now) + calendar.GetMonth(DateTime.Now).ToString() + calendar.GetDayOfMonth(DateTime.Now);
        var data = repository.GetAll();
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(fileName, json);
    }
}