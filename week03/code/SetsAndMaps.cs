using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> mSet = new HashSet<string>();
        List<string> mResult = new List<string>();

        // Put all words into set
        foreach (string word in words)
        {
            mSet.Add(word);
        }

        // Look for matching words that are reversed
        foreach (string word in words)
        {
            string reverse = "" + word[1] + word[0];

            if (word[0] != word[1] && mSet.Contains(reverse))
            {
                mResult.Add(word + " & " + reverse);

                // Take out matching words
                mSet.Remove(word);
                mSet.Remove(reverse);
            }
        }
        //string[] rArray = result.ToArray();
        return mResult.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degrees = new Dictionary<string, int>();
        foreach (string line in File.ReadLines(filename))
        {
            string[] fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            string censusDegree = fields[3];

            if (degrees.ContainsKey(censusDegree))
            {
                degrees[censusDegree] = degrees[censusDegree] + 1;
            }
            else
            {
                degrees[censusDegree] = 1;
            }
        }
        // Dictionary<string, int> rDegrees =
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        Dictionary<char, int> letters = new Dictionary<char, int>();

        word1 = word1.ToLower();
        word1 = word1.Replace(" ", "");
        word2 = word2.ToLower();
        word2 = word2.Replace(" ", "");

        // Qty letters in word1
        for (int i = 0; i < word1.Length; i++)
        {
            char letter = word1[i];
            if (letters.ContainsKey(letter))
            {
                letters[letter] = letters[letter] + 1;
            }
            else
            {
                letters[letter] = 1;
            }
        }

        // Remove extras
        for (int i = 0; i < word2.Length; i++)
        {
            char letter = word2[i];

            if (letters.ContainsKey(letter) == false)
            {
                return false;
            }

            letters[letter] = letters[letter] - 1;

            if (letters[letter] < 0)
            {
                return false;
            }
        }

        // Use all of them
        foreach (char letter in letters.Keys)
        {
            //if (letters[letter] == 0)
            //{
            //    return true;
            //}
            if (letters[letter] != 0)
            {
                return false;
            }
        }
        //return false; confirmed
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}