﻿using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Firebase;
using Firebase.Storage;
using Amazon.S3;
using Amazon.S3.Model;
using System.Security.AccessControl;
using UserService;
using FaceService;
using Microsoft.AspNetCore.Mvc;
using Core.Contracts.Models;

namespace DALCore.Controllers
{
    public class CompareFacesController : ControllerBase
    {
        IFace faceManager;
        public CompareFacesController(IFace _faceManager)
        {
            faceManager = _faceManager;
        }
        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("api/CompareFaces")]
        public async System.Threading.Tasks.Task<string> CompareFacesAsync([Microsoft.AspNetCore.Mvc.FromBody] CollectionName collectionId)
        {
            ForgotPasswordManager obj = new ForgotPasswordManager();
            try
            {
                return await faceManager.CompareFacesAsync(collectionId.CollectionId);
            }
            catch (Exception)
            {
                return "Exception Occurred";
            }
        }

    }
}
