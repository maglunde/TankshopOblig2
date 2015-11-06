﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Image
{
    public interface IImageLogic
    {

        bool AddImage(int productId, string imageUrl);
        bool UpdateImage(int imageId, int productId, string imageUrl);
        bool DeleteImage(int imageId);
        List<Nettbutikk.Model.Image> GetAllImages();
        Nettbutikk.Model.Image GetImage(int imageId);

    }
}
