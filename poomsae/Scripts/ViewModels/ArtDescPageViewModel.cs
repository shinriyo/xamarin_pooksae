﻿//-----------------------------------------------------------------------
// <copyright file="ArtDescPageViewModel.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Xamarin.Forms;

    /// <summary>
    /// ArtDescPage.xmlに対応したもの.
    /// </summary>
    public sealed class ArtDescPageViewModel
    {
        public string Name { get; set; }
        public ImageSource Picture { get; set; }
        public string Desc { get; set; }
        public string KoreanName { get; set; }
    }
}