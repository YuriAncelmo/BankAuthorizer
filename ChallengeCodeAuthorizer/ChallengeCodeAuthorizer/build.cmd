dotnet publish -c Release
docker build -t authorizer-image -f Dockerfile .
docker run -it --rm authorizer-image