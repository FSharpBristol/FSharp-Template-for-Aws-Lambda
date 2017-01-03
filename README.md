# FSharp Template for Aws Lambda

Template for publishing F# projects to AWS Lambda.  Source code originally from this blog post http://lukemerrett.com/fsharp-on-aws-lambda/

The template at the root of this Git repository uses just dotnet core and AWS Lambda Tools.

If you prefer to use Serverless (and simplify the process of deploying & invoking the function) please use the template in the [Serverless folder](https://github.com/lukemerrett/FSharp-Template-for-Aws-Lambda/tree/master/serverless).

## Prerequisites

* [.Net Core 1.0.1 SDK](https://www.microsoft.com/net/download/core)
    * 1.1 isn't currently supported by AWS Lambda 
*  An AWS Account

## Build and Package the Template

The template is already set up as a working, albeit basic, Lambda function.  The tool defined in the `project.json` file allows us to package the project so it can be used by AWS.

CD into the root directory of the project and run:

```bash
dotnet restore
dotnet build 
dotnet lambda package --configuration Release --framework netcoreapp1.0
```

This will output the package zip to `bin\Release\netcoreapp1.0\FSharpLambdaTemplate.zip`.  When creating the AWS Lambda this is the zip file you will provide.

## Setting up an AWS Function

Log in to AWS Console and choose your region.

Go to Services -> Lambda -> Get Started Now.  Here select the Blank Function blueprint, then select no triggers (we'll trigger it ourselves) and click "Next".

The function can then be set up like this, note the selected zip file is the one packaged above:

![02](http://lukemerrett.com/images/fsharp-lambda-02.PNG)

From here we tell AWS where to find our handler function is.  The format of the handler declarion is `Assembly::Namespace.ClassName::MethodName` so in our case it is: `FSharpLambdaTemplate::AwsLambdaTemplate.Program::handler`

![03](http://lukemerrett.com/images/fsharp-lambda-03.PNG)

Leave everything else as default and click "Next" to go to the Review stage then "Create function".

## Testing the Function 

Once created you can click "Test" on the UI; this will invoke the function.

You should see "Execution result: succeeded(logs)" on the bottom panel.

Clicking "logs" will take you to CloudWatch, then clicking on the latest event you should see tracking of the requests starting and ending, with the output "Hello World!" in the middle.
