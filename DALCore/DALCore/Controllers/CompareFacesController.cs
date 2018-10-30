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

namespace DALCore.Controllers
{

    [ApiController]
    public class CompareFacesController : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/Guard")]
        public async System.Threading.Tasks.Task<bool> CompareFacesAsync()
        {
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            ForgotPasswordManager obj = new ForgotPasswordManager();
            try
            {
                FaceManager faceManager = new FaceManager();
                return await faceManager.CompareFacesAsync();
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public void AddANewFace()
        {
            FaceManager faceManager = new FaceManager();

        }
    }
}
