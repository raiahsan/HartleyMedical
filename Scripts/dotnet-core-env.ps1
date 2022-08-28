setx ASPNETCORE_ENVIRONMENT $env:DEPLOYMENT_GROUP_NAME
echo "Deeployment Group: $env:DEPLOYMENT_GROUP_NAME" >> c:\temp\codedeploy.log