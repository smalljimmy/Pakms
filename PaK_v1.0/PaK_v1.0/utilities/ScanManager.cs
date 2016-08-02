using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIA;

namespace PaK_v1._0.utilities
{
    static class ScanManager
    {
        public static object ScanImage()
        {
            
            try
            {
                var dlg = new WIA.CommonDialog();
                Device device = dlg.ShowSelectDevice(WIA.WiaDeviceType.VideoDeviceType, true, false);

                if (device != null)
                {

                    // Now let's take a picture !
                    Item item = device.ExecuteCommand(CommandID.wiaCommandTakePicture);

                    ImageFile img = (ImageFile)dlg.ShowTransfer(item);
                    return img.FileData.get_BinaryData();

                }

            }
            catch (Exception ex)
            {
            }

            return null;
        }

    }
}
