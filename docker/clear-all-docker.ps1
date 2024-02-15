#remove swarm 
# docker swarm leave --force

#stop all containers

docker kill $(docker ps -q)

docker rm $(docker ps -a -q)

docker rmi -f $(docker images -q)

docker rm $(docker ps -a -f status=exited -q)

#cleanup volumes
docker volume prune --force