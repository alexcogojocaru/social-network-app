# Small tool to build the app automatically on windows
# Usage
# build.ps1 - to build and run the app
# build.ps1 run - only to run the app
# 
# The app is deployed to localhost:5001

if ( $null -eq $args[0] ) {
    Write-Output "Starting docker build..."
    Start-Sleep -s 1

    docker build -t socialapp .
    Write-Output "Finished the build..." 
}

Write-Output "Running on port 5001"
docker run -p 5001:5001 -e PORT=5001 -d socialapp

Write-Output "Deployed the app..."