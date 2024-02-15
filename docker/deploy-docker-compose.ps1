docker compose --env-file ./config/.env -f docker-compose-sqlserver.yml  -f docker-compose-redis.yml -f docker-compose-sqlserver.yml up -d

switch (Read-Host 'Remove unused images (Y/n)'){
    Y { 
        docker image prune --force 
        }
    N {   
    }
    default {  }
}