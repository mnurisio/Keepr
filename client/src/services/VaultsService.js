import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Vault } from "@/models/Vault.js"

class VaultsService {
    async getVaultById(vaultId) {
        AppState.activeVault = null
        const response = await api.get(`api/vaults/${vaultId}`)
        logger.log('getting profile by Id', response.data)
        const vault = new Vault(response.data)
        AppState.activeVault = vault
    }

    async getProfileVaults(profileId) {
        AppState.profileVaults = []
        const response = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('getting vaults by profile Id', response.data)
        const vaults = response.data.map(pojo => new Vault(pojo))
        AppState.profileVaults = vaults
    }

}

export const vaultsService = new VaultsService()