using System;
using Microsoft.ProjectOxford.Face;
using Newtonsoft.Json;
using System.IO;

namespace FaceDetectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var faceServiceClient = new FaceServiceClient(ConfigurationHelper.FaceApiSubscriptionKey);
            var faceDetector = new FaceDetector(faceServiceClient);
            var processedPhotos = faceDetector.DetectFaces(ConfigurationHelper.InputPhotosPath, ConfigurationHelper.InputPhotosMask);

            foreach (var photo in processedPhotos)
            {
                Console.WriteLine(photo);

                File.WriteAllText(ConfigurationHelper.ResultsPath + photo.PhotoName + ".json", JsonConvert.SerializeObject(photo));
                File.Move(photo.PhotoPath, ConfigurationHelper.ProcessedPhotoPath + photo.PhotoName);
            }
        }
    }
}