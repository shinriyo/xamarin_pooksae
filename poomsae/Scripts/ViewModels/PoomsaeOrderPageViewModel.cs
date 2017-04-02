//-----------------------------------------------------------------------
// <copyright file="PoomsaeOrderPageViewModel.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Xamarin.Forms;

    /// <summary>
    /// PoomsaeOrderPage.xmlに対応したもの.
    /// </summary>
    public sealed class PoomsaeOrderPageViewModel
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public string Hangl { get; set; }
        public ImageSource ActionStep { get; set; }
        public string Meaning { get; set; }
        public string Order { get; set; }
        public string Detail { get; set; }
        public string NewArts { get; set; }
    }
}