using Microsoft.ProjectOxford.Face;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FaceDetectExample
{
    public class FaceDetector
    {
        private readonly IFaceServiceClient _faceServiceClient;
        private readonly FaceAttributeType[] _requiedFaceAttributes = new FaceAttributeType[] {
            FaceAttributeType.Age,
            FaceAttributeType.Gender,
            FaceAttributeType.Smile,
            FaceAttributeType.FacialHair,
            FaceAttributeType.HeadPose,
            FaceAttributeType.Glasses
        };

        public FaceDetector(IFaceServiceClient faceServiceClient)
        {
            _faceServiceClient = faceServiceClient;
        }

        public async Task<ProcessedPhoto> DetectFaces(string photoPath)
        {
            using (var photoStream = File.OpenRead(photoPath))
            {
                var faces = await _faceServiceClient.DetectAsync(photoStream, true, true, _requiedFaceAttributes);
                return new ProcessedPhoto(photoPath, faces);
            }
        }

        public IEnumerable<ProcessedPhoto> DetectFaces(string directoryPath, string searchPattern)
        {
            var photos = Directory.GetFiles(directoryPath, searchPattern);

            foreach (var photo in photos)
            {
                yield return DetectFaces(photo).Result;
            }
        }
    }
}
