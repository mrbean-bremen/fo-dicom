// Copyright (c) 2012-2023 fo-dicom contributors.
// Licensed under the Microsoft Public License (MS-PL).
#nullable disable

#if WINDOWS
using System.Windows.Media.Imaging;
#endif

using System.Drawing;
using FellowOakDicom.Imaging;
using Xunit;

namespace FellowOakDicom.Tests.Imaging
{

    [Collection(TestCollections.General)]
    public class WPFImageTest
    {
#region Unit tests

#if WINDOWS
        [Fact]
        public void As_BitmapSource_ReturnsBitmapSource()
        {
            var image = new WPFImage(100, 100);
            image.Render(3, false, false, 0);
            Assert.IsAssignableFrom<BitmapSource>(image.As<BitmapSource>());
        }

        [Fact]
        public void As_Bitmap_Throws()
        {
            var image = new WPFImage(100, 100);
            image.Render(3, false, false, 0);
            Assert.Throws<DicomImagingException>(() => image.As<Bitmap>());
        }

#endif

#endregion
    }
}
