docker build -t greeter .
aws ecr get-login-password --region ap-south-1 | docker login --username AWS --password-stdin xxx.dkr.ecr.ap-south-1.amazonaws.com
docker tag greeter:latest xxx.dkr.ecr.ap-south-1.amazonaws.com/greeter:latest
docker push xxx.dkr.ecr.ap-south-1.amazonaws.com/greeter:latest