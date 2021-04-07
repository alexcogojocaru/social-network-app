# social-network-app

<h2>The app's architecture (might be changed in the future)</h2>
<img src="https://raw.githubusercontent.com/alexcogojocaru/social-network-app/master/res/api-architecture.png" alt="api-architecture">



## Building the application with Docker

```
git clone https://github.com/alexcogojocaru/social-network-app.git 
cd social-network-app
docker build -t socialapp .
docker run -p 5001:5001 -e PORT=5001 -d socialapp 
```