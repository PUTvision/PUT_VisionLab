using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUTVision_ICamera
{
    public interface ICamera
    {
        void Open();
        void Capture(int _imageNumber, bool _enableImageSave, bool _enableImageShow);
        void Close();
    }
}
