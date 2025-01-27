export class VaultKeep{
    constructor(data){
        this.id = data.id
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
        this.vaultKeepId = data.vaultKeepId
        this.vaultId = data.vaultId
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}
