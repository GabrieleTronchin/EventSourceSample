docker compose --env-file ./config/.env -f docker-compose.yml up -d

switch (Read-Host 'Remove unused images (Y/n)'){
    Y { 
        docker image prune --force 
        }
    N {   
    }
    default {  }
}