﻿using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using DALCore.Models;
using System;
using System.Linq;

namespace FaceService
{
    public class FaceManager : IFace
    {
        public async System.Threading.Tasks.Task<string> CompareFacesAsync(string collectionName)
        {
            try
            {
                string accessKeyId = "AKIAJM4TC3NLKAVPLCFQ";
                string secretAccessKey = "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";
                BasicAWSCredentials basicAWSCredentials = new BasicAWSCredentials(accessKeyId, secretAccessKey);
                AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient(basicAWSCredentials, RegionEndpoint.APSouth1);
                var response = await amazonRekognitionClient.SearchFacesByImageAsync(new SearchFacesByImageRequest
                {
                    CollectionId = collectionName,
                    FaceMatchThreshold = 80,
                    Image = new Image
                    {
                        S3Object = new Amazon.Rekognition.Model.S3Object
                        {
                            Bucket = "visitors-bucket",
                            Name = "new_visitor.jpg"
                        }
                    },
                    MaxFaces = 5
                });
                if (response.FaceMatches.Any())
                {
                    int imageId = Convert.ToInt32(response.FaceMatches[0].Face.ExternalImageId);
                    if (collectionName.Equals("visitors"))
                        return GetVisitorNameById(imageId);
                    else
                        return GetEmployeeNameById(imageId);
                }

                else
                    return "No Match Found";
            }
            catch (Exception)
            {
                return "Exception Occurred";
            }
        }

        public async System.Threading.Tasks.Task<string> AddANewFaceAsync(string imageId)
        {
            try
            {
                string accessKeyId = "AKIAJM4TC3NLKAVPLCFQ";
                string secretAccessKey = "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";
                BasicAWSCredentials basicAWSCredentials = new BasicAWSCredentials(accessKeyId, secretAccessKey);
                AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient(basicAWSCredentials, RegionEndpoint.APSouth1);
                var response = await amazonRekognitionClient.IndexFacesAsync(new IndexFacesRequest
                {
                    CollectionId = "visitors",
                    ExternalImageId = imageId,
                    Image = new Image
                    {
                        S3Object = new Amazon.Rekognition.Model.S3Object
                        {
                            Bucket = "visitors-bucket",
                            Name = "new_visitor.jpg"
                        }
                    }
                });
                return "success";
            }
            catch (Exception exception)
            {
                return "exception: " + exception.StackTrace;
            }
        }
        public string GetVisitorNameById(int Id)
        {
            try
            {
                var entity = new DatabaseContext();
                Visitors Visitor = entity.Visitors.Where(entry => entry.VisitorId == Id).FirstOrDefault();
                return Visitor.NameOfVisitor + ":" + Id;
            }
            catch (Exception ex)
            {
                return "Unable to fetch name";
            }
        }

        public string GetEmployeeNameById(int Id)
        {
            try
            {
                var entity = new DatabaseContext();
                Employees employees = entity.Employees.Where(entry => entry.EmployeeId == Id.ToString()).FirstOrDefault();
                return employees.EmployeeName + ":" + Id;
            }
            catch (Exception ex)
            {
                return "Unable to fetch name";
            }
        }
    }
}
