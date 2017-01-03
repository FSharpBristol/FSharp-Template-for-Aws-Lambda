namespace AwsLambdaTemplate

open Amazon.Lambda.Core

[<assembly:LambdaSerializer(typeof<Amazon.Lambda.Serialization.Json.JsonSerializer>)>]
do ()


module Models = 
    type Request = { Key1 : string; Key2 : string; Key3 : string }
    type Response = { Message : string; Request : Request }
 
module Program =
    open System
    open System.IO
    open System.Text
    open Models

    let handler(request:Request): Response = 
        { Message = "Go Serverless v1.0! Your function executed successfully!"
          Request = request }