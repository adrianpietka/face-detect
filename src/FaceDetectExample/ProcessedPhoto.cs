using Microsoft.ProjectOxford.Face.Contract;
using System.Collections.Generic;
using System.IO;

namespace FaceDetectExample
{
    public class ProcessedPhoto
    {
        public readonly string PhotoPath;
        public readonly string PhotoName;
        public readonly ICollection<Face> Faces;

        public ProcessedPhoto(string photoPath, ICollection<Face> faces)
        {
            PhotoPath = photoPath;
            PhotoName = Path.GetFileName(photoPath);
            Faces = faces;
        }
        
        public override string ToString()
        {
            return string.Format("Detected {0} faces for: {1}", Faces.Count, PhotoName);
        }
    }
}
