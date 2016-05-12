using System.Configuration;

namespace FaceDetectExample
{
    class ConfigurationHelper
    {
        public static string FaceApiSubscriptionKey => ConfigurationManager.AppSettings["FACE_API_SUBSCRIPTION_KEY"];
        public static string InputPhotosPath => ConfigurationManager.AppSettings["INPUT_PHOTOS_PATH"];
        public static string InputPhotosMask => ConfigurationManager.AppSettings["INPUT_PHOTOS_MASK"];
        public static string ProcessedPhotoPath => ConfigurationManager.AppSettings["PROCESSED_PHOTOS_PATH"];
        public static string ResultsPath => ConfigurationManager.AppSettings["RESULTS_PATH"];
    }
}