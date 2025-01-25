

export class Keep{
    constructor(data){
        this.id = data.id
        this.createdAt = new Date (data.createdAt)
        this.updatedAt = new Date (data.updatedAt)
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}


let data = {
    "name": "Beautiful",
    "description": "We can assume that any instance of a land can be construed as a midget airbus.",
    "img": "https://images.unsplash.com/photo-1564166174574-a9666f590437?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=762&h=717&q=60",
    "views": 0,
    "kept": 0,
    "creatorId": "673fb08be5c8f3f492851751",
    "creator": {
        "name": "notdrevil1@volcanolair.edu",
        "picture": "https://s.gravatar.com/avatar/944d1c5069b8cb4e9218c305a565a45e?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fno.png",
        "coverImg": null,
        "id": "673fb08be5c8f3f492851751",
        "createdAt": "2025-01-15T21:36:14",
        "updatedAt": "2025-01-15T21:36:14"
    },
    "id": 1,
    "createdAt": "2025-01-24T19:09:56",
    "updatedAt": "2025-01-24T19:09:56"
}