
# MongoDB on Windows in Minutes with Docker
Now that the prerequisites are out of the way, there are two steps to getting MongoDB up and running. First, create a volume to persist data between runs. If you skip this step, any changes you make will disappear when the container stops running.
```
docker volume create --name=mongodata
```
The name can be anything you like. The next step will pull the database image if it doesn’t already exist, then launch a running instance using the mounted volume.
```
docker run --name mongodb -v mongodata:/data/db -d -p 27017:27017 mongo
```
You can give the running container any name you like. The first time may feel like npm install as multiple layers are downloaded, but subsequent runs should go quite fast.

That’s it. You’re done. You have a fully functional version of MongoDB running on your machine! (Here’s mine running, mapped to a different port).

Of course, you probably want to tweak it a bit. By default, it’s running without authentication. To set up authentication, you need to create a login and then restart the service with the “authentication” switch.

First, log into the running (non-authenticated) version.
```
winpty docker exec -it mongodb bash
```
(winpty is needed from a typical Windows command line. You can omit it to run from other terminals. There is nothing special about mongodb other than it’s the name I gave the container in the previous step).

Open the MongoDB terminal:
```
mongo
```

Let’s assume your database is called “mydatabase” and you want to set up a user named “myuser” with password “secret”. These two steps will take care of it for you (the database does not have to exist yet):
```
use mydatabase

db.createUser({user:"myuser", pwd:"secret", roles:[{role:"readWrite", db: "mydatabase"}]});
```

After that, you can exit out of the MongoDB terminal and the bash shell that’s running. Next, stop and remove the existing instance and launch a new one with authentication active:
```
docker stop mongodb

docker rm mongodb

docker run --name mongodb -v mongodata:/data/db -d -p 27017:27017 mongo --auth
```
Now you can authenticate with the connection string:
```
mongodb://myuser:secret@localhost:27017/mydatabase
```


## Aggrigation
```
[
    {
        "$match": { 
					"PlayerId": {{appsmith.URL.queryParams.playerId}}
				}
    },
    {
        "$group": {
            _id: "$PlayerId",
            totalAmount: { $sum: "$Amount"}
        }
    }
]
```
