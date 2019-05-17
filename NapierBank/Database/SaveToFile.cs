using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using NapierBank.Models;

namespace NapierBank.Database
{
    public class SaveToFile
    {
        // initialise string to hold the file paths for each of the 
        // different message types
        private string _smsFilePath;
        private string _emailFilePath;
        private string _tweetFilePath;

        public string ErrorCode { get; set; }

        // Constructor to hold file paths
        public SaveToFile()
        {
            _smsFilePath = "Data/sms.json";
            _emailFilePath = "Data/email.json";
            _tweetFilePath = "Data/tweet.json";


            ErrorCode = string.Empty;
        }

        #region Save SMS to Json
        // Serialises SMS to json file, spliting text up into objects.
        // Updates file if the file already exists
        public bool ToJsonSms(Sms smsMessage)
        {
            try
            {
                if (File.Exists(_smsFilePath))
                {
                    var filePath = _smsFilePath;
                    // Read existing json data
                    var jsonData = System.IO.File.ReadAllText(filePath);
                    // De-serialize to object or create new list
                    var objectList = JsonConvert.DeserializeObject<List<Sms>>(jsonData)
                                          ?? new List<Sms>();

                    objectList.Add(smsMessage);

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(objectList);
                    System.IO.File.WriteAllText(filePath, jsonData);
                }
                else
                {
                    File.Create(_smsFilePath).Dispose();
                    var filePath = _smsFilePath;
                    // Read existing json data
                    var jsonData = System.IO.File.ReadAllText(filePath);
                    // De-serialize to object or create new list
                    var objectList = JsonConvert.DeserializeObject<List<Sms>>(jsonData)
                                          ?? new List<Sms>();

                    objectList.Add(smsMessage);

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(objectList);
                    System.IO.File.WriteAllText(filePath, jsonData);
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

        #region Save EMAIL to Json
        // Serialises SMS to json file, spliting text up into objects.
        // Updates file if the file already exists
        public bool ToJsonEMail(Email emailMessage)
        {
            try
            {
                if (File.Exists(_emailFilePath))
                {
                    var filePath = _emailFilePath;
                    // Read existing json data
                    var jsonData = System.IO.File.ReadAllText(filePath);
                    // De-serialize to object or create new list
                    var objectList = JsonConvert.DeserializeObject<List<Email>>(jsonData)
                                          ?? new List<Email>();

                    objectList.Add(emailMessage);

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(objectList);
                    System.IO.File.WriteAllText(filePath, jsonData);
                }
                else
                {
                    File.Create(_emailFilePath).Dispose();
                    var filePath = _emailFilePath;
                    // Read existing json data
                    var jsonData = System.IO.File.ReadAllText(filePath);
                    // De-serialize to object or create new list
                    var objectList = JsonConvert.DeserializeObject<List<Email>>(jsonData)
                                          ?? new List<Email>();

                    objectList.Add(emailMessage);

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(objectList);
                    System.IO.File.WriteAllText(filePath, jsonData);
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

        #region Save TWEET to Json
        // Serialises SMS to json file, spliting text up into objects.
        // Updates file if the file already exists
        public bool ToJsonTweet(Tweet tweetMessage)
        {
            try
            {
                if (File.Exists(_tweetFilePath))
                {
                    var filePath = _tweetFilePath;
                    // Read existing json data
                    var jsonData = System.IO.File.ReadAllText(filePath);
                    // De-serialize to object or create new list
                    var objectList = JsonConvert.DeserializeObject<List<Tweet>>(jsonData)
                                          ?? new List<Tweet>();

                    objectList.Add(tweetMessage);

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(objectList);
                    System.IO.File.WriteAllText(filePath, jsonData);
                }
                else
                {
                    File.Create(_tweetFilePath).Dispose();
                    var filePath = _tweetFilePath;
                    // Read existing json data
                    var jsonData = System.IO.File.ReadAllText(filePath);
                    // De-serialize to object or create new list
                    var objectList = JsonConvert.DeserializeObject<List<Tweet>>(jsonData)
                                          ?? new List<Tweet>();

                    objectList.Add(tweetMessage);

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(objectList);
                    System.IO.File.WriteAllText(filePath, jsonData);
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
