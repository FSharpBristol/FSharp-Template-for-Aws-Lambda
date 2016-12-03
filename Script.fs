namespace AwsLambdaTemplate

module Program =
    open System
    open System.IO
    open System.Text
    open Amazon.Lambda.Core

    let handler(count:int, context:ILambdaContext) = 
        printfn "Hello World!"
        0