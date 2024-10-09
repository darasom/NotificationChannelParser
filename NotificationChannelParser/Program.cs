using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Test cases
        Console.WriteLine(ParseNotificationTitle("[BE][FE][Urgent] there is error"));        // Case 1
        Console.WriteLine(ParseNotificationTitle("[BE][QA][HAHA][Urgent] there is error"));  // Case 2

        // Free cases
        Console.Write("Enter notification title: ");
        string title = Console.ReadLine();
        Console.WriteLine(ParseNotificationTitle(title));
    }

    static string ParseNotificationTitle(string title) 
    {
        // List of valid channels
        List<string> validChannels = new List<string>() { "BE", "FE", "QA", "Urgent" };
        List<string> channelsFound = new List<string>();

        // Use regex to find tags in square brackets
        var matches = Regex.Matches(title, @"\[(.*?)\]");

        // Loop through matches and collect valid channels
        foreach (Match match in matches)
        {
            string channel = match.Groups[1].Value;
            if(validChannels.Contains(channel)) channelsFound.Add(channel);
        }

        // The output
        return channelsFound.Count > 0 ? $"Receive channels: {string.Join(", ", channelsFound)}" : "No valid channels found.";
    }
}