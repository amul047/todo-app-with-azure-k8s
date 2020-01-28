Using powershell/command prompt, navigate to the folder containing the dockerfile for the image you want to make.

Then run the following command to create a local image.
```
docker image build -t <insert local image name> . 
```
Then run the following command to tag it with a docker hub image name (can do the same for other providers).
```
docker tag <insert local image name> <insert repository image name>:latest   
```
Then run the following to push the image to docker hub.
```
docker push <insert repository image name>:latest  
```
