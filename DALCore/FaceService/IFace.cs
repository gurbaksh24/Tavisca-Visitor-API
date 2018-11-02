﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FaceService
{
    public interface IFace
    {
        System.Threading.Tasks.Task<string> CompareFacesAsync(string collectionName);
        System.Threading.Tasks.Task<string> AddANewFaceAsync(string imageId);
    }
}

