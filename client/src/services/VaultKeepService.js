import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"

class VaultKeepService{

   async DeleteKeep(vaultKeepId) {
        const response = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
        logger.log('deleting vaultkeep', (await response).data)
        const vaultKeepToDelete = AppState.vaultKeeps.findIndex(vaultKeep => vaultKeep.vaultKeepId == vaultKeepId)
        AppState.vaultKeeps.splice(vaultKeepToDelete, 1)
    }


}

export const vaultKeepService = new VaultKeepService()