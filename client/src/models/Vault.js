export class Vault{
    constructor(data){
        this.id = data.id
        this.CreatedAt = new Date(data.CreatedAt)
        this.updatedAt = new Date(data.updatedAt)
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.isPrivate = data.isPrivate
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}


let data = {
    "name": "My Collection",
    "description": "Can't live without these",
    "img": "https://images.unsplash.com/photo-1595429035839-c99c298ffdde?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&h=400&q=60",
    "isPrivate": false,
    "creatorId": "673faac60ee76bc126981172",
    "creator": {
        "name": "Austin Powers",
        "picture": "https://s.gravatar.com/avatar/8a0c4075ef7a6c67cd7756e81517329c?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fau.png",
        "coverImg": null,
        "id": "673faac60ee76bc126981172",
        "createdAt": "2025-01-21T21:13:03",
        "updatedAt": "2025-01-25T21:41:28"
    },
    "id": 6,
    "createdAt": "2025-01-24T20:58:30",
    "updatedAt": "2025-01-24T20:58:30"
}