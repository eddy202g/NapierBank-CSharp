using NapierBank.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBank.Database
{
    public class LoadFromFile
    {
        // initialise string to hold the file paths for each of the 
        // different message types
        private string _smsFilePath;
        private string _emailFilePath;
        private string _tweetFilePath;

        // Lists to hold messages
        public string ErrorCode { get; set; }
        public List<Sms> SmsMessages { get; set; }
        public List<Email> EmailMessages { get; set; }
        public List<Tweet> TweetMessages { get; set; }

        // Constructor to hold file pathsand initialise lists
        public LoadFromFile()
        {
            _smsFilePath = "Data/sms.json";
            _emailFilePath = "Data/email.json";
            _tweetFilePath = "Data/tweet.json";

            ErrorCode = string.Empty;
            SmsMessages = new List<Sms>();
            EmailMessages = new List<Email>();
            TweetMessages = new List<Tweet>();
        }

        #region Load SMS From Json
        // De-serialises SMS from json file, splitting file based on 
        // de-limiter to seperate objects
        public bool FromJsonSMS()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer(); // Initialise serialiser
                using (FileStream s = File.Open(_smsFilePath, FileMode.Open)) // Open Filestream
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        // deserialize only when there's "{" character in the stream
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var o = serializer.Deserialize<Sms>(reader);

                            SmsMessages.Add(o);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString(); // Display error code 
                return false;
            }
        }
        #endregion

        #region Load EMAIL From Json
        // De-serialises EMAIL from json file, splitting file based on 
        // de-limiter to seperate objects
        public bool FromJsonEMAIL()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                using (FileStream s = File.Open(_emailFilePath, FileMode.Open))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        // deserialize only when there's "{" character in the stream
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var o = serializer.Deserialize<Email>(reader);

                            EmailMessages.Add(o);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
        #endregion

        #region Load TWEET From Json
        // De-serialises TWEET from json file, splitting file based on 
        // de-limiter to seperate objects
        public bool FromJsonTWEET()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                using (FileStream s = File.Open(_tweetFilePath, FileMode.Open))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        // deserialize only when there's "{" character in the stream
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var o = serializer.Deserialize<Tweet>(reader);

                            TweetMessages.Add(o);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
        #endregion
    }
}
