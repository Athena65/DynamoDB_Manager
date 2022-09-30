﻿using Amazon.DynamoDBv2.DataModel;

namespace DynamoDB_Manager.Models
{
    [DynamoDBTable("Students")]
    public class Student
    {
        [DynamoDBHashKey("id")]
        public int Id { get; set; }
        [DynamoDBProperty("class")]
        public int Class { get; set; }
        [DynamoDBProperty("country")]
        public string? Country { get; set; }
        [DynamoDBProperty("first_name")]
        public string? FirstName { get; set; }
        [DynamoDBProperty("last_name")]
        public string? LastName { get; set; }
    }
}