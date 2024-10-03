

using System.Text;

namespace Maui.Plugins.Networking.Android.Samples;

public static class ConsoleWriter
{
    public static Label ConsoleDisplay;
    public static void WriteCollectionToConsole<T>(string title, IEnumerable<T> collection)
    {
        if (title != null)
            ConsoleDisplay.Text += $"{title}\n\n";
        foreach (T item in collection)
        {
            WriteObjectToConsole(null, item);
        }
    }

    public static void WriteObjectToConsole<T>(string title, T obj)
    {
        var props = obj.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        StringBuilder sb = new StringBuilder();
        if (title != null)
            sb.AppendLine(title);
        foreach (var prop in props)
        {
            if (prop.PropertyType.IsAssignableTo(typeof(ValueType)) || prop.PropertyType == typeof(string))
                sb.AppendLine(prop.Name + ": " + prop.GetValue(obj));
        }
        sb.AppendLine();
        ConsoleDisplay.Text += sb.ToString();
    }

    public static void WriteError(Exception ex)
    {
        ConsoleDisplay.Text += ex.Message + "\n" + ex.StackTrace + "\n";
    }

    public static void Write(string text = "")
    {
        ConsoleDisplay.Text += text;
    }

    public static void WriteLine(string text = "")
    {
        ConsoleDisplay.Text += text + "\n";
    }
}
